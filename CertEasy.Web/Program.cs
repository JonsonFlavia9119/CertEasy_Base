using CertEasy.Model;
using CertEasy.Data;
using CertEasy.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using Resend;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure SQL Server Column Options
var columnOptions = new ColumnOptions();
columnOptions.Store.Remove(StandardColumn.Properties);
columnOptions.Store.Remove(StandardColumn.MessageTemplate);
// Removed problematic additional columns EntityType and EntityID as they are causing runtime errors during DB queries
columnOptions.AdditionalColumns = new Collection<SqlColumn>
{
    new SqlColumn { ColumnName = "UserID", DataType = SqlDbType.Int, AllowNull = true }
};

// Add Serilog
Serilog.Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/admin-audit.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
    .WriteTo.MSSqlServer(
        connectionString: connectionString,
        sinkOptions: new MSSqlServerSinkOptions { TableName = "AppLogs", AutoCreateSqlTable = true },
        columnOptions: columnOptions)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllersWithViews(options => {
    options.Filters.Add<CertEasy.Web.Filters.AdminExceptionFilter>();
});

// Database configuration
builder.Services.AddDbContext<CertEasyDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("CertEasy.Data")));

// Authentication configuration
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    })
    .AddNegotiate();

// Add HttpClient for Resend
builder.Services.AddHttpClient();

// Configure Resend client
// API Key is retrieved dynamically in ResendEmailService from the database per the requirement.
// We do NOT register ResendClient here via AddHttpClient<IResend, ResendClient> because it requires 
// IOptions<ResendClientOptions> which we don't have statically. 
// ResendEmailService manually instantiates ResendClient using the dynamic API key.

// Register custom services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IWorkflowService, WorkflowService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IEmailService, ResendEmailService>();

var app = builder.Build();

// Database initialization - apply migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<CertEasyDbContext>();
        dbContext.Database.Migrate();
        Serilog.Log.Information("Database migrations applied successfully.");

        var fileUploadsPath = Path.Combine(app.Environment.WebRootPath ?? Path.Combine(app.Environment.ContentRootPath, "wwwroot"), "FileUploads");
        if (!Directory.Exists(fileUploadsPath))
        {
            Directory.CreateDirectory(fileUploadsPath);
        }
    }
    catch (Exception ex)
    {
        Serilog.Log.Fatal(ex, "Database migration/initialization failed");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
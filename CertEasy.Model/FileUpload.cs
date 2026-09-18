using System;
using System.ComponentModel.DataAnnotations;

namespace CertEasy.Model
{
    public class FileUpload : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string FileName { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string FilePath { get; set; } = string.Empty;

        [StringLength(100)]
        public string ContentType { get; set; } = string.Empty;

        public long FileSize { get; set; }

        public long EntityId { get; set; }

        public long EntityTypeId { get; set; }
    }
}

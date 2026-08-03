function WorkflowViewModel() {
    var self = this;

    self.currentStep = ko.observable(1);
    self.certifications = ko.observableArray([]);
    self.educationLevels = ko.observableArray([]);

    self.selectedCertificationID = ko.observable();
    self.selectedEducationLevelID = ko.observable();
    self.remarks = ko.observable('');
    self.message = ko.observable('');

    self.nextStep = function () {
        self.currentStep(self.currentStep() + 1);
    };

    self.prevStep = function () {
        self.currentStep(self.currentStep() - 1);
    };

    self.loadData = function () {
        $.getJSON('/Workflow/GetInitialData', function (data) {
            self.certifications(data.certifications);
            self.educationLevels(data.educationLevels);
        });
    };

    self.submitApplication = function () {
        var data = {
            CertificationID: parseInt(self.selectedCertificationID()),
            EducationLevelID: parseInt(self.selectedEducationLevelID()),
            Remarks: self.remarks()
        };

        $.ajax({
            url: '/Workflow/SubmitApplication',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: {
                'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
            },
            success: function (response) {
                if (response.success) {
                    self.message(response.message);
                    self.currentStep(4);
                }
            },
            error: function (err) {
                alert('Error submitting application. Please try again.');
            }
        });
    };

    self.loadData();
}

$(document).ready(function () {
    ko.applyBindings(new WorkflowViewModel(), document.getElementById('workflow-wizard'));
});
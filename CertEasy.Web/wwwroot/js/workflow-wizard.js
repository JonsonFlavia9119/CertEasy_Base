function WorkflowViewModel() {
    var self = this;

    self.currentStep = ko.observable(1);
    self.certifications = ko.observableArray([]);
    self.exams = ko.observableArray([]);
    self.educationLevels = ko.observableArray([
        { id: 1, name: 'High School' },
        { id: 2, name: "Bachelor's Degree" },
        { id: 3, name: "Master's Degree" },
        { id: 4, name: 'PhD' }
    ]);

    self.selectedCertificationID = ko.observable();
    self.selectedExamID = ko.observable();
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
            self.exams(data.exams);
        });
    };

    self.submitApplication = function () {
        var data = {
            CertificationID: parseInt(self.selectedCertificationID()),
            ExamID: parseInt(self.selectedExamID()),
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
                    self.currentStep(5);
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
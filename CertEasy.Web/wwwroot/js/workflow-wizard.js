function WorkflowViewModel() {
    var self = this;

    self.currentStep = ko.observable(1);
    self.certifications = ko.observableArray([]);
    self.exams = ko.observableArray([]);
    self.educationLevels = ko.observableArray([]);

    self.selectedCertificationID = ko.observable();
    self.selectedExamID = ko.observable();
    self.selectedEducationLevelID = ko.observable();
    self.remarks = ko.observable('');
    self.message = ko.observable('');

    self.selectedCertificationName = ko.computed(function () {
        var cert = ko.utils.arrayFirst(self.certifications(), function (item) {
            return item.id === self.selectedCertificationID();
        });
        return cert ? cert.name : 'Not selected';
    });

    self.selectedExamName = ko.computed(function () {
        var exam = ko.utils.arrayFirst(self.exams(), function (item) {
            return item.id === self.selectedExamID();
        });
        return exam ? (exam.examName + ' - ' + exam.examCenter) : 'Not selected';
    });

    self.selectedEducationName = ko.computed(function () {
        var edu = ko.utils.arrayFirst(self.educationLevels(), function (item) {
            return item.id === self.selectedEducationLevelID();
        });
        return edu ? edu.name : 'Not selected';
    });

    self.nextStep = function () {
        if (self.currentStep() < 5) {
            self.currentStep(self.currentStep() + 1);
        }
    };

    self.prevStep = function () {
        if (self.currentStep() > 1) {
            self.currentStep(self.currentStep() - 1);
        }
    };

    self.loadData = function () {
        $.getJSON('/Workflow/GetInitialData', function (data) {
            self.certifications(data.certifications);
            self.exams(data.exams);
            self.educationLevels(data.educations);
        });
    };

    self.submitApplication = function () {
        if (!self.selectedEducationLevelID()) {
            alert('Please select an education level.');
            return;
        }

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
                    self.currentStep(6);
                } else {
                    alert(response.message);
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
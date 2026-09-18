function WorkflowViewModel() {
    var self = this;

    self.currentStep = ko.observable(1);
    self.certifications = ko.observableArray([]);
    self.exams = ko.observableArray([]);
    self.educationLevels = ko.observableArray([]);

    // Selected values for 3 dropdowns
    self.selectedExamName = ko.observable('');
    self.selectedLocation = ko.observable('');
    self.selectedExamID = ko.observable();

    self.selectedCertificationID = ko.observable();
    self.selectedEducationLevelID = ko.observable();
    self.remarks = ko.observable('');
    self.message = ko.observable('');

    // Document Uploads
    self.certificationDocumentFile = ko.observable(null);
    self.certificationDocumentName = ko.observable('None selected');
    self.educationDocumentFile = ko.observable(null);
    self.educationDocumentName = ko.observable('None selected');

    self.onCertificationDocumentChange = function (data, event) {
        var file = event.target.files[0];
        if (file) {
            self.certificationDocumentFile(file);
            self.certificationDocumentName(file.name);
        } else {
            self.certificationDocumentFile(null);
            self.certificationDocumentName('None selected');
        }
    };

    self.onEducationDocumentChange = function (data, event) {
        var file = event.target.files[0];
        if (file) {
            self.educationDocumentFile(file);
            self.educationDocumentName(file.name);
        } else {
            self.educationDocumentFile(null);
            self.educationDocumentName('None selected');
        }
    };

    // 1. Unique Exam Names
    self.uniqueExamNames = ko.computed(function () {
        var names = [];
        ko.utils.arrayForEach(self.exams(), function (item) {
            if (item.examName && names.indexOf(item.examName) === -1) {
                names.push(item.examName);
            }
        });
        return names;
    });

    // Reset dependent dropdowns when Exam Name changes
    self.selectedExamName.subscribe(function () {
        self.selectedLocation('');
        self.selectedExamID(null);
    });

    // 2. Locations filtered by selected Exam Name
    self.availableLocations = ko.computed(function () {
        var examName = self.selectedExamName();
        if (!examName) return [];
        var locations = [];
        ko.utils.arrayForEach(self.exams(), function (item) {
            if (item.examName === examName && item.examCenter && locations.indexOf(item.examCenter) === -1) {
                locations.push(item.examCenter);
            }
        });
        return locations;
    });

    // Reset Exam Date selection when Location changes
    self.selectedLocation.subscribe(function () {
        self.selectedExamID(null);
    });

    // 3. Exam Dates/Slots filtered by selected Exam Name and Location
    self.availableExamSlots = ko.computed(function () {
        var examName = self.selectedExamName();
        var location = self.selectedLocation();
        if (!examName || !location) return [];
        var slots = [];
        ko.utils.arrayForEach(self.exams(), function (item) {
            if (item.examName === examName && item.examCenter === location) {
                slots.push(item);
            }
        });
        return slots;
    });

    self.selectedCertificationName = ko.computed(function () {
        var cert = ko.utils.arrayFirst(self.certifications(), function (item) {
            return item.id === self.selectedCertificationID();
        });
        return cert ? cert.name : 'Not selected';
    });

    self.selectedExamDisplay = ko.computed(function () {
        var exam = ko.utils.arrayFirst(self.exams(), function (item) {
            return item.id === self.selectedExamID();
        });
        if (!exam) return 'Not selected';
        var slotDate = new Date(exam.examSlot).toLocaleString();
        return exam.examName + ' - ' + exam.examCenter + ' (' + slotDate + ')';
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
        $.ajax({
            url: '/Workflow/GetInitialData',
            type: 'GET',
            success: function (data) {
                self.certifications(data.certifications);
                self.exams(data.exams);
                self.educationLevels(data.educations);
            }
        });
    };

    self.submitApplication = function () {
        if (!self.selectedEducationLevelID()) {
            alert('Please select an education level.');
            return;
        }

        var formData = new FormData();
        formData.append('CertificationID', self.selectedCertificationID());
        formData.append('ExamID', self.selectedExamID());
        formData.append('EducationLevelID', self.selectedEducationLevelID());
        if (self.remarks()) {
            formData.append('Remarks', self.remarks());
        }
        if (self.certificationDocumentFile()) {
            formData.append('CertificationDocument', self.certificationDocumentFile());
        }
        if (self.educationDocumentFile()) {
            formData.append('EducationDocument', self.educationDocumentFile());
        }

        $.ajax({
            url: '/Workflow/SubmitApplication',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
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
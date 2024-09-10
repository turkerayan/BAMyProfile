using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Constants;

public class Messages
{

    public const string ExampleAddSuccess = "Example_Add_Success";
    public const string ExampleAddFail = "Example_Add_Fail";
    public const string ExampleUpdateSuccess = "Example_Update_Success";
    public const string ExampleUpdateFail = "Example_Update_Fail";
    public const string ExampleListedSuccess = "Example_Listed_Success";
    public const string ExampleFoundSuccess = "Example_Found_Success";
    public const string ExampleDeletedSuccess = "Example_Deleted_Success";
    public const string ExampleListedFail = "Example_Listed_Fail";
    public const string ExampleAlreadyExists = "Example_Already_Exists";
    public const string ExampleNotFound = "Example_Not_Found";
    public const string ListHasNoExamples = "List_Has_No_Examples";
    public const string ExampleIdRequired = "Example_Id_Required";
    public const string ExampleNameRequired = "Example_Name_Required";


    //Yetenek için mesaj
    public const string CapabilityAddSuccess = "Capability added successfully.";
    public const string CapabilityAddFail = "Failed to add capability.";
    public const string CapabilityUpdateSuccess = "Capability updated successfully.";
    public const string CapabilityUpdateFail = "Failed to update capability.";
    public const string CapabilityListedSuccess = "Capabilities listed successfully.";
    public const string CapabilityFoundSuccess = "Capability found successfully.";
    public const string CapabilityDeletedSuccess = "Capability deleted successfully.";
    public const string CapabilityListedFail = "Failed to list capabilities.";
    public const string CapabilityAlreadyExists = "Capability already exists.";
    public const string CapabilityNotFound = "Capability not found.";
    public const string CapabilityIdRequired = "Capability ID is required.";
    public const string CapabilityNameCannotBeEmpty = "Capability name cannot be empty.";
    public const string CapabilityNameCannotExceed256Letters = "Capability name cannot exceed 256 characters.";
    public const string CapabilityNameMustBeAtLeast2Characters = "Capability name must be at least 2 characters long.";

    public const string ListHasNoCapability = "List_Has_No_Capability";
    //diller için messaj
    public const string LanguagesAddSuccess = "Languages_Add_Success";
    public const string LanguagesAddFail = "Languages_Add_Fail";
    public const string LanguagesUpdateSuccess = "Languages_Update_Success";
    public const string LanguagesUpdateFail = "Languages_Update_Fail";
    public const string LanguagesListedSuccess = "Languages_Listed_Success";
    public const string LanguagesFoundSuccess = "Languages_Found_Success";
    public const string LanguagesDeletedSuccess = "Languages_Deleted_Success";
    public const string LanguagesListedFail = "Languages_Listed_Fail";
    public const string LanguagesAlreadyExists = "Languages_Already_Exists";
    public const string LanguagesNotFound = "Languages_Not_Found";
    public const string ListHasNoLanguages = "List_Has_No_Languages";
    public const string LanguageNameCannotExceed2Letters = "LanguageNameCannotExceed2Letters";
    public const string LanguagesIdRequired = "Languages_Id_Required";


    //Aday için mesajlar
    public const string CandidateAlreadyExists = "Candidate_Already_Exists";
    public const string CandidateAddSuccess = "Candidate_Add_Success";
    public const string CandidateNotFound = "Candidate_Not_Found";
    public const string CandidateDeletedSuccess = "Candidate_Deleted_Success";
    public const string CandidateListedSuccess = "Candidate_Listed_Success";
    public const string CandidateFoundSuccess = "Candidate_Found_Success";
    public const string CandidateUpdateSuccess = "Candidate_Update_Success";
    public const string CandidateAddFail = "Candidate_Add_Fail";

    public const string CandidateNameCannotBeEmpty = "Candidate_Name_Cannot_Be_Empty";
    public const string CandidateNameMustBeAtLeast3Characters = "Candidate_Name_Must_Be_At_Least_3_Characters";
    public const string CandidateNameMustBeMaximum30Characters = "Candidate_Name_Must_Be_Maximum_30_Characters";
    public const string CandidateNameCanOnlyContainLetters = "Candidate_Name_Can_Only_Contain_Letters";
    public const string CandidateSurnameCannotBeEmpty = "Candidate_Surname_Cannot_Be_Empty";
    public const string CandidateSurnameMustBeAtLeast2Characters = "Candidate_Surname_Must_Be_At_Least_2_Characters";
    public const string CandidateSurnameMustBeMaximum30Characters = "Candidate_Surname_Must_Be_Maximum_30_Characters";
    public const string CandidateSurnameCanOnlyContainLetters = "Candidate_Surname_Can_Only_Contain_Letters";
    public const string CandidateEmailCannotBeEmpty = "Candidate_Email_Cannot_Be_Empty";


    public const string CertificateAddSuccess = "Certificate added successfully.";
    public const string CertificateAddFail = "Failed to add certificate.";
    public const string CertificateUpdateSuccess = "Certificate updated successfully.";
    public const string CertificateUpdateFail = "Failed to update certificate.";
    public const string CertificateListedSuccess = "Certificates listed successfully.";
    public const string CertificateFoundSuccess = "Certificate found successfully.";
    public const string CertificateDeletedSuccess = "Certificate deleted successfully.";
    public const string CertificateListedFail = "Failed to list certificates.";
    public const string CertificateAlreadyExists = "Certificate already exists.";
    public const string CertificateNotFound = "Certificate not found.";
    public const string ListHasNoCertificates = "No certificates found in the list.";
    public const string CertificateIdRequired = "Certificate ID is required.";
    public const string CertificateFileCannotBeEmpty = "Certificate File is required.";
    public const string CertificateFileTypeFail = "Certificate File should be JPG,JPEG or PDF";



    public const string ReferenceAddSuccess = "Reference added successfully.";
    public const string ReferenceAddFail = "Failed to add reference.";
    public const string ReferenceUpdateSuccess = "Reference updated successfully.";
    public const string ReferenceUpdateFail = "Failed to update reference.";
    public const string ReferenceListedSuccess = "References listed successfully.";
    public const string ReferenceFoundSuccess = "Reference found successfully.";
    public const string ReferenceDeletedSuccess = "Reference deleted successfully.";
    public const string ReferenceListedFail = "Failed to list references.";
    public const string ReferenceAlreadyExists = "Reference already exists.";
    public const string ReferenceNotFound = "Reference not found.";
    public const string ListHasNoReferences = "No references found in the list.";

    public const string TrainingProgramAddSuccess = "Training program added successfully.";
    public const string TrainingProgramAddFail = "Failed to add training program.";
    public const string TrainingProgramUpdateSuccess = "Training program updated successfully.";
    public const string TrainingProgramUpdateFail = "Failed to update training program.";
    public const string TrainingProgramListedSuccess = "Training programs listed successfully.";
    public const string TrainingProgramFoundSuccess = "Training program found successfully.";
    public const string TrainingProgramDeletedSuccess = "Training program deleted successfully.";
    public const string TrainingProgramListedFail = "Failed to list training programs.";
    public const string TrainingProgramAlreadyExists = "Training program already exists.";
    public const string TrainingProgramNotFound = "Training program not found.";
    public const string ListHasNoTrainingProgram = "No training programs found in the list.";


    public const string EventAddSuccess = "Event Add Success";
    public const string EventAddFail = "Event Add Failed";
    public const string EventUpdateSuccess = "Event Update Success";
    public const string EventUpdateFail = "Event Update Failed";
    public const string EventListedSuccess = "Event Listed Success";
    public const string EventFoundSuccess = "Event Found Success";
    public const string EventDeletedSuccess = "Event Deleted Success";
    public const string EventListedFail = "Event Listing Failed";
    public const string EventAlreadyExists = "Event Already Exists";
    public const string EventNotFound = "Event Not Found";
    public const string ListHasNoEvents = "List Has No Events";


    public const string EventNameCanNotBeEmpty = "Event_Name_Can_Not_Be_Empty";
    public const string EventNameMustBeAtLeast2Characters = "Event_Name_Must_Be_At_Least_2_Characters";
    public const string EventNameCanNotExceed50Characters = "Event_Name_Can_Not_Exceed_50_Characters";
    public const string EventNameCanContainLettersAndNumbers = "Event_Name_Can_Contain_Letters_And_Numbers";
    public const string EventDateCanNotBeEmpty = "Event_Date_Can_Not_Be_Empty";
    public const string EventTypeCanNotBeEmpty = "Event_Type_Can_Not_Be_Empty";
    public const string EventIdRequired = "EventIdRequired";

    public const string UniversityAddSuccess = "University_Add_Success";
    public const string UniversityAddFail = "University_Add_Fail";
    public const string UniversityUpdateSuccess = "University_Update_Success";
    public const string UniversityUpdateFail = "University_Update_Fail";
    public const string UniversityListedSuccess = "University_Listed_Success";
    public const string UniversityFoundSuccess = "University_Found_Success";
    public const string UniversityDeletedSuccess = "University_Deleted_Success";
    public const string UniversityListedFail = "University_Listed_Fail";
    public const string UniversityAlreadyExists = "University_Already_Success";
    public const string UniversityNotFound = "University_Not_Found";
    public const string ListHasNoUniversities = "List_Has_No_University";
    public const string UniversityIdRequired = "UniversityIdRequired";



    public const string FacultyAddSuccess = "Faculty_Add_Success";
    public const string FacultyAddFail = "Faculty_Add_Fail";
    public const string FacultyUpdateSuccess = "Faculty_Update_Success";
    public const string FacultyUpdateFail = "Faculty_Update_Fail";
    public const string FacultyListedSuccess = "Faculty_Listed_Success";
    public const string FacultyFoundSuccess = " Faculty_Found_Success";
    public const string FacultyDeletedSuccess = "Faculty_Deleted_Success";
    public const string FacultyListedFail = "Faculty_Listed_Fail";
    public const string FacultyAlreadyExists = "Faculty_Already_Exists";
    public const string FacultyNotFound = "Faculty_Not_Found";
    public const string ListHasNoFaculties = "List_Has_No_Faculties";
    public const string FacultyIdRequired = "Faculty_Id_Required";
    public const string FacultyNameCannotExceed2Letters = "FacultyNameCannotExceed2Letters";



    public const string DepartmentAddSuccess = "Department_Add_Success";
    public const string DepartmentAddFail = "Bölüm Ekleme Başarısız";
    public const string DepartmentUpdateSuccess = "Department_Update_Success";
    public const string DepartmentUpdateFail = "Bölüm Güncelleme Başarısız";
    public const string DepartmentListedSuccess = "Department_Listed_Success";
    public const string DepartmentFoundSuccess = "Department_Found_Success";
    public const string DepartmentDeletedSuccess = "Department_Deleted_Success";
    public const string DepartmentListedFail = "Bölümler Listeleme Başarısız";
    public const string DepartmentAlreadyExists = "Department_Already_Exists";
    public const string DepartmentNotFound = "Department_Not_Found";
    public const string ListHasNoDepartments = "List_Has_No_Departments";
    public const string DepartmentIdRequired = "DepartmentIdRequired";

    //öğrenci için mesajlar
    public const string StudentAddSuccess = "Student Add Success";
    public const string StudentAddFail = "Student Add Fail";
    public const string StudentUpdateSuccess = "Student Update Success";
    public const string StudentUpdateFail = "Student Update Fail";
    public const string StudentListedSuccess = "Student Listed Success";
    public const string StudentFoundSuccess = "Student Found Success";
    public const string StudentDeletedSuccess = "Student Deleted Success";
    public const string StudentListedFail = "Student Listed Fail";
    public const string StudentAlreadyExists = "Student Already Exists";
    public const string StudentNotFound = "Student Not Found";
    public const string ListHasNoStudent = "List Has No Student";

    public const string StudentIdRequired = "Student Id Required";
    public const string StudentNameCannotBeEmpty = "Student Name Cannot Be Empty";
    public const string StudentNameMustBeAtLeast3Characters = "Student Name Must Be At Least 3 Characters";
    public const string StudentNameMustBeMaximum30Characters = "Student Name Must Be Maximum 30 Characters";
    public const string StudentNameCanOnlyContainLetters = "Student Name Can Only Contain Letters";
    public const string StudentSurnameCannotBeEmpty = "Student Surname Cannot Be Empty";
    public const string StudentSurnameMustBeAtLeast2Characters = "Student Surname Must Be At Least 2 Characters";
    public const string StudentSurnameMustBeMaximum30Characters = "Student Surname Must Be Maximum 30 Characters";
    public const string StudentSurnameCanOnlyContainLetters = "Student Surname Can Only Contain Letters";
    public const string StudentEmailCannotBeEmpty = "Student Email Cannot Be Empty";
    public const string IsCandidateIsRequired = "Is Candidate Is Required";


    public const string ExperienceAddSuccess = "Experience_Add_Success";
    public const string ExperienceAddFail = "Experience_Add_Fail";
    public const string ExperienceUpdateSuccess = "Experience_Update_Success";
    public const string ExperienceUpdateFail = "Experience_Update_Fail";
    public const string ExperienceListedSuccess = "Experience_Listed_Success";
    public const string ExperienceFoundSuccess = "Experience_Found_Success";
    public const string ExperienceDeletedSuccess = "Experience_Deleted_Success";
    public const string ExperienceListedFail = "Experience_Listed_Fail";
    public const string ExperienceAlreadyExists = "Experience_Already_Exists";
    public const string ExperienceNotFound = "Experience_Not_Found";
    public const string ListHasNoExperiences = "List_Has_No_Experiences";
    public const string ExperienceIdNotEmpty = "ExperienceIdNotEmpty";


    public const string CvAddSuccess = "Cv_Add_Success";
    public const string CvAddFail = "Cv_Add_Fail";
    public const string CvUpdateSuccess = "Cv_Update_Success";
    public const string CvUpdateFail = "Cv_Update_Fail";
    public const string CvListedSuccess = "Cv_Listed_Success";
    public const string CvFoundSuccess = "Cv_Found_Success";
    public const string CvDeletedSuccess = "Cv_Deleted_Success";
    public const string CvListedFail = "Cv_Listed_Fail";
    public const string CvAlreadyExists = "Cv_Already_Exists";
    public const string CvNotFound = "Cv_Not_Found";
    public const string CvIdRequired = "Cv_Id_Required";

    public const string ListHasNoCvs = "List_Has_No_Cvs";

    public const string InterviewAddSuccess = "Interview_Add_Success";
    public const string InterviewAddFail = "Interview_Add_Fail";
    public const string InterviewUpdateSuccess = "Interview_Update_Success";
    public const string InterviewUpdateFail = "Interview_Update_Fail";
    public const string InterviewListedSuccess = "Interview_Listed_Success";
    public const string InterviewFoundSuccess = "Interview_Found_Success";
    public const string InterviewDeletedSuccess = "Interview_Deleted_Success";
    public const string InterviewListedFail = "Interview_Listed_Fail";
    public const string InterviewAlreadyExists = "Interview_Already_Exists";
    public const string InterviewNotFound = "Interview_Not_Found";
    public const string ListHasNoInterviews = "List_Has_No_Interviews";


    public const string ApplicationInterviewAddSuccess = "Application_Interview_Add_Success";
    public const string ApplicationInterviewAddFail = "Application_Interview_Add_Fail";
    public const string ApplicationInterviewUpdateSuccess = "Application_Interview_Update_Success";
    public const string ApplicationInterviewUpdateFail = "Application_Interview_Update_Fail";
    public const string ApplicationInterviewListedSuccess = "Application_Interview_Listed_Success";
    public const string ApplicationInterviewFoundSuccess = "Application_Interview_Found_Success";
    public const string ApplicationInterviewDeletedSuccess = "Application_Interview_Deleted_Success";
    public const string ApplicationInterviewListedFail = "Application_Interview_Listed_Fail";
    public const string ApplicationInterviewAlreadyExists = "Application_Interview_Already_Exists";
    public const string ApplicationInterviewNotFound = "Application_Interview_Not_Found";
    public const string ListHasNoApplicationInterviews = "List_Has_No_Application_Interviews";


    public const string ApplicationInterviewerAddSuccess = "Application_Interviewer_Add_Success";
    public const string ApplicationInterviewerAddFail = "Application_Interviewer_Add_Fail";
    public const string ApplicationInterviewerUpdateSuccess = "Application_Interviewer_Update_Success";
    public const string ApplicationInterviewerUpdateFail = "Application_Interviewer_Update_Fail";
    public const string ApplicationInterviewerListedSuccess = "Application_Interviewer_Listed_Success";
    public const string ApplicationInterviewerFoundSuccess = "Application_Interviewer_Found_Success";
    public const string ApplicationInterviewerDeletedSuccess = "Application_Interviewer_Deleted_Success";
    public const string ApplicationInterviewerListedFail = "Application_Interviewer_Listed_Fail";
    public const string ApplicationInterviewerAlreadyExists = "Application_Interviewer_Already_Exists";
    public const string ApplicationInterviewerNotFound = "Application_Interviewer_Not_Found";
    public const string ListHasNoApplicationInterviewers = "List_Has_No_Application_Interviewers";

    public const string CandidateIdRequired = "Candidate_Id_Required";
    public const string CompanyIdRequired = "Company_Id_Required";
    public const string ApplicationInterviewDateRequired = "Application_Interview_Date_Required";
    public const string InvalidDateFormat = "Invalid_Date_Format";
    public const string ApplicationInterviewDateWithinYear = "Application_Interview_Date_Within_Year";
    public const string ApplicationInterviewStatusForRequired = "Application_Interview_Status_For_Required";

    public const string ApplicationInterviewerNameCannotBeEmpty = "Application_Interviewer_Name_Cannot_Be_Empty";
    public const string ApplicationInterviewerNameCanOnlyContainLetters = "Application_Interviewer_Name_Can_Only_Contain_Letters";
    public const string ApplicationInterviewerSurnameCannotBeEmpty = "Application_Interviewer_Surname_Cannot_Be_Empty";
    public const string ApplicationInterviewerSurnameCanOnlyContainLetters = "Application_Interviewer_Surname_Can_Only_Contain_Letters";
    public const string ApplicationInterviewerEmailCannotBeEmpty = "Application_Interviewer_Email_Cannot_Be_Empty";
    public const string ApplicationInterviewerPhoneNumberCannotBeEmpty = "Application_Interviewer_Phone_Number_Cannot_Be_Empty";
    public const string PleaseEnterValidEmail = "Please_Enter_Valid_Email";
    public const string PhoneNumberMustBe11DigitsandStartingWith0 = "Phone_Number_Must_Be_11_Digits_and_Starting_With_0";
    public const string PhoneNumberCanOnlyContainNumber = "Phone_Number_Can_Only_Contain_Number";
    public const string GenderMustBeSelected = "Gender_Must_Be_Selected";
    public const string PleaseSelectValidGender = "Please_Select_Valid_Gender";
    public const string DateOfBirthCannotBeEmpty = "Date_Of_Birth_Cannot_Be_Empty";
    public const string PleaseEnterValidDateofBirth = "Please_Enter_Valid_Date_of_Birth";
    public const string AddressMustContainAtLeast2Characters = "Address_Must_Contain_At_Least_2_Characters";
    public const string AddressCanBeUpTo200Characters = "Address_Can_Be_Up_To_200_Characters";
    public const string ApplicationInterviewCommentsRequired = "Application_Interview_Comments_Required";
    public const string ApplicationInterviewCommentsMaxLength = "Application_Interview_Comments_MaxLength";
    public const string ApplicationInterviewIdRequired = "Application_Interview_Id_Required";
    public const string ApplicationInterviewerIdRequired = "Application_Interviewer_Id_Required";





    //Account mesajları
    public const string AccountAddSuccess = "Hesap Ekleme Başarılı";
    public const string AccountAddFail = "Hesap Ekleme Başarısız";
    public const string AccountUpdateSuccess = "Hesap Güncelleme Başarılı";
    public const string AccountUpdateFail = "Hesap Güncelleme Başarısız";
    public const string AccountListedSuccess = "Hesap Listeleme Başarılı";
    public const string AccountFoundSuccess = "Hesap Görüntüleme Başarılı";
    public const string AccountDeletedSuccess = "Hesap Silme Başarılı";
    public const string AccountListedFail = "Hesap Listeleme Başarısız";
    public const string AccountAlreadyExists = "Hesap Zaten Kayıtlı";
    public const string AccountNotFound = "Hesap Bulunamadı";
    public const string ListHasNoAccounts = "Listelenecek Hesap Yok";

    public const string CapabilityStudentAddSuccess = "Yetenek Öğrenci Ekleme Başarılı";
    public const string CapabilityStudentAddFail = "Yetenek Öğrenci Ekleme Başarısız";
    public const string CapabilityStudentUpdateSuccess = "Yetenek Öğrenci Güncelleme Başarılı";
    public const string CapabilityStudentUpdateFail = "Yetenek Öğrenci Güncelleme Başarısız";
    public const string CapabilityStudentListedSuccess = "Yetenek Öğrenci Listeleme Başarılı";
    public const string CapabilityStudentFoundSuccess = "Yetenek Öğrenci Görüntüleme Başarılı";
    public const string CapabilityStudentDeletedSuccess = "Yetenek Öğrenci Silme Başarılı";
    public const string CapabilityStudentListedFail = "Yetenek Öğrenci Listeleme Başarısız";
    public const string CapabilityStudentAlreadyExists = "Yetenek Öğrenci Zaten Kayıtlı";
    public const string CapabilityStudentNotFound = "Yetenek Öğrenci Bulunamadı";
    public const string ListHasNoCapabilityStudents = "Listelenecek Yetenek Öğrenci Yok";
    public const string CapabilityStudentIdRequired = "Yetenek Öğrenci Id Boş Olamaz";

    public const string EventStudentAddSuccess = "Event_Student_Add_Success";
    public const string EventStudentAddFail = "Event_Student_Add_Fail";
    public const string EventStudentUpdateSuccess = "Event_Student_Update_Success";
    public const string EventStudentUpdateFail = "Event_Student_Update_Fail";
    public const string EventStudentListedSuccess = "Event_Student_Listed_Success";
    public const string EventStudentFoundSuccess = "Event_Student_Found_Success";
    public const string EventStudentDeletedSuccess = "Event_Student_Deleted_Success";
    public const string EventStudentListedFail = "Event_Student_Listed_Fail";
    public const string EventStudentAlreadyExists = "Event_Student_Already_Exists";
    public const string EventStudentNotFound = "Event_Student_Not_Found";
    public const string ListHasNoEventStudents = "List_Has_No_Event_Students";
    public const string EventStudentIdRequired = "Event_Student_Id_Required";

    public const string ReferenceStudentAddSuccess = "Referans Öğrenci Ekleme Başarılı";
    public const string ReferenceStudentAddFail = "Referans Öğrenci Ekleme Başarısız";
    public const string ReferenceStudentUpdateSuccess = "Referans Öğrenci Güncelleme Başarılı";
    public const string ReferenceStudentUpdateFail = "Referans Öğrenci Güncelleme Başarısız";
    public const string ReferenceStudentListedSuccess = "Referans Öğrenci Listeleme Başarılı";
    public const string ReferenceStudentFoundSuccess = "Referans Öğrenci Görüntüleme Başarılı";
    public const string ReferenceStudentDeletedSuccess = "Referans Öğrenci Silme Başarılı";
    public const string ReferenceStudentListedFail = "Referans Öğrenci Listeleme Başarısız";
    public const string ReferenceStudentAlreadyExists = "Referans Öğrenci Zaten Kayıtlı";
    public const string ReferenceStudentNotFound = "Referans Öğrenci Bulunamadı";
    public const string ListHasNoReferenceStudents = "Listelenecek Referans Öğrenci Yok";
    public const string RefenreceStudentIdRequired = "Referans Öğrenci Id Boş Olamaz";

    public const string StudentCertificateAddSuccess = "Student_Certificate_Add_Success";
    public const string StudentCertificateAddFail = "Student_Certificate_Add_Fail";
    public const string StudentCertificateUpdateSuccess = "Student_Certificate_Update_Success";
    public const string StudentCertificateUpdateFail = "Student_Certificate_Update_Fail";
    public const string StudentCertificateListedSuccess = "Student_Certificate_Listed_Success";
    public const string StudentCertificateFoundSuccess = "Student_Certificate_Found_Success";
    public const string StudentCertificateDeletedSuccess = "Student_Certificate_Deleted_Success";
    public const string StudentCertificateListedFail = "Student_Certificate_Listed_Fail";
    public const string StudentCertificateAlreadyExists = "Student_Certificate_Already_Exists";
    public const string StudentCertificateNotFound = "Student_Certificate_Not_Found";
    public const string ListHasNoStudentCertificates = "List_Has_No_Student_Certificates";
    public const string StudentCertificateIdRequired = "Student_Certificate_Id_Required";

    public const string StudentDepartmentAddSuccess = "Student_Department_Add_Success";
    public const string StudentDepartmentAddFail = "Student_Department_Add_Fail";
    public const string StudentDepartmentUpdateSuccess = "Student_Department_Update_Success";
    public const string StudentDepartmentUpdateFail = "Student_Department_Update_Fail";
    public const string StudentDepartmentListedSuccess = "Student_Department_Listed_Success";
    public const string StudentDepartmentFoundSuccess = "Student_Department_Found_Success";
    public const string StudentDepartmentDeletedSuccess = "Student_Department_Deleted_Success";
    public const string StudentDepartmentListedFail = "Student_Department_Listed_Fail";
    public const string StudentDepartmentAlreadyExists = "Student_Department_Already_Exists";
    public const string StudentDepartmentNotFound = "Student_Department_Not_Found";
    public const string ListHasNoStudentDepartments = "List_Has_No_Student_Departments";
    public const string StudentDepartmentIdRequired = "Student_Department_Id_Required";

    public const string StudentLanguageAddSuccess = "Student_Language_Add_Success";
    public const string StudentLanguageAddFail = "Student_Language_Add_Fail";
    public const string StudentLanguageUpdateSuccess = "Student_Language_Update_Success";
    public const string StudentLanguageUpdateFail = "Student_Language_Update_Fail";
    public const string StudentLanguageListedSuccess = "Student_Language_Listed_Success";
    public const string StudentLanguageFoundSuccess = "Student_Language_Found_Success";
    public const string StudentLanguageDeletedSuccess = "Student_Language_Deleted_Success";
    public const string StudentLanguageListedFail = "Student_Language_Listed_Fail";
    public const string StudentLanguageAlreadyExists = "Student_Language_Already_Exists";
    public const string StudentLanguageNotFound = "Student_Language_Not_Found";
    public const string ListHasNoStudentLanguages = "List_Has_No_Student_Languages";
    public const string StudentLanguageIdRequired = "Student_Language_Id_Required";

    public const string StudentTrainingProgramAddSuccess = "Student_Training_Program_Add_Success";
    public const string StudentTrainingProgramAddFail = "Student_Training_Program_Add_Fail";
    public const string StudentTrainingProgramUpdateSuccess = "Student_Training_Program_Update_Success";
    public const string StudentTrainingProgramUpdateFail = "Student_Training_Program_Update_Fail";
    public const string StudentTrainingProgramListedSuccess = "Student_Training_Program_Listed_Success";
    public const string StudentTrainingProgramFoundSuccess = "Student_Training_Program_Found_Success";
    public const string StudentTrainingProgramDeletedSuccess = "Student_Training_Program_Deleted_Success";
    public const string StudentTrainingProgramListedFail = "Student_Training_Program_Listed_Fail";
    public const string StudentTrainingProgramAlreadyExists = "Student_Training_Program_Already_Exists";
    public const string StudentTrainingProgramNotFound = "Student_Training_Program_Not_Found";
    public const string ListHasNoStudentTrainingPrograms = "List_Has_No_Student_Training_Programs";
    public const string StudentTrainingProgramIdRequired = "Student_Training_Program_Id_Required";

    public const string CompanyAddSuccess = "Company_Add_Success";
    public const string CompanyAddFail = "Company_Add_Fail";
    public const string CompanyUpdateSuccess = "Company_Update_Success";
    public const string CompanyUpdateFail = "Company_Update_Fail";
    public const string CompanyListedSuccess = "Company_Listed_Success";
    public const string CompanyFoundSuccess = "Company_Found_Success";
    public const string CompanyDeletedSuccess = "Company_Deleted_Success";
    public const string CompanyListedFail = "Company_Listed_Fail";
    public const string CompanyAlreadyExists = "Company_Already_Exists";
    public const string CompanyNotFound = "Company_Not_Found";
    public const string ListHasNoCompanies = "List_Has_No_Companies";
    public const string CompanyNameNotEmpty = "Company_Name_Not_Empty";
    public const string CompanyNameMaxLength = "Company_Name_Max_Length";
    public const string CompanyNameMinLength = "Company_Name_Min_Length";
    public const string CompanyLocationNotEmpty = "Company_Location_Not_Empty";
    public const string CompanyLocationMaxLength = "Company_Location_Max_Length";
    public const string CompanyLocationMinLength = "Company_Location_Min_Length";
    public const string CompanySectorNotEmpty = "Company_Sector_Not_Empty";
    public const string CompanySectorMaxLength = "Company_Sector_Max_Length";
    public const string CompanySectorMinLength = "Company_Sector_Min_Length";
    public const string CompanyGeneralInformationNotEmpty = "Company_General_Information_Not_Empty";
    public const string CompanyGeneralInformationMaxLength = "Company_General_Information_Max_Length";
    public const string CompanyGeneralInformationMinLength = "Company_General_Information_Min_Length";
    public const string CompanyContactInformationPhoneNumberNotEmpty = "Company_Contact_Information_Phone_Number_Not_Empty";
    public const string CompanyContactInformationEmailNotEmpty = "Company_Contact_Information_Email_Not_Empty";
    public const string CompanyContactInformationAddSuccess = "Company_Contact_Information_Add_Success";
    public const string CompanyContactInformationAddFail = "Company_Contact_Information_Add_Fail";
    public const string CompanyContactInformationUpdateSuccess = "Company_Contact_Information_Update_Success";
    public const string CompanyContactInformationUpdateFail = "Company_Contact_Information_Update_Fail";
    public const string CompanyContactInformationListedSuccess = "Company_Contact_Information_Listed_Success";
    public const string CompanyContactInformationFoundSuccess = "Company_Contact_Information_Found_Success";
    public const string CompanyContactInformationDeletedSuccess = "Company_Contact_Information_Deleted_Success";
    public const string CompanyContactInformationListedFail = "Company_Contact_Information_Listed_Fail";
    public const string CompanyContactInformationAlreadyExists = "Company_Contact_Information_Already_Exists";
    public const string CompanyContactInformationNotFound = "Company_Contact_Information_Not_Found";
    public const string ListHasNoCompanyContactInformations = "List_Has_No_Company_Contact_Informations";
    public const string CompanyContactInformationAddressNotEmpty = "Company_Contact_Information_Address_Not_Empty";
    public const string CompanyContactInformationAddressMaxLength = "Company_Contact_Information_Address_Max_Length";
    public const string CompanyContactInformationAddressMinLength = "Company_Contact_Information_Address_Min_Length";
    public const string CompanyContactInformationIdRequired = "Company_Contact_Information_Id_Required";



    //Authentication Mesajları
    public const string CreateTokenSuccess = "İşlem Başarılı";
    public const string RevokeTokenFail = "İşlem Başarısız";
    public const string RevokeTokenSuccess = "İşlem Başarılı";
    public const string CreateTokenFail = "Email veya Password Hatalı";
    public const string UserAddSuccess = "Kişi Başarıyla Sisteme Eklendi";
    public const string UserAddFail = "Kişinin Sisteme Eklenme İşlemi Başarısız";
    public const string UserNotFound = "Kullanıcı Bulunamadı";
    public const string GeneralSuccessMessage = "İşlem Başarılı";
    public const string UserDeletedSuccess = "Kullanıcı Silme Başarılı";
    public const string UserListedFail = "Kullanıcı Listeleme Başarısız";
    public const string UserAlreadyExists = "Kullanıcı Zaten Kayıtlı";
    public const string UserDeletedFail = "Kullanıcı Silme İşlemi Başarısız";
    public const string ListHasNoUser = "Listelenecek Kullanıcı Yok";
    public const string LoginWelcome = "Welcome";
    public const string UserEmailAlreadyExists = "Email Zaten Kayıtlı";


    //ContactPerson Mesajları

    public const string ContactPersonAddSuccess = "Contact_Person_Add_Success";
    public const string ContactPersonAddFail = "Contact_Person_Add_Fail ";
    public const string ContactPersonUpdateSuccess = "Contact_Person_Update_Success";
    public const string ContactPersonUpdateFail = "Contact_Person_Update_Fail";
    public const string ContactPersonListedSuccess = "Contact_Person_Listed_Success";
    public const string ContactPersonFoundSuccess = "Contact_Person_Found_Success";
    public const string ContactPersonDeletedSuccess = "Contact_Person_Deleted_Success";
    public const string ContactPersonListedFail = "Contact_Person_Listed_Fail";
    public const string ContactPersonAlreadyExists = "Contact_Person_Already_Exists";
    public const string ContactPersonNotFound = "Contact_Person_Not_Found";
    public const string ListHasNoContactPerson = "List_Has_No_Contact_Person";
    public const string ContactPersonNameNotEmmpty = "Contact_Person_Name_Not_Emmpty";
    public const string ContactPersonNameNotExceed256Letters = "Contact_Person_Name_Not_Exceed_256_Letters";
    public const string ContactPersonCompanyIdNotEmpty = "Contact_Person_Company_Id_Not_Empty";

    public const string ContactPersonEmailNotEmpty = "Contact_Person_Email_Not_Empty";
    public const string ContactPersonPhoneNumberNotEmpty = "Contact_Person_Phone_Number_Not_Empty";
    public const string ContactPersonPhoneNumberMinLength = "Contact_Person_Phone_Number_Min_Length";
    public const string ContactPersonDepartmentNotEmpty = "Contact_Person_Department_Not_Empty";
    public const string ContactPersonDepartmentNotExceed256Letters = "Contact_Person_Department_Not_Exceed_256_Letters";
    public const string ContactPersonPositionNotEmpty = "Contact_Person_Position_Not_Empty";
    public const string ContactPersonPositionNotExceed50Letters = "Contact_Person_Position_Not_Exceed_50_Letters";
    public const string ContactPersonIdIsRequiredForUpdate = "Contact_Person_Id_Is_Required_For_Update";
    public const string ContactPersonFullNameMinLength = "Contact_Person_Full_Name_Min_Length";
    public const string ContactPersonDepartmentMinLength = "Contact_Person_Department_Min_Length";
    public const string ContactPersonPositionMinLength = "Contact_Person_Position_Min_Length";



    // İş İlanı Mesajları
    public const string JobAddSuccess = "Job_Add_Success";
    public const string JobAddFail = "Job_Add_Fail";
    public const string JobUpdateSuccess = "Job_Update_Success";
    public const string JobUpdateFail = "Job_Update_Fail";
    public const string JobListedSuccess = "Job_Listed_Success";
    public const string JobFoundSuccess = "Job_Found_Success";
    public const string JobDeletedSuccess = "Job_Deleted_Success";
    public const string JobListedFail = "Job_Listed_Fail";
    public const string JobAlreadyExists = "Job_Already_Exists";
    public const string JobNotFound = "Job_Not_Found";
    public const string ListHasNoJobs = "List_Has_No_Jobs";

    public const string JobPositionNotEmpty = "Job_Position_Not_Empty";
    public const string JobPositionMustBeAtLeast2Characters = "Job_Position_Must_Be_At_Least_2_Characters";
    public const string JobPositionCanNotExceed100Characters = "Job_Position_Can_Not_Exceed_100_Characters";
    public const string JobDescriptionNotEmpty = "Job_Description_Not_Empty";
    public const string JobDescriptionMustBeAtLeast2Characters = "Job_Description_Must_Be_At_Least_2_Characters";
    public const string JobDescriptionCanNotExceed256Characters = "Job_Description_Can_Not_Exceed_256_Characters";
    public const string JobExperienceNotEmpty = "Job_Experience_Not_Empty";
    public const string JobExperienceMustBeAtLeast1Characters = "Job_Experience_Must_Be_At_Least_1_Characters";
    public const string JobExperienceCanNotExceed256Characters = "Job_Experience_Can_Not_Exceed_256_Characters";
    public const string JobExperienceFormat = "Job_Experience_Format";
    public const string JobEducationNotEmpty = "Job_Education_Not_Empty";
    public const string JobEducationMustBeAtLeast2Characters = "Job_Education_Must_Be_At_Least_2_Characters";
    public const string JobEducationCanNotExceed256Characters = "Job_Education_Can_Not_Exceed_256_Characters";
    public const string JobEducationFormat = "Job_Education_Format";
    public const string JobSalaryNotEmpty = "Job_Salary_Not_Empty";
    public const string JobSalaryGreaterThanZero = "Job_Salary_Greater_Than_Zero";
    public const string JobWorkLocationNotEmpty = "Job_Work_Location_Not_Empty";
    public const string JobStatusNotEmpty = "Job_Status_Not_Empty";
    public const string JobIdRequired = "Job_Id_Required";

    // İş Becerileri Mesajları
    public const string JobSkillAddSuccess = "İş Becerisi Başarıyla Oluşturuldu";
    public const string JobSkillAddFail = "İş Becerisi Oluşturma Başarısız";
    public const string JobSkillUpdateSuccess = "İş Becerisi Güncelleme Başarılı";
    public const string JobSkillUpdateFail = "İş Becerisi Güncelleme Başarısız";
    public const string JobSkillListedSuccess = "İş Becerileri Listeleme Başarılı";
    public const string JobSkillFoundSuccess = "İş Becerisi Görüntüleme Başarılı";
    public const string JobSkillDeletedSuccess = "İş Becerisi Silme Başarılı";
    public const string JobSkillListedFail = "İş Becerileri Listeleme Başarısız";
    public const string JobSkillAlreadyExists = "İş Becerisi Zaten Kayıtlı";
    public const string JobSkillNotFound = "İş Becerisi Bulunamadı";
    public const string ListHasNoJobSkills = "Listelenecek İş Becerisi Yok";
    public const string JobSkillIdRequired = "İş Beceri Id Boş Olamaz";

    // İş Avantajları Mesajları
    public const string JobBenefitAddSuccess = "İş Avantajı Başarıyla Oluşturuldu";
    public const string JobBenefitAddFail = "İş Avantajı Oluşturma Başarısız";
    public const string JobBenefitUpdateSuccess = "İş Avantajı Güncelleme Başarılı";
    public const string JobBenefitUpdateFail = "İş Avantajı Güncelleme Başarısız";
    public const string JobBenefitListedSuccess = "İş Avantajları Listeleme Başarılı";
    public const string JobBenefitFoundSuccess = "İş Avantajı Görüntüleme Başarılı";
    public const string JobBenefitDeletedSuccess = "İş Avantajı Silme Başarılı";
    public const string JobBenefitListedFail = "İş Avantajları Listeleme Başarısız";
    public const string JobBenefitAlreadyExists = "İş Avantajı Zaten Kayıtlı";
    public const string JobBenefitNotFound = "İş Avantajı Bulunamadı";
    public const string ListHasNoJobBenefits = "Listelenecek İş Avantajı Yok";
    public const string JobBenefitIdRequired = "İş Avantajı Id Boş Olamaz";
    //İlan-Aday Mesajları
    public const string JobCandidateAddSuccess = "İlan-Aday Başarıyla Oluşturuldu";
    public const string JobCandidateAddFail = "İlan-Aday Oluşturma Başarısız";
    public const string JobCandidateUpdateSuccess = "İlan-Aday Güncelleme Başarılı";
    public const string JobCandidateUpdateFail = "İlan-Aday Güncelleme Başarısız";
    public const string JobCandidateListedSuccess = "İlan-Aday Listeleme Başarılı";
    public const string JobCandidateFoundSuccess = "İlan-Aday Görüntüleme Başarılı";
    public const string JobCandidateDeletedSuccess = "İlan-Aday Silme Başarılı";
    public const string JobCandidateListedFail = "İlan-Aday Listeleme Başarısız";
    public const string JobCandidateAlreadyExists = "İlan-Aday Zaten Kayıtlı";
    public const string JobCandidateNotFound = "İlan-Aday Bulunamadı";
    public const string ListHasNoJobCandidates = "Listelenecek Adayın İlanı Yok";

    public const string BenefitAlreadyExists = "Benefit already exists.";
    public const string BenefitAddSuccess = "Benefit added successfully.";
    public const string BenefitNotFound = "Benefit not found.";
    public const string BenefitDeletedSuccess = "Benefit deleted successfully.";
    public const string ListHasNoBenefits = "No benefits found in the list.";
    public const string BenefitListedSuccess = "Benefits listed successfully.";
    public const string BenefitFoundSuccess = "Benefit found successfully.";
    public const string BenefitUpdateSuccess = "Benefit updated successfully.";
    public const string BenefitNameNotEmpty = "Benefit name cannot be empty.";
    public const string BenefitIdRequired = "Benefit ID is required.";



    // Beceri Mesajları
    public const string SkillAddSuccess = "Skill_Add_Success";
    public const string SkillAddFail = "Skill_Add_Fail";
    public const string SkillUpdateSuccess = "Skill_Update_Success";
    public const string SkillUpdateFail = "Skill_Update_Fail";
    public const string SkillListedSuccess = "Skill_Listed_Success";
    public const string SkillFoundSuccess = "Skill_Found_Success";
    public const string SkillDeletedSuccess = "Skill_Deleted_Success";
    public const string SkillListedFail = "Skill_Listed_Fail";
    public const string SkillAlreadyExists = "Skill_Already_Exists";
    public const string SkillNotFound = "Skill_Not_Found";
    public const string ListHasNoSkills = "List_Has_No_Skills";
    public const string SkillNameNotEmpty = "Skill_Name_Not_Empty";
    public const string SkillIdRequired = "Skill_Id_Required";

    public const string PhoneNumberMustBe11Digit = "Phone_Number_Must_Be_11_Digit";
    public const string PhoneNumberMustBeStartingWith0 = "Phone_Number_Must_Be_Starting_With_0";

    //Employee Mesajları
    public const string EmployeeAddSuccess = "Employee_Add_Success";
    public const string EmployeeAddFail = "Employee_Add_Fail";
    public const string EmployeeUpdateSuccess = "Employee_Update_Success";
    public const string EmployeeUpdateFail = "Employee_Update_Fail";
    public const string EmployeeListedSuccess = "Employee_Listed_Success";
    public const string EmployeeFoundSuccess = "Employee_Found_Success";
    public const string EmployeeDeletedSuccess = "Employee_Deleted_Success";
    public const string EmployeeListedFail = "Employee_Listed_Fail";
    public const string EmployeeAlreadyExists = "Employee_Already_Exists";
    public const string EmployeeNotFound = "Employee_Not_Found";
    public const string ListHasNoEmployees = "List_Has_No_Employees";
    public const string EmployeeFirstNameNotEmpty = "Employee_Name_Not_Empty";
    public const string EmployeFirstNameCanBeUpTo30Characters = "Employe_Name_Can_Be_Up_To_30_Characters";
    public const string EmployeFirstNameCanOnlyContainLetters = "Employee_Name_Can_Only_Contain_Letters";
    public const string EmployeeLastNameNotEmpty = "Employee_Surname_Not_Empty";
    public const string EmployeeLastNameCanBeUpTo30Characters = "Employee_Surname_Can_Be_Up_To_30_Characters";
    public const string EmployeLastNameCanOnlyContainLetters = "Employee_Surname_Can_Only_Contain_Letters";
    public const string EmployeeEmailNotEmpty = "Employee_Email_Not_Empty";
    public const string EmployeeEmailMustBeCorrectFormat = "Employee_Email_Must_Be_Correct_Format";
    public const string EmployeePhoneNumberMustBe11DigitsandStartingWith0 = "Employee_Phone_Number_Must_Be_11_Digits_and_Starting_With_0";
    public const string EmployeePhoneNumberCanOnlyContainNumber = "Employee_PhoneNumber_Can_Only_Contain_Number";
    public const string EmployeeGenderMustBeSelected = "Employee_Gender_Must_Be_Selected";
    public const string EmployeePleaseSelectValidGender = "Employee_Please_Select_Valid_Gender";
    public const string DateOfBirthOfEmployeeCannotBeEmpty = "DateOfBirth_Of_Employee_Cannot_Be_Empty";
    public const string DateofBirthofEmployeeMustEnterValid = "DateOfBirth_Of_Employee_Must_Enter_Valid";
    public const string AddressOfEmployeeMustContainAtLeast2Characters = "Address_Of_Employee_Must_Contain_At_Least_2_Characters";
    public const string AddressOfEmployeeCanBeUpTo200Characters = "Address_Of_Employee_Can_Be_Up_To_200_Characters";
    public const string EmployeeLastNameMustContainAtLeast2Characters = "Employee_LastName_Must_Contain_At_Least_2_Characters";
    public const string EmployeeFirstNameMustContainAtLeast2Characters = "Employee_FirstName_Must_Contain_At_Least_2_Characters";
    public const string EmployeeIdRequired = "EmployeeIdRequired";


    //Sertifika için validasyon mesajları
    public const string CertificateNameCannotBeEmpty = "Certificate_Name_Cannot_Be_Empty";
    public const string CertificateNameCannotExceed256Letters = "Certificate_Name_Cannot_Exceed_256_Letters";
    public const string CertificateNameCannotBeLessThan2Letters = "Certificate_Name_Cannot_Be_Less_Than_2_Letters";
    public const string CertificateNameCanContainLettersAndNumbers = "Certificate_Name_Can_Contain_Letters_And_Numbers";
    public const string CertificateDateCannotBeEmpty = "Certificate_Date_Cannot_Be_Empty";
    public const string CertificateDescriptionCannotBeEmpty = "Certificate_Description_Cannot_Be_Empty";
    public const string CertificateDescriptionCannotExceed256Letters = "Certificate_Description_Cannot_Exceed_256_Letters";
    public const string CertificateDescriptionCannotBeLessThan2Letters = "Certificate_Description_Cannot_Be_Less_Than_2_Letters";
    public const string CertificateDescriptionCanContainLettersAndNumbers = "Certificate_Description_Can_Contain_Letters_And_Numbers";
    public const string CertificateAchievementStatusCannotBeEmpty = "Certificate_Achievement_Status_Cannot_Be_Empty";


    //Başvuru Mesajları

    public const string ApplicationAddSuccess = "Application_Add_Success";
    public const string ApplicationAddFail = "Application_Add_Fail";
    public const string ApplicationUpdateSuccess = "Application_Update_Success";
    public const string ApplicationUpdateFail = "Application_Update_Fail";
    public const string ApplicationListedSuccess = "Application_Listed_Success";
    public const string ApplicationFoundSuccess = "Application_Found_Success";
    public const string ApplicationDeletedSuccess = "Application_Deleted_Success";
    public const string ApplicationListedFail = "Application_Listed_Fail";
    public const string ApplicationAlreadyExists = "Application_Already_Exists";
    public const string ApplicationNotFound = "Application_Not_Found";
    public const string ListHasNoApplications = "List_Has_No_Applications";

    public const string ApplicationDateRequired = "Application_Date_Required";
    public const string ApplicationDateWithinYear = "Application_Date_Within_Year";
    public const string ApplicationStatusForRequired = "Application_Status_For_Required";
    public const string ApplicationDescriptionMaxLength = "Application_Description_Max_Length";
    public const string ApplicationIdRequired = "Application_Id_Required";


    //MailService mesajları
    public const string MailSendSuccess = "Mail_Send_Success";
    public const string MailSendFail = "Mail_Send_Fail";
    public const string MailSendCompleted = "Mail_Send_Completed";


}


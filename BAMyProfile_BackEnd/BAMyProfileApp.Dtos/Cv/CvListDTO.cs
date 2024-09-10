using BAMyProfileApp.Dtos.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Cv;

public class CvListDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Profile { get; set; }
    public Guid StudentId { get; set; }
    public string FullName { get; set; }
    public List<string>? StudentCertificateNames { get; set; }
    public List<string>? EventStudentNames { get; set; }
    public List<string>? ReferenceStudentNames { get; set; }
    public List<string>? StudentTrainingProgramNames { get; set; }
    public List<string>? StudentLanguageNames { get; set; }
    public List<string>? CapabilityStudentNames { get; set; }
    public List<string>? InterviewNames { get; set; }
    public List<string>? ExperienceNames { get; set; }
}

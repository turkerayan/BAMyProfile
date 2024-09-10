﻿using BAMyProfileApp.Entities.Enums;

namespace BAMyProfileApp.Dtos.Job;

public class JobCreateDTO
{
    public string Position { get; set; }
    public string Description { get; set; }
    public string Experience { get; set; }
    public string Education { get; set; }
    public decimal Salary { get; set; }
    public Remote WorkLocation { get; set; }
    public JobStatus JobStatus { get; set; }
    public Guid CompanyId { get; set; }

}
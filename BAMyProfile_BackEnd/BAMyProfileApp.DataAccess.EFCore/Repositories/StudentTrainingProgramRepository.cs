﻿using BAMyProfileApp.Core.DataAccess.EntityFramework;
using BAMyProfileApp.DataAccess.Contexts;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.DataAccess.EFCore.Repositories;

public class StudentTrainingProgramRepository : EFBaseRepository<StudentTrainingProgram>, IStudentTrainingProgramRepository
{
    public StudentTrainingProgramRepository(BAMyProfileAppDbContext context) : base(context)
    {

    }
}


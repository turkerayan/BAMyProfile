﻿using BAMyProfileApp.Core.DataAccess.Interfaces;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.DataAccess.Interfaces.Repositories;

public interface IDepartmentRepository :
    IAsyncFindableRepository<Department>,
    IAsyncInsertableRepository<Department>,
    IAsyncUpdateableRepository<Department>,
    IAsyncDeleteableRepository<Department>
{

}
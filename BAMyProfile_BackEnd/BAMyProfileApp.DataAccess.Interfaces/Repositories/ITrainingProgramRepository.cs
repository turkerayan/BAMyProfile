using BAMyProfileApp.Core.DataAccess.Interfaces;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.DataAccess.Interfaces.Repositories;

public interface ITrainingProgramRepository : IAsyncFindableRepository<TrainingProgram>, IAsyncInsertableRepository<TrainingProgram>, IAsyncRepository, IAsyncUpdateableRepository<TrainingProgram>, IAsyncDeleteableRepository<TrainingProgram>
{

}

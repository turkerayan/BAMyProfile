using BAMyProfileApp.Core.DataAccess.Interfaces;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.DataAccess.Interfaces.Repositories;

public interface IJobSkillRepository :
    IAsyncFindableRepository<JobSkill>,
    IAsyncInsertableRepository<JobSkill>,
    IAsyncUpdateableRepository<JobSkill>,
    IAsyncDeleteableRepository<JobSkill>
{

}

using BAMyProfileApp.Core.DataAccess.Interfaces;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.DataAccess.Interfaces.Repositories;

public interface ISkillRepository :
    IAsyncFindableRepository<Skill>,
    IAsyncInsertableRepository<Skill>,
    IAsyncUpdateableRepository<Skill>,
    IAsyncDeleteableRepository<Skill>

{
}

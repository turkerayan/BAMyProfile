using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.References;
using BAMyProfileApp.Entities.DbSets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces
{
   
    public interface IReferenceService
    {     
        Task<IResult> CreateAsync(ReferenceCreateDTO referenceCreateDTO);
        Task<IResult> DeleteAsync(Guid id);
        Task<IResult> UpdateAsync(ReferenceUpdateDTO referenceUpdateDTO);
        Task<IResult> GetAllAsync();
        Task<IResult> GetByIdAsync(Guid id);
    }
}

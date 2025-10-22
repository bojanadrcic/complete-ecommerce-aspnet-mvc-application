using eTourist.Data.Base;
using eTourist.Models;

namespace eTourist.Data.Services
{
    public interface IArrangementsService: IEntityBaseRepository<Arrangement>
    {
        Task<Arrangement> GetArrangementByIdAsync(int id);
    }
}

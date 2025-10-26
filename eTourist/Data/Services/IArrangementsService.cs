using eTourist.Data.Base;
using eTourist.Data.ViewModels;
using eTourist.Models;

namespace eTourist.Data.Services
{
    public interface IArrangementsService: IEntityBaseRepository<Arrangement>
    {
        Task<Arrangement> GetArrangementByIdAsync(int id);
        Task<NewArrangementDropdownsVM> GetNewArrangementDropdownsValues();
        Task AddNewArrangementAsync(NewArrangementVM data);
        Task UpdateArrangementAsync(NewArrangementVM data);

    }
}

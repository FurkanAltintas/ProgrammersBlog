using ProgrammersBlog.Entities.Dtos.CategoryDtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAll();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeleted(); // silinmemiş olan tüm kategoriler
        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive(); // hem silinmemiş hem de aktif olanları listele
        Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdByName);
        Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IResult> Delete(int categoryId, string modifiedByName); // IsDeleted = true
        Task<IResult> HardDelete(int categoryId); // İçeriği veritabanından siler
    }
}

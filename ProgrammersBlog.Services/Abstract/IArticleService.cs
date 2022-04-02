using ProgrammersBlog.Entities.Dtos.ArticleDtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> Get(int articleId);
        Task<IDataResult<ArticleListDto>> GetAll();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeleted(); // silinmemiş olan tüm kategoriler
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive(); // silinmemiş ve aktif olan tüm kategoriler
        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId); // kategoriye göre makaleleri getir
        Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName); // ekleme
        Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName); // güncelleme
        Task<IResult> Delete(int articleId, string modifiedByName); // IsDeleted = true
        Task<IResult> HardDelete(int articleId); // İçeriği veritabanından siler
    }
}

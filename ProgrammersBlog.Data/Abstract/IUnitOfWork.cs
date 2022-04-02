using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IArticleRepository Articles { get; }
        public ICategoryRepository Categories { get; }
        public ICommentRepository Comments { get; }
        public IRoleRepository Roles { get; }
        public IUserRepository Users { get; } // _unitOfWork.Categories.AddAsync(category);

        /* _unitOfWork.Categories.AdAsync(category);
         * _unitOfWork.Users.AddAsync(user);
         * _unitOfWork.SaveAsync();
         * Bu süreçte eğer bir tanesi hataya düşerse exception vereceği için
         * burada bir saveAsync a hiç ulaşamıyor olacağız ve veriler veritabanına 
         * eksik bir şekilde kaydedilmemiş olacak
         */

        Task<int> SaveAsync();

        /* Etkilenen kayıt sayısı için int olarak belirtiyoruz */
    }
}

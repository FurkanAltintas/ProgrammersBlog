using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Article : EntityBase, IEntity
    {
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public DateTime Date { get; set; }
        public int ViewsCount { get; set; } = 0; // Okunma Sayısı
        public int CommentCount { get; set; } = 0; // Yorum Sayısı
        public string SeoAuthor { get; set; } // Makaleyi yazan meta taglerini ekleyeceğimiz yer
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; } // etiketlerimiz

        /*************************************/

        public Category Category { get; set; } // Bir makalenin sadece bir kategorisi olabilir

        public User User { get; set; } // Bir makalenin sadece bir kullanıcısı olabilir

        public ICollection<Comment> Comments { get; set; } // Bir makale birden fazla yoruma sahip olabilir
    }
}

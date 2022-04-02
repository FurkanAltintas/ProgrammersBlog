﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id); // primary key alanı var mı ? Id alanını primary key olarak yapmış olduk
            builder.Property(a => a.Id).ValueGeneratedOnAdd(); // identity alanı. Eklendikçe buraya bir değer oluştur
            builder.Property(a => a.Title).HasMaxLength(100); // Maksimum uzunluğu var mı ? Varsa belirtmemiz gerekiyor
            // 100 karakterden uzun olduğunda sql hata vericek
            builder.Property(a => a.Title).IsRequired(true); // default ayarı true olarak belirtilir biz yine de belirtelim
            // Title 2 kere oluşturdum tek sırayla da yapabilirdim ama karışıklık olmasın diye tek yerde tutmak istedim
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)"); // content alanımızda çok fazla içerik girebiliriz o yüzden böyle bir şey yaptım
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(50); // yazarın ismi maksimum 50 karakter olarak belirttik
            builder.Property(a => a.SeoDescription).HasMaxLength(150);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70);
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.ViewsCount).IsRequired(); // hiç okunmadı ise bile 0 yazması lazım
            builder.Property(a => a.CommentCount).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired(); // dosya yolu olarak tutuyoruz
            builder.Property(a => a.Thumbnail).HasMaxLength(250);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500); // boş bırakılabilir

            /********************************************************************/

            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId); // bir kategori birden falza makaleye sahip olabilir. Buradaki Generic kısmı vermeyebilirdik çünkü ilk kısımda seçiyorduk ama bu okunurluğu arttırdığı için ben ekledim
            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId); // bir kullanıcının birden fazla içeriğe sahip olabilir.

            /* Bir kullanıcı ve bir kategori birden fazla makaleye sahip olabilir */

            builder.ToTable("Articles"); // Tablo olarak hangi ismi almalı

            builder.HasData(
                new Article()
                {
                    Id = 1,
                    UserId = 1,
                    CategoryId = 1,
                    Title = "C# 9.0 ve .NET 5 Yenilikleri",
                    Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "C# 9.0 ve .NET 5 Yenilikleri",
                    SeoTags = "C#, C# 9, .NET5, .NET Framework, .NET Core",
                    SeoAuthor = "Furkan Altıntaş",
                    Date = DateTime.Now,
                    CommentCount = 1,
                    ViewsCount = 100,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C# 9.0 ve .NET 5 Yenilikleri"
                },
                new Article()
                {
                    Id = 2,
                    UserId = 1,
                    CategoryId = 2,
                    Title = "C++ 11 ve 19 Yenilikleri",
                    Content = "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "C++ 11 ve 19 Yenilikleri",
                    SeoTags = "C++ 11 ve 19 Yenilikleri",
                    SeoAuthor = "Furkan Altıntaş",
                    Date = DateTime.Now,
                    CommentCount = 1,
                    ViewsCount = 295,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C++ 11 ve 19 Yenilikleri"
                },
                new Article()
                {
                    Id = 3,
                    UserId = 1,
                    CategoryId = 3,
                    Title = "JavaScript ES2019 ve ES2020 Yenilikleri",
                    Content = "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "JavaScript ES2019 ve ES2020 Yenilikleri",
                    SeoTags = "JavaScript ES2019 ve ES2020 Yenilikleri",
                    SeoAuthor = "Furkan Altıntaş",
                    Date = DateTime.Now,
                    CommentCount = 1,
                    ViewsCount = 12,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "JavaScript ES2019 ve ES2020 Yenilikleri"
                }); // Fluent Api kullandığımız için değerler null olsa bile eklemek zorundayız
        }
    }
}
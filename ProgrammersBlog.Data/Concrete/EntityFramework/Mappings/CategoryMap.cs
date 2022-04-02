using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id); // Id alanımızı primary key yaptık
            builder.Property(c => c.Id).ValueGeneratedOnAdd(); // identity olarak 1, 1 artmasını sağlıyoruz
            builder.Property(c => c.Name).IsRequired(); // Null olamaz
            builder.Property(c => c.Name).HasMaxLength(70);
            builder.Property(c => c.Description).HasMaxLength(500); // Null olabilir
            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(500); // boş bırakılabilir

            // Kategori ile çalıştığımız için c ile çağırıyoruz ve böylece daha düzgün, daha okunaklı kod yazmış oluyoruzz

            builder.ToTable("Categories");

            /* 
             * Bu sınıf herhangi bir id barındırmadığı için ilişkileri yapmamıza gerek yok.
             * Bu ilişkileri  Fluent Api ile üzerinde nerede biz dışarıdan bir id alıyorsak orada yapıyoruz.
               Örnek: Article kısmında 2 tane Id kısmı bulunmaktadır ama Category kısmında bir id alanı yoktur.*/

            builder.HasData(
                new Category()
                {
                    Id = 1,
                    Name = "C#",
                    Description = "C# Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C# Blog Kategorisi"
                },
                new Category()
                {
                    Id = 2,
                    Name = "C++",
                    Description = "C++ Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C++ Blog Kategorisi"
                },
                new Category()
                {
                    Id = 3,
                    Name = "JavaScript",
                    Description = "JavaScript Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "JavaScript Blog Kategorisi"
                });
        }
    }
}

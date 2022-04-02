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
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        // Bu sınıfımızın erişim belirleyicisi public olmalı. DbContext kısmında kullanabilmemiz için.
        // Konfigurasyonlarını yapabilmemiz için IEntityTypeConfiguration interfacinden implement olmalı.
        // Bunu da rol sınıfıyla implement etmemiz gerekiyor.
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id); // Id alanını primary key olarak belirttik
            builder.Property(r => r.Id).ValueGeneratedOnAdd(); // Id alanının bir bir artmasını sağladık
            builder.Property(r => r.Name).IsRequired(); // Bu alanı zorunlu yaptık
            builder.Property(r => r.Name).HasMaxLength(30);
            builder.Property(r => r.Description).IsRequired();
            builder.Property(r => r.Description).HasMaxLength(250);
            builder.Property(r => r.CreatedByName).IsRequired();
            builder.Property(r => r.CreatedByName).HasMaxLength(50);
            builder.Property(r => r.ModifiedByName).IsRequired();
            builder.Property(r => r.ModifiedByName).HasMaxLength(50);
            builder.Property(r => r.CreatedDate).IsRequired();
            builder.Property(r => r.ModifiedByName).IsRequired();
            builder.Property(r => r.IsActive).IsRequired();
            builder.Property(r => r.IsDeleted).IsRequired();
            builder.Property(r => r.Note).HasMaxLength(500); // boş bırakılabilir

            builder.ToTable("Roles");

            builder.HasData(new Role()
            {
                Id = 1,
                Name = "Admin",
                Description = "Admin Rolü, Tüm Haklara Sahiptir",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate", // ilk oluşturma işlemi
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Admin  Rolüdür"
            }); // veritabanı tam oluşurken ki olduğu için tüm kolonları doldurmamız lazım

            // veritabanında böyle bir veri var mı ? veri yok ise parantezler içerisinde ekliyor olacağız
        }
    }
}

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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id); // primary key alanını belirttik
            builder.Property(u => u.Id).ValueGeneratedOnAdd(); // identity alanını sağladık
            builder.Property(u => u.Email).IsRequired(); // boş bırakılamaz
            builder.Property(u => u.Email).HasMaxLength(50); // 50 karakter olarak sağladık
            /* Email alanı Unique bir alan olmalı. Yani veritabanında bir emailden bir tane daha olamaz
             * Başka bir kullanıcı da o email ile kayıt olamaz*/
            builder.HasIndex(u => u.Email).IsUnique(); // bir indexi var mı ? Varsa seç
            /* IsUnique => Burası unique mi ? Email alanını unique olarak belirttik böylece 
             bu emailden bir kere kayıt olunabilir, ikinci kere kayıt olunamaz */
            builder.Property(u => u.UserName).IsRequired();
            builder.Property(u => u.UserName).HasMaxLength(20);
            builder.HasIndex(u => u.UserName).IsUnique(); // özel ad
            builder.Property(u => u.PasswordHash).IsRequired(); // bir kolon tipi de vermemiz gerekiyor
            builder.Property(u => u.PasswordHash).HasColumnType("VARBINARY(500)"); // mdf olarak vericez ama ileride değişir diye böyle ayarlıyoruz
            builder.Property(u => u.Description).HasMaxLength(500);
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(30);
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(30);
            builder.Property(u => u.Picture).IsRequired();
            builder.Property(u => u.Picture).HasMaxLength(250);
            builder.Property(u => u.CreatedByName).IsRequired();
            builder.Property(u => u.CreatedByName).HasMaxLength(50);
            builder.Property(u => u.ModifiedByName).IsRequired();
            builder.Property(u => u.ModifiedByName).HasMaxLength(50);
            builder.Property(u => u.CreatedDate).IsRequired();
            builder.Property(u => u.ModifiedByName).IsRequired();
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.IsDeleted).IsRequired();
            builder.Property(u => u.Note).HasMaxLength(500); // boş bırakılabilir

            /**************************************************/

            builder.HasOne<Role>(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
            // u - r - u
            // entity - foreignKey - entity
            // Bir rolün birden fazla kullanıcısı olabilir
            // Neye ihtiyacımız var ? Role
            // Bir rol birden fazla kullanıcıda olabilir mi ? Evet
            // ForeignKey kısmı ? RoleId

            builder.ToTable("Users"); // Tablomuza Users olarak ayarladık. Bu tablomuzun veritabanında karşılığı Users olucak.

            builder.HasData(new User()
            {
                Id = 1,
                RoleId = 1, // Rolü  Admin
                FirstName = "Furkan",
                LastName = "Altıntaş",
                UserName = "furkanaltintas",
                Email = "furkanaltintas785@gmail.com",
                Picture = "Picture: https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU",
                Description = "İlk Admin Kullanıcı",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Admin Kullanıcısı",
                PasswordHash = Encoding.ASCII.GetBytes("0192023a7bbd73250516f069df18b500")
            });
        }
    }
}

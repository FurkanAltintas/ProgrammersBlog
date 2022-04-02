using Microsoft.Extensions.DependencyInjection;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /* Extensions sınıf ve metodlarımızı kullanabilmek ve bu yapıyı kurabilmek için sınıflarımızı ve metodlarımızı static yapıyoruz. */

        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ProgrammersBlogContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();


            return serviceCollection;


            // Biri senden IUnitOfWork isterse sen ona UnitOfWork'ü ver
            /* Neden Scoped olarak ekledik ?
             * Çünkü DbContext de özünde scopedır.
             * 
             Peki Scope Nedir?
             * Siz bir istekte bulunduğunuz ve işlemlere başladığınız zaman bu işlemlerin bütünü bir scope içerisine alınır ve orada yürütülür. Ve sizin tüm işlemleriniz bittikten sonra da scope kendisini kapatır.*/

            /* SCOPED
             * Yapılan her request'te nesne tekrar oluşur ve bir request içerisinde sadece bir tane nesne kullanulır.
             
               Transient ve Scoped kullanım şekilleri nesne oluşturma zamanları açısından biraz karıştırılabilir.
               Transient'da her nesne çağrımında yeni bir instance oluşturulurken, Scoped'da ise request esnasında yeni bir instance oluşur ve o request sonlanana kadar aynı nesne kullanılır. Request bazında staleless nesne kullanılması istenen durumlarda Scoped bağımlılıkları oluşturabiliriz.
            */
        }
    }
}

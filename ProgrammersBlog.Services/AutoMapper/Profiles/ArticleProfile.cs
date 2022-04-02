using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos.ArticleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleAddDto, Article>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            //  Sen ArticleAddDto'yu Article dönüştürürken CreatedDate ekle
            /* Artık ArticleAddDto içerisinde bu alan olmasa bile Article içerisinde bu değerimizi gördüğü zaman
               hemen burada bizim verdiğimiz ayar dosyasını kullanarak yani aslında buradaki metodu kullanarak oraya CreatedDate alanını eklemiş oluyor*/
            CreateMap<ArticleUpdateDto, Article>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            //  ArticleUpdateDto al onu Article'a dönüştür.

            /* Source: Kaynak, Destination: Gidilecek Yer */
        }
    }
}

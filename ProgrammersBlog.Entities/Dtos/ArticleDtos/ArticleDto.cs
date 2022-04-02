using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.Entities.Dtos.ArticleDtos
{
    public class ArticleDto : DtoGetBase
    {
        public Article Article { get; set; }
        // public override ResultStatus ResultStatus { get; set} = ResultStatus.Success; // örnek kullanım
    }
}

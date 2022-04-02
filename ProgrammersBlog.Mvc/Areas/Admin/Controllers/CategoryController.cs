using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAll();
            /* GetAll metodunu çalıştırdık bu da bizlere bir DataResult dönecekti.
             * Bizler bu DataResult'ı, result isimli değişkenin içerisine attık.
               Daha sonra bu değişken içerisinde bulunan ResultStatus değerimizi kontrol ettik
               Eğer buradaki değerimiz Success ise DataResult içerisindeki verimizi view içerisine dönmüş olduk.*/

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }

            return View();
        }
    }
}

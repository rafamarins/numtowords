using System.Web.Mvc;
using NumToWord.Application;

namespace NumToWord.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The _word service
        /// </summary>
        private static WordService _wordService = new WordService();

        //
        // GET: /Home/
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        //
        //POST: /Home/
        /// <summary>
        /// Indexes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(Domain.Word input)
        {
            Domain.Word output= _wordService.Convert(input);

            return Json(output.Number);
        }
    }
}

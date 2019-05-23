using ITDevProjekt.Data.Interfaces;
using ITDevProjekt.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITDevProjekt.Controllers
{
    public class SearchController : Controller
    {
        private readonly ITranslationsRepository _translateRepositoty;

        public SearchController(ITranslationsRepository translateRepositoty)
        {
            _translateRepositoty = translateRepositoty;
        }

        [Route("Search")]
        public IActionResult List()
        {
            var translationsVM = new List<TranslateViewModel>();
            var translations = _translateRepositoty.GetAll();

            foreach (var translation in translations)
            {
                translationsVM.Add(new TranslateViewModel
                {
                    Translations = translation
                });
            }
            return View(translationsVM);
        }
    }
}

using ITDevProjekt.Data.Interfaces;
using ITDevProjekt.Data.Models;
using ITDevProjekt.Data.Repositories;
using ITDevProjekt.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ITDevProjekt.Controllers
{
    public class TranslateController : Controller
    {
        private readonly ILangsRepository _langsRepository;
        private readonly ITranslationsRepository _translateRepository;

        public TranslateController(ILangsRepository langsRepositoty, ITranslationsRepository translateRepositoty)
        {
            _langsRepository = langsRepositoty;
            _translateRepository = translateRepositoty;
        }

        [Route("Translate")]
        public IActionResult List()
        {
            var langsVM = new List<LangsViewModel>();
            var langs = _langsRepository.GetAll();

            if(langs.Count() == 0)
            {
                return View("Empty");
            }

            foreach(var lang in langs)
            {
                langsVM.Add(new LangsViewModel
                {
                    Langs = lang
                });
            }
            return View(langsVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Translations translate)
        {
            _translateRepository.Create(translate);
            return View();
        }
    }
}

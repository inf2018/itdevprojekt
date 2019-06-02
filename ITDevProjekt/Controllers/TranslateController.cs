using ITDevProjekt.Data.Interfaces;
using ITDevProjekt.Data.Models;
using ITDevProjekt.Data.Repositories;
using ITDevProjekt.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

            if (langs.Count() == 0)
            {
                return View("Empty");
            }

            foreach (var lang in langs)
            {
                langsVM.Add(new LangsViewModel
                {
                    Langs = lang
                });
            }
            return View(langsVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Translations translate, string TextToken, string LangSource, string LangTranslate)
        {
            var _token = TextToken;
            var _langTo = LangTranslate;
            var _langFrom = LangSource;
            var trans = _translateRepository.GetAllWithToken(_token);
            if(trans == null)
            {
                Save(translate);
            } 
            else
            {
                var existTranslateSource = trans.Where(x => x.LangSource == _langFrom).Any();

                if(existTranslateSource)
                {
                    var existTranslate = trans.Where(x => x.LangTranslate == _langTo).Any();

                    if (!existTranslate)
                    {
                        Save(translate);
                    }
                }
                else
                {
                    Save(translate);
                }
            }
                
            return View();
        }

        private void Save(Translations translate)
        {
            _translateRepository.Create(translate);
        }
    }
}

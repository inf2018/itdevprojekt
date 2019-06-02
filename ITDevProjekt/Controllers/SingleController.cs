using ITDevProjekt.Data.Interfaces;
using ITDevProjekt.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITDevProjekt.Controllers
{
    public class SingleController : Controller
    {
        private readonly ILangsRepository _langsRepository;
        private readonly ITranslationsRepository _translateRepository;

        public SingleController(ILangsRepository langsRepositoty, ITranslationsRepository translateRepositoty)
        {
            _langsRepository = langsRepositoty;
            _translateRepository = translateRepositoty;
        }

        [Route("Single")]
        public IActionResult Single(int id)
        {
            var langsVM = new List<LangsViewModel>();
            var transVM = new List<TranslateViewModel>();
            var trans = _translateRepository.GetById(id);
            var langs = _langsRepository.GetAll();

            foreach (var lang in langs)
            {
                langsVM.Add(new LangsViewModel
                {
                    Langs = lang
                });
            }

            foreach (var tran in trans)
            {
                transVM.Add(new TranslateViewModel
                {
                    Translations = tran
                });
            }
            return View();
        }
    }
}

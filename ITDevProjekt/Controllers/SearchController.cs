using ITDevProjekt.Data.Interfaces;
using ITDevProjekt.Models;
using ITDevProjekt.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public IActionResult Index()
        {
            var model = new TranlateWrapViewModel()
            {
                List = new List<TranslateViewModel>()
            };
            return View(model);
        }
        //[Route("Search")]
        //public IActionResult Index()
        //{
        //    var translationsVM = new List<TranslateViewModel>();
        //    var translations = _translateRepositoty.GetAll();

        //    foreach (var translation in translations)
        //    {
        //        translationsVM.Add(new TranslateViewModel
        //        {
        //            Translations = translation
        //        });
        //    }
        //    return View(translationsVM);
        //    //return View();
        //}

        [HttpGet]
        public ActionResult SearchResult()
        {
            return View();
        }

      [HttpPost]
        public IActionResult Index(TranlateWrapViewModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Token))
            {
                model = new TranlateWrapViewModel()
                {
                    List = new List<TranslateViewModel>()
                };
                return View(model);
            }

            var _token = model.Token;
            var translationsVM = new List<TranslateViewModel>();
            //var translations = _translateRepositoty.GetAll();
            var translations = _translateRepositoty.GetWithToken(_token);
            foreach (var translation in translations)
            {
                if (translation.TextToken.Contains(_token))
                {
                    translationsVM.Add(new TranslateViewModel
                    {
                        Translations = translation
                    });
                }
            }
            model.List = translationsVM;
            return View(model);
        }

        [HttpPost]
        public IActionResult SearchResult(string token)
        {
            //var _token = token;
            //var translationsVM = new List<TranslateViewModel>();
            ////var translations = _translateRepositoty.GetAll();
            //var translations = _translateRepositoty.GetWithToken(_token);
            //foreach (var translation in translations)
            //{
            //    if (translation.TextToken.Contains(_token))
            //    {
            //        translationsVM.Add(new TranslateViewModel
            //        {
            //            Translations = translation
            //        });
            //    }
            //}
            //return View("Index", translationsVM);
            return RedirectToAction("Index", new { token1 = token });
        }
    }
}

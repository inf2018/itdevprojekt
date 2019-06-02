using ITDevProjekt.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITDevProjekt.Models
{
    public class TranlateWrapViewModel
    {
        public string Token { get; set; }
        public List<TranslateViewModel> List { get; set; }
    }
}

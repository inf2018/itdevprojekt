using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITDevProjekt.Models
{
    public class SelectData
    {
        public string lang_source { get; set; }
        public string lang_translate { get; set; }
        public string text_before { get; set; }
        public string text_after { get; set; }
        public string text_token { get; set; }

        public List<SelectData> selectDatas { get; set; }
    }
}

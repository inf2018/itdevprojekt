using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITDevProjekt.Models
{
    public class Language
    {
        [Key]
        public int L_id { get; set; }

        [Required]
        public String lang_attr { get; set; }

        [Required]
        public String lang_name { get; set; }

        public List<Language> languages { get; set; }
    }

    //class Translations
    //{
    //    [Required]
    //    public int T_id { get; set; }

    //    [Required]
    //    public String lang_source { get; set; }

    //    [Required]
    //    public String lang_translate { get; set; }

    //    [Required]
    //    public String text_before { get; set; }

    //    [Required]
    //    public String text_after { get; set; }

    //    [Required]
    //    public String text_token { get; set; }
    //}
}

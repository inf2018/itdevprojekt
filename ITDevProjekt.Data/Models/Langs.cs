using System;
using System.ComponentModel.DataAnnotations;

namespace ITDevProjekt.Data.Models
{
    public class Langs
    {
        [Key]
        public int Id { get; set; }

        public string LangAttr { get; set; }

        public string LangName { get; set; }

        public static implicit operator Langs(Translations v)
        {
            throw new NotImplementedException();
        }
    }

}

using System.ComponentModel.DataAnnotations;

namespace ITDevProjekt.Data.Models
{
    public class Translations
    {
        [Key]
        public int Id { get; set; }

        public string LangSource { get; set; }

        public string LangTranslate { get; set; }

        public string TextBefore { get; set; }

        public string TextAfter { get; set; }

        public string TextToken { get; set; }
    }
}

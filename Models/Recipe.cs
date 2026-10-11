namespace Przepisy.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Nazwa { get; set; } = "";
        public string Kategoria { get; set; } = "";
        public int CzasPrzygotowania { get; set; }
        public string Trudnosc { get; set; } = "";
        public string Skladniki { get; set; } = "";
        public string Instrukcje { get; set; } = "";
    }
}

namespace Kalkulator.Models
{
    public class Dane
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Dane(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}

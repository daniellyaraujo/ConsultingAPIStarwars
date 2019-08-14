using System;
using System.Collections.Generic;

namespace ConstruindoAPI.Models
{
    public class ListPessoas
    {
        public IList<Pessoas> Results { get; set; }

        internal object OrderBy(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }

    public class Pessoas
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Mass { get; set; }
        public string Skin_Color { get; set; }
        public string Hair_Color { get; set; }
        public string Eye_Color { get; set; }
        public string Birth_Year { get; set; }
        public string Gender { get; set; }
        public string HomeWorld { get; set; }
        public ICollection<string> Films { get; set; }
        public ICollection<string> Species { get; set; }
        public ICollection<string> Vehicles { get; set; }
        public ICollection<string> Starships { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }

       
    }
}

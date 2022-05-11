using System.Collections.Generic;

namespace graduationtourwebsite.Models
{
    public class tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<place> places { get; set; }
    }
}

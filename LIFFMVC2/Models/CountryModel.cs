using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LIFFMVC2.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation properties
        public virtual Collection<Film> Films { get; set; }
    }
    
}

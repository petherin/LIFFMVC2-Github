using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LIFFMVC2.Models
{
    public class ImagePath
    {
        public int Id { get; set; }
        public string Path { get; set; }

        //Navigation properties
        public virtual Collection<Film> Films { get; set; }
    }
    
}

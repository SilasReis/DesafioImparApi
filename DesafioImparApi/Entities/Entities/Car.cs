using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Car
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Photo Photo { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelBilgiSistemi.Models
{
    public class Birim
    {
        [Key]
        public int BirimId { get; set; }
        public string BirimAdi { get; set; }
        public List<Personel> Personels { get; set; }
    }
}

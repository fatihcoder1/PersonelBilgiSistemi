using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelBilgiSistemi.Models
{
    public class Personel
    {

        [Key]
        public int PersonelId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Sehir { get; set; }
        public int BirimId { get; set; }
        public Birim Birim { get; set; }
    }
}

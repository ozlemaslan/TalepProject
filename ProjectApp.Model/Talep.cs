using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ProjectApp.Model
{
    public class Talep : BaseEntity
    {
        [Required]
        public string Ad { get; set; }

        [Required]
        public string Soyad { get; set; }
        public string Aciklama { get; set; }

        [Required]
        public byte[] Dosya { get; set; }
        public DateTime DegerlendirmeZamani { get; set; }
        public bool IsOlumlu { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}

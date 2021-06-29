using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.Model
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            IsActive = true;
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        [DisplayName("Aktif Mi")]
        public bool IsActive { get; set; }
        [DisplayName("Tarih")]
        public DateTime CreatedDate { get; set; }
    }
}

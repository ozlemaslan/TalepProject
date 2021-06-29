using ProjectApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.DataAccess.Interfaces
{
    public interface ITalepRepository
    {
        Talep Insert(Talep talep);
        Talep Delete(Talep talep);
        Talep Update(Talep talep);
        List<Talep> GetAll();
        Talep GetTalepId(int id);
        
    }
}

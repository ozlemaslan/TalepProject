using ProjectApp.DataAccess.Interfaces;
using ProjectApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.DataAccess.Repository
{
    public class TalepRepository : ITalepRepository
    {
        TalepContext _context;
        public TalepRepository(TalepContext context)
        {
            _context = context;
        }
        public Talep Delete(Talep talep)
        {
            try
            {
                _context.Taleps.Remove(talep);
                _context.SaveChanges();
                return talep;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Talep> GetAll()
        {
            return _context.Taleps.ToList();
        }

        public Talep GetTalepId(int id)
        {
            return _context.Taleps.Find(id);
        }

        public Talep Insert(Talep talep)
        {
            try
            {
                _context.Taleps.Add(talep);
                _context.SaveChanges();
                return talep;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Talep Update(Talep talep)
        {
            try
            {
                Talep t = new Talep();
                t.Aciklama = talep.Aciklama;
                t.Ad = talep.Ad;
                t.Soyad = talep.Soyad;
                t.Dosya = talep.Dosya;
                t.CreatedDate = talep.CreatedDate;
                t.DegerlendirmeZamani = talep.DegerlendirmeZamani;

                _context.Entry(t).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return talep;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

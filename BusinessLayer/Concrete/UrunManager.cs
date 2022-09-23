using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UrunManager : IUrunService
    {
        IUrunDal _urunDal;

        public UrunManager(IUrunDal urunDal)
        {
            _urunDal = urunDal;
        }

        public List<Urun> GetList()
        {
            return _urunDal.GetListAll();
        }

        public void TAdd(Urun t)
        {
            _urunDal.Insert(t);
        }

        public void TDelete(Urun t)
        {
            _urunDal.Delete(t);
        }

        public Urun TGetById(int id)
        {
            return _urunDal.GetById(id);
        }

        public void TUpdate(Urun t)
        {
            _urunDal.Update(t);
        }
    }
}

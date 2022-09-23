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
    public class ReferanslarManager : IReferanslarService
    {
        IReferanslarDal _referanslarDal;

        public ReferanslarManager(IReferanslarDal referanslarDal)
        {
            _referanslarDal = referanslarDal;
        }

        public List<Referanslar> GetList()
        {
            return _referanslarDal.GetListAll();
        }

        public void TAdd(Referanslar t)
        {
            _referanslarDal.Insert(t);
        }

        public void TDelete(Referanslar t)
        {
            _referanslarDal.Delete(t);
        }

        public Referanslar TGetById(int id)
        {
            return _referanslarDal.GetById(id);
        }

        public void TUpdate(Referanslar t)
        {
            _referanslarDal.Update(t);
        }
    }
}

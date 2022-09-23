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
    public class FooterManager : IFooterService
    {
        IFooterDal _footerDal;

        public FooterManager(IFooterDal footerDal)
        {
            _footerDal = footerDal;
        }

        public List<Footer> GetList()
        {
            return _footerDal.GetListAll();
        }

        public void TAdd(Footer t)
        {
            _footerDal.Insert(t);
        }

        public void TDelete(Footer t)
        {
            _footerDal.Delete(t);
        }

        public Footer TGetById(int id)
        {
            return _footerDal.GetById(id);
        }

        public void TUpdate(Footer t)
        {
            _footerDal.Update(t);
        }
    }
}

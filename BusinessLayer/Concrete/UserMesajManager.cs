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
    public class UserMesajManager : IUserMesajService
    {
        IUserMesajDal _usermesajDal;

        public UserMesajManager(IUserMesajDal usermesajDal)
        {
            _usermesajDal = usermesajDal;
        }

        public List<UserMesaj> GetList()
        {
            return _usermesajDal.GetListAll();
        }

        public void TAdd(UserMesaj t)
        {
            _usermesajDal.Insert(t);
        }

        public void TDelete(UserMesaj t)
        {
            _usermesajDal.Delete(t);
        }

        public UserMesaj TGetById(int id)
        {
            return _usermesajDal.GetById(id);
        }

        public void TUpdate(UserMesaj t)
        {
            _usermesajDal.Update(t);
        }
    }
}

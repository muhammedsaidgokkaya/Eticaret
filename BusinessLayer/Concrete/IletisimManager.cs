﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class IletisimManager : IIletisimService
    {
        IIletisimDal _iletisimDal;

        public IletisimManager(IIletisimDal iletisimDal)
        {
            _iletisimDal = iletisimDal;
        }

        public List<Iletisim> GetList()
        {
            return _iletisimDal.GetListAll();
        }

        public void TAdd(Iletisim t)
        {
            _iletisimDal.Insert(t);
        }

        public void TDelete(Iletisim t)
        {
            _iletisimDal.Delete(t);
        }

        public Iletisim TGetById(int id)
        {
            return _iletisimDal.GetById(id);
        }

        public void TUpdate(Iletisim t)
        {
            _iletisimDal.Update(t);
        }
    }
}

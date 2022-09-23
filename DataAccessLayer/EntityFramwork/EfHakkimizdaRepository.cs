﻿using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramwork
{
    public class EfHakkimizdaRepository : GenericRepository<Hakkimizda>, IHakkimizdaDal
    {
    }
}

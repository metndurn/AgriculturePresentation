﻿using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AdminManager : IAdminService
	{
		IAdminDal _adminDal;
		public AdminManager(IAdminDal adminDal)//constructor injection ıslemı var burada unutma bunları
		{
			_adminDal = adminDal;
		}
		public void Delete(Admin t)
		{
			_adminDal.Delete(t);
		}

		public Admin GetById(int id)
		{
			return _adminDal.GetById(id);
		}

		public List<Admin> GetListAll()//listeleme işlemi
		{
			return _adminDal.GetListAll();
		}

		public void Insert(Admin t)
		{
			_adminDal.Insert(t);
		}

		public void Update(Admin t)
		{
			_adminDal.Update(t);
		}
	}
}

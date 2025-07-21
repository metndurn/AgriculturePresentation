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
	public class AddressManager : IAddressService // IAddressService interface'ini implement eden AddresManager sınıfı
	{
		private readonly IAddressDal _addressDal;
		public AddressManager(IAddressDal addressDal)
		{
			_addressDal = addressDal;
		}

		public void Delete(Address t)
		{
			_addressDal.Delete(t);
		}

		public Address GetById(int id)
		{
			return _addressDal.GetById(id);
		}

		public List<Address> GetListAll()
		{
			return _addressDal.GetListAll();
		}

		public void Insert(Address t)
		{
			_addressDal.Insert(t);
		}

		public void Update(Address t)
		{
			_addressDal.Update(t);
		}
	}
}

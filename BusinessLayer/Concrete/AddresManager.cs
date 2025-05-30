using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AddresManager : IAddressService // IAddressService interface'ini implement eden AddresManager sınıfı
	{
		private readonly IAddressDal _addresDal;

		public AddresManager(IAddressDal addresDal)
		{
			_addresDal = addresDal;
		}

		public void Delete(Address t)
		{
			_addresDal.Delete(t);
		}

		public Address GetById(int id)
		{
			return _addresDal.GetById(id);
		}

		public List<Address> GetListAll()
		{
			return _addresDal.GetListAll();
		}

		public void Insert(Address t)
		{
			_addresDal.Insert(t);
		}

		public void Update(Address t)
		{
			_addresDal.Update(t);
		}
	}
}

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
	public interface IAddressDal : IGenericDal<Address>
	{
		//List<Entities.Concrete.Address> GetListAll(Func<Address, bool> filter);// filtreleme
		//Entities.Concrete.Address GetById(Func<Address, bool> filter);//ıd'ye gore filtreleme
		//List<Entities.Concrete.Address> GetListAll(Func<Address, bool> filter, int page, int pageSize);//tum listeyi filtreleme ve sayfalama
		//int Count(Func<Address, bool> filter);//filtreleme ve sayfalama
		//int Count();//tum listeyi sayma
	}
}

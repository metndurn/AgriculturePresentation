using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete.EntityFramework
{
	public class EfAddressDal : GenericRepository<Address>, IAddressDal
	{
		//GenericRepository'den miras alındığı için burada sadece özel metodlar yazılacak.
		//Eğer özel bir metod yoksa buraya gerek yoktur.
		//Eğer bir metod yazılacaksa GenericRepository'den miras alındığı için burada override edilmelidir.
	}
}

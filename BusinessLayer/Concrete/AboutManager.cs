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
	public class AboutManager : IAboutService
	{
		private readonly IAboutDal _aboutDal;
		public AboutManager(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}

		public void Delete(About entity)
		{
			throw new NotImplementedException();
		}

		public About GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<About> GetListAll()
		{
			return _aboutDal.GetListAll();
		}

		public void Insert(About entity)
		{
			throw new NotImplementedException();
		}

		public void Update(About entity)
		{
			throw new NotImplementedException();
		}
	}
}

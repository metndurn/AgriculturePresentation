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
	/*teamManager ile ilgili butun metodlar burada yazıldı yani icleri dolduruldu*/
	public class TeamManager : ITeamService
	{
		private readonly ITeamDal _teamDal;//dependency injection ile _teamDal'ı kullanacağız. Bu sayede ITeamDal interface'ini implement eden sınıfları kullanabileceğiz.

		public TeamManager(ITeamDal teamDal)//constructor injection yapıcı metot
		{
			_teamDal = teamDal;
		}

		public void Delete(Team t)//silme
		{
			_teamDal.Delete(t);
		}

		public Team GetById(int id)//ıd'ye göre getirme
		{
			return _teamDal.GetById(id);
		}

		public List<Team> GetListAll()//tumunu listeleme
		{
			return _teamDal.GetListAll();
		}

		public void Insert(Team t)//ekleme
		{
			_teamDal.Insert(t);
		}

		public void Update(Team t)//guncelleme
		{
			_teamDal.Update(t);
		}
	}
}

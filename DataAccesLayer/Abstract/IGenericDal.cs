using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
	public interface IGenericDal<T> where T : class, new()
	{
		void Insert(T t);//ekleme
		void Update(T t);//güncelleme
		void Delete(T t);//silme
		T GetById(int id);//id ile bulma
		List<T> GetListAll();//tüm herseyi listeleme
		//List<T> GetListAll(Func<T, bool> filter);// filtreleme
		//T GetById(Func<T, bool> filter);//ıd'ye gore filtreleme
		//List<T> GetListAll(Func<T, bool> filter, int page, int pageSize);//tum listeyi filtreleme ve sayfalama
		//int Count(Func<T, bool> filter);//filtreleme ve sayfalama
		//int Count();//tum listeyi sayma
	}
}

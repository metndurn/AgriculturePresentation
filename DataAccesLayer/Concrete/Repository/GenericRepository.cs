using DataAccesLayer.Abstract;
using DataAccesLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete.Repository
{
	/*miras alınıp implemente edıldı yanı kodlar buradan yazılacak*/
	public class GenericRepository<T> : IGenericDal<T> where T : class, new()
	{
		public void Delete(T t)
		{
			using var context = new AgricultureContext();
			context.Remove(t);//veri tabanından siler
			context.SaveChanges();
		}

		public T GetById(int id)
		{
			using var context = new AgricultureContext();
			return context.Set<T>().Find(id);//veri tabanından id'ye göre bulur
		}

		public List<T> GetListAll()
		{
			using var context = new AgricultureContext();//veri tabanı baglantısı
			return context.Set<T>().ToList();//tüm listeyi getirir
		}

		public void Insert(T t)
		{
			using var context = new AgricultureContext();
			context.Add(t);
			context.SaveChanges();
		}

		public void Update(T t)
		{
			using var context = new AgricultureContext();
			context.Update(t);
			context.SaveChanges();
		}
	}
}

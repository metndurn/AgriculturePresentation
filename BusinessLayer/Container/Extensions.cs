using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.EntityFramework;
using DataAccesLayer.Contexts;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
	public static class Extensions
	{
		public static void ContainerDependencies(this IServiceCollection service)
		{
			service.AddScoped<IServiceService, ServiceManager>();//burada service manager sınıfı eklenmiş oldu
			service.AddScoped<IServiceDal, EfServiceDal>();//burada service dal sınıfı eklenmiş oldu
			service.AddDbContext<AgricultureContext>();//bununla birlikte context sınıfı da eklenmiş oldu.
			service.AddScoped<ITeamService, TeamManager>();//burada team manager sınıfı eklenmiş oldu
			service.AddScoped<ITeamDal, EfTeamDal>();//burada team dal sınıfı eklenmiş oldu
			service.AddScoped<IAnnouncementService, AnnouncementManager>();//burada announcement manager sınıfı eklenmiş oldu
			service.AddScoped<IAnnouncementDal, EfAnnouncementDal>();//burada announcement dal sınıfı eklenmiş oldu
			service.AddScoped<IImageService, ImageManager>();//burada announcement manager sınıfı eklenmiş oldu
			service.AddScoped<IImageDal, EfImageDal>();//burada announcement dal sınıfı eklenmiş oldu
			service.AddScoped<IAddressService, AddressManager>();//burada announcement manager sınıfı eklenmiş oldu
			service.AddScoped<IAddressDal, EfAddressDal>();//burada announcement dal sınıfı eklenmiş oldu
			service.AddScoped<IContactService, ContactManager>();//burada announcement manager sınıfı eklenmiş oldu
			service.AddScoped<IContactDal, EfContactDal>();//burada announcement dal sınıfı eklenmiş oldu
			service.AddScoped<ISocialMediaService, SocialMediaManager>();//burada announcement manager sınıfı eklenmiş oldu
			service.AddScoped<ISocialMediaDal, EfSocialMediaDal>();//burada announcement dal sınıfı eklenmiş oldu
			service.AddScoped<IAboutService, AboutManager>();//burada announcement manager sınıfı eklenmiş oldu
			service.AddScoped<IAboutDal, EfAboutDal>();//burada announcement dal sınıfı eklenmiş oldu
			service.AddScoped<IAdminService, AdminManager>();//burada announcement manager sınıfı eklenmiş oldu
			service.AddScoped<IAdminDal, EfAdminDal>();//burada announcement dal sınıfı eklenmiş oldu
			service.AddScoped<IProductService, ProductManager>();//burada announcement manager sınıfı eklenmiş oldu
			service.AddScoped<IProductDal, EfProductDal>();//burada announcement dal sınıfı eklenmiş oldu
		}
	}
}

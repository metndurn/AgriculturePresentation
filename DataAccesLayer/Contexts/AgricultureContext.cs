using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Contexts
{
	/*katmanlı yapılarda referans ıslemlerı olmadan buraların bır anlamı yok bunu unutma
	 dbcontext kısmı sılınıp yerine identitydbcontext eklendi veritabanında tablolar yok bunları migration
	üzerinden getirecegiz*/
	public class AgricultureContext : IdentityDbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.;Database=AgricultureDB;Integrated Security=True;TrustServerCertificate=True;");
		}
		public DbSet<Address> Addresses { get; set; }
		public DbSet<About> Abouts { get; set; }//sonradan eklendi
		public DbSet<Service> Services { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<Announcement> Announcements { get; set; }
		public DbSet<SocialMedia> SocialMedias { get; set; }//yeni tablo olarak ekledık
		public DbSet<Admin> Admins { get; set; }//yeni tablo olarak ekledık

		public DbSet<Product> Products { get; set; }
	}
}

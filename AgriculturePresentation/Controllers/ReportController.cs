using AgriculturePresentation.Models;
using ClosedXML.Excel;
using DataAccesLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AgriculturePresentation.Controllers
{
	public class ReportController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult StaticReport()
		{
			/*burada raporların verılmesı ıcın kodlar yazılıyor ve esktra olarak bir paket yuklendı
			 oda EPplus adında*/
			ExcelPackage excelPackage = new ExcelPackage();//newleme işlemi yaptık
			var workBook = excelPackage.Workbook.Worksheets.Add("Static Report");

			/*burada veriler verildi daha sonra verılen verılerın ıclerı dolduruldu*/
			workBook.Cells[1, 1].Value = "Ürün Adı";
			workBook.Cells[1, 2].Value = "Ürün Kategorisi";
			workBook.Cells[1, 3].Value = "Ürün Stok";

			workBook.Cells[2, 1].Value = "Mercimek";
			workBook.Cells[2, 2].Value = "Bakliyat";
			workBook.Cells[2, 3].Value = "785 Kg";

			workBook.Cells[3, 1].Value = "Buğday";
			workBook.Cells[3, 2].Value = "Bakliyat";
			workBook.Cells[3, 3].Value = "1.250 Kg";

			workBook.Cells[4, 1].Value = "Havuç";
			workBook.Cells[4, 2].Value = "Sebze";
			workBook.Cells[4, 3].Value = "550 Kg";

			var bytes = excelPackage.GetAsByteArray();//Excel dosyasını baytlara çevirme işlemi dosyaların indirilmesi için gerekli
			return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BakliyatRaporu.xlsx");
		}
		public List<ContactModel> ContactList()//contactlist sayfası için bir action metodu
		{
			List<ContactModel> contactModels = new List<ContactModel>();
			using (var context = new AgricultureContext())// AgricultureContext sınıfından bir context nesnesi oluşturuyoruz
			{
				contactModels = context.Contacts.Select(x => new ContactModel// ContactModel sınıfından bir liste oluşturuyoruz
				{// x.ContactModel sınıfından bir nesne oluşturuyoruz
					ContactId = x.Id,
					ContactName = x.Name,
					ContactEmail = x.Email,
					ContactMessage = x.Message,
					ContactDate = x.Date
				}).ToList();
			}
			return contactModels;// contactModels listesini döndürür
		}
		public IActionResult ContactReport()//contact report sayfası için bir action metodu
		{
			using (var workBook = new XLWorkbook())
			{
				/*baslıkları atandı sımdı ıse alttarafta doldurma ıslemı yapacagız*/
				var worksheet = workBook.Worksheets.Add("Mesaj Listesi");// Contact Report adında bir çalışma sayfası ekliyoruz
				worksheet.Cell(1, 1).Value = "Mesaj ID";// 1. satır 1. sütuna Mesaj ID yazıyoruz
				worksheet.Cell(1, 2).Value = "Mesaj Adı";// 1. satır 2. sütuna Mesaj Adı yazıyoruz
				worksheet.Cell(1, 3).Value = "Mesaj E-Posta";// 1. satır 3. sütuna Mesaj E-Posta yazıyoruz
				worksheet.Cell(1, 4).Value = "Mesaj İçerik";// 1. satır 4. sütuna Mesaj İçerik yazıyoruz
				worksheet.Cell(1, 5).Value = "Mesaj Tarih";// 1. satır 5. sütuna Mesaj Tarih yazıyoruz

				int contactRowCount = 2;// 2. satırdan itibaren verileri doldurmaya başlayacağız
				foreach (var item in ContactList())// ContactList metodundan dönen listeyi döngüye alıyoruz
				{
					worksheet.Cell(contactRowCount, 1).Value = item.ContactId;
					worksheet.Cell(contactRowCount, 2).Value = item.ContactName;
					worksheet.Cell(contactRowCount, 3).Value = item.ContactEmail;
					worksheet.Cell(contactRowCount, 4).Value = item.ContactMessage;
					worksheet.Cell(contactRowCount, 5).Value = item.ContactDate;
					contactRowCount++;// satır sayısını artırıyoruz
				}

				using (var stream = new MemoryStream())// bellek akışı oluşturuyoruz
				{
					workBook.SaveAs(stream);// workbook'u bellek akışına kaydediyoruz
					var content = stream.ToArray();// bellek akışını baytlara çeviriyoruz
					return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MesajRaporu.xlsx");// dosyayı indiriyoruz
				}
			}
		}

		public List<AnnouncementModel> AnnouncementList()//contactlist sayfası için bir action metodu
		{
			List<AnnouncementModel> announcementModels = new List<AnnouncementModel>();
			using (var context = new AgricultureContext())// AgricultureContext sınıfından bir context nesnesi oluşturuyoruz
			{
				announcementModels = context.Announcements.Select(x => new AnnouncementModel// ContactModel sınıfından bir liste oluşturuyoruz
				{// x.ContactModel sınıfından bir nesne oluşturuyoruz
					Id = x.Id,
					Title = x.Title,
					Description = x.Description,
					Date = x.Date,
					Status = x.Status
				}).ToList();
			}
			return announcementModels;// contactModels listesini döndürür
		}
		public IActionResult AnnouncementReport()//contact report sayfası için bir action metodu
		{
			using (var workBook = new XLWorkbook())
			{
				/*baslıkları atandı sımdı ıse alttarafta doldurma ıslemı yapacagız*/
				var worksheet = workBook.Worksheets.Add("Duyuru Listesi");// Contact Report adında bir çalışma sayfası ekliyoruz
				worksheet.Cell(1, 1).Value = "Duyuru ID";// 1. satır 1. sütuna Mesaj ID yazıyoruz
				worksheet.Cell(1, 2).Value = "Duyuru Adı";// 1. satır 2. sütuna Mesaj Adı yazıyoruz
				worksheet.Cell(1, 3).Value = "Duyuru Açıklaması";// 1. satır 3. sütuna Mesaj E-Posta yazıyoruz
				worksheet.Cell(1, 4).Value = "Duyuru Tarihi";// 1. satır 4. sütuna Mesaj İçerik yazıyoruz
				worksheet.Cell(1, 5).Value = "Duyuru Durumu";// 1. satır 5. sütuna Mesaj Tarih yazıyoruz

				int announcementRowCount = 2;// 2. satırdan itibaren verileri doldurmaya başlayacağız
				foreach (var item in AnnouncementList())// ContactList metodundan dönen listeyi döngüye alıyoruz
				{
					worksheet.Cell(announcementRowCount, 1).Value = item.Id;
					worksheet.Cell(announcementRowCount, 2).Value = item.Title;
					worksheet.Cell(announcementRowCount, 3).Value = item.Description;
					worksheet.Cell(announcementRowCount, 4).Value = item.Date;
					worksheet.Cell(announcementRowCount, 5).Value = item.Status;
					announcementRowCount++;// satır sayısını artırıyoruz
				}
				using (var stream = new MemoryStream())// bellek akışı oluşturuyoruz
				{
					workBook.SaveAs(stream);// workbook'u bellek akışına kaydediyoruz
					var content = stream.ToArray();// bellek akışını baytlara çeviriyoruz
					return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DuyuruRaporu.xlsx");// dosyayı indiriyoruz
				}
			}
		}
	}
}

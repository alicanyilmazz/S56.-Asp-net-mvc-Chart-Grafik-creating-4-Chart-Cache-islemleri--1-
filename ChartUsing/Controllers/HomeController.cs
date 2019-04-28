using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ChartUsing.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChartColumn(string tip = "Line")  //Chart tipini parametreye bagladık böylece dışarıdan tipe ne verirsek  ona göre grafik olusacak!
        {

            Chart chart = new Chart(500, 500);
            chart.AddTitle("MyComputer Salesman Graphic");
            chart.AddLegend("Products");
            chart.AddSeries(name: "Computer A", chartType: tip, xValue: new[] { 20, 40, 60 }, yValues: new[] { 800, 1200, 2300 });
            chart.AddSeries(name: "Computer B", chartType: tip, xValue: new[] { 20, 40, 60 }, yValues: new[] { 900, 1600, 3300 });

            string dir = Server.MapPath("~/charts/");

            if(Directory.Exists(dir)==false)
            {
                Directory.CreateDirectory(dir);
            }

            string imagePath = dir + "chart1.jpeg";
            string xmlPath = dir + "chart1.xml";

            chart.Save(imagePath, format: "jpeg");
            chart.SaveXml(xmlPath);
            chart.SaveToCache("chart1", 10, true); // 2.parametre kac dk cache de kalacak ,3. parametre Expiration yani 10 dk dolmadan page refresh edilirse true ise süreyi basa sarar false ise sarmaz 10dk dolunca siler direkt.
            return View(chart);
        }
    }
}
/*
 Burada olusturdugumuz chart'ları (grafikleri) Server da bir Folder olsuturup içerisine kaydettik.
 Böylece Degişik formatlarda kaydettğimiz bu grafikleri saklayabiliriz daha sonrası için ve hatta xml veya jpeg formattında okuma işlemleri yapabiliriz hız ve yedekleme saglar buda bize.
 ****Solution içerisinde chart isiminde bir Folder olusturacak ve içerisine jpeg ve xml formatlarında bu chart 'ları kaydedecek isterseniz baska formatlarda da kayıt edebilirsiniz.
     */
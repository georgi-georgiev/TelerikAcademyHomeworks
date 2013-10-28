using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Essentials.Models;

namespace MVC_Essentials.Controllers
{
    public class CalculateController : Controller
    {
        List<string> Types;
        List<SelectListItem> TypesItems;
        public CalculateController()
        {
            this.Types = new List<string>()
            {
                "bit - b",
                "Byte - B",
                "Kilobit - Kb",
                "Kilobyte - KB",
                "Megabit - Mb",
                "Megabyte - MB",
                "Gigabit - Gb",
                "Gigabyte - GB",
                "Terabit - Tb",
                "Terabyte - TB",
                "Petabit - Pb",
                "Petabyte - PB",
                "Exabit - Eb",
                "Exabyte - EB",
                "Zettabit - Zb",
                "Zettabyte - ZB",
                "Yottabit - Yb",
                "Yottabyte - YB"
            };

            this.TypesItems = new List<SelectListItem>();

            foreach (var type in Types)
            {
                TypesItems.Add(new SelectListItem() { Text = type, Value = type });
            }
        }

        public ActionResult Index()
        {
            this.ViewBag.Types = this.TypesItems;
            return View();
        }

        [HttpPost]
        public ActionResult Convert(int? quantity, string Types, string Kilo)
        {
            if(quantity == null)
            {
                quantity = 1;
            }

            int quantityInt = (int)quantity;
            double kiloInt = double.Parse(Kilo);

            double startKilo = 1;
            for (int i = 0; i < Math.Floor((double)this.Types.IndexOf(Types)/2)+1; i++)
            {
                startKilo *= 1024;
            }
            if (Types.Contains("bit"))
            {
                kiloInt = (double)quantity * startKilo;
            }
            else
            {
                kiloInt = (double)quantity * startKilo * 8;
            }

            ViewBag.Types = this.TypesItems;
            var results = new List<CalculateResult>();
            kiloInt /= double.Parse(Kilo);
            results.Add(new CalculateResult() { Name = this.Types[0], Size = kiloInt });

            foreach(var type in this.Types)
            {
                if (type != this.Types[0])
                {
                    if (type.Contains("bit"))
                    {
                        kiloInt /= double.Parse(Kilo) / 8;
                        results.Add(new CalculateResult() { Name = type, Size = kiloInt });
                    }
                    else
                    {
                        kiloInt /= double.Parse(Kilo) / 128;
                        results.Add(new CalculateResult() { Name = type, Size = kiloInt });
                    }
                }
            }
            ViewBag.Results = results;
            return View("Index");
        }
	}
}
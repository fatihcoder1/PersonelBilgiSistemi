using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonelBilgiSistemi.Models;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PersonelBilgiSistemi.Controllers
{
    public class PersonellerController : Controller
    {
        Context context = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var personel = context.Personels.Include(x => x.Birim).ToList();

            return View(personel);
        }
        [HttpGet]
        public IActionResult YeniPersonel()
        {

            List<SelectListItem> degerler = (from x in context.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAdi,
                                                 Value = x.BirimId.ToString(),
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }
        public IActionResult YeniPersonel(Personel p)
        {
            var per = context.Birims.Where(x => x.BirimId == p.Birim.BirimId).FirstOrDefault();
            p.Birim = per;
            context.Personels.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index"); 
        }
    }
}

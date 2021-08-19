using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonelBilgiSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelBilgiSistemi.Controllers
{
    public class BirimController : Controller
    {
        Context context = new Context();
        
        public IActionResult Index()
        {
            var degerler = context.Birims.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniBirim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim b)
        {
            context.Birims.Add(b);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimSil(int id)
        {
            var birim = context.Birims.Find(id);
            context.Birims.Remove(birim);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimGetir(int id)
        {
            var birim = context.Birims.Find(id);
            return View("BirimGetir", birim);
        }
        public IActionResult BirimGuncelle(Birim b)
        {
            var birim = context.Birims.Find(b.BirimId);
            birim.BirimAdi = b.BirimAdi;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimDetay(int id)
        {
            var degerler = context.Personels.Where(x => x.BirimId == id).ToList();
            var brmad = context.Birims.Where(y => y.BirimId == id).Select(
                 x => x.BirimAdi
                ).FirstOrDefault();
            ViewBag.brm = brmad;
            return View(degerler);
        }
    }

}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practice.Data;
using Practice.Models;

namespace Practice.Controllers
{
    public class DistrictController : Controller
    {
        //databse Connectivity
        private readonly ApplicationDbContext _context;
        public DistrictController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //query to get list of datas from databse using ef
            List<DistrictModel> dsitricts = _context.DistrictModel.Include(p => p.Province).ToList();
            return View(dsitricts);
        }

        public IActionResult Details(int id)
        {
            DistrictModel model = _context.DistrictModel.Find(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var provinces = _context.ProvinceModel.ToList();
            ViewData["ProvinceId"] = new SelectList(provinces, "Id", "Name");
            return View();
        }

        [HttpPost]

        public IActionResult Create(DistrictModel modeldata)
        {
            if (ModelState.IsValid)
            {
                //save data to database
                _context.DistrictModel.Add(modeldata);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var provinces = _context.ProvinceModel.ToList();
            ViewData["ProvinceId"] = new SelectList(provinces, "Id", "Name");
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var provinces = _context.ProvinceModel.ToList();
            ViewData["ProvinceId"] = new SelectList(provinces, "Id", "Name");
            var data = _context.DistrictModel.Find(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            return View(data);
        }



        [HttpPost]
        public IActionResult Edit(DistrictModel modeldata)
        {
            if (ModelState.IsValid)
            {
                _context.DistrictModel.Update(modeldata);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modeldata);

            //[HttpGet]
            //public IActionResult Delete(int id)
            //{
            //    return View();
            //}

            //[HttpPost]

            //public IActionResult Delete(DistrictModel modeldata)
            //{
            //    return View();
            //}
        }
    }
}

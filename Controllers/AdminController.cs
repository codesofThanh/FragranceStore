using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Project.DAO;
using Project.Models;
using System.Xml.Linq;

namespace Project.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("roleId") == null)
            {
                //return RedirectToAction("Index", "Home");//action: Index, controller: Home
                return View("AcessDenied");//"": ten cua View
                //return View();//no se tra ve cùng 1 view
            }
            else
            {
                return View();
            }
        }
        public IActionResult AllProduct()
        {
            ViewBag.list = PRN211_FA23_SE1733_2Context.INSTANCE.ProductHe172748s.ToList();
            return View();
        }
        public IActionResult Brand()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            var c = PRN211_FA23_SE1733_2Context.INSTANCE.CategoryHe172748s.ToList();
            ViewBag.c = c;
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(IFormCollection f)
        {
            string name = f["title"];
            string img = f["imageBase64"];
            int categoryId = int.Parse(f["genre"]);
            string description = f["detail1"];
            string tmp = f["detail2"];
            decimal price = decimal.Parse(f["price"]);
            int empId = 1;

           var product = new ProductHe172748
           {
               Name = name,
               Img = img,
               CategoryId = categoryId,
               Description = description,
               Tmp = tmp,
               Price = price,
               EmployeeEmployeeId = empId
           };
            PRN211_FA23_SE1733_2Context.INSTANCE.ProductHe172748s.Add(product);
            PRN211_FA23_SE1733_2Context.INSTANCE.SaveChanges();

            return Redirect("/Admin/AllProduct");
        }
        public IActionResult Edit(int id)
        {
            //int ID = id;
            //if (TempData["id"] != null)
            //{
            //    if (int.TryParse(TempData["id"].ToString(), out int tmp))
            //    {
            //        ID = tmp;
            //    }
            //    else
            //    {
            //        // Xử lý trường hợp không thể phân tích chuỗi thành số nguyên
            //    }
            //}

            if (id != null)
            {
                var p = PRN211_FA23_SE1733_2Context.INSTANCE.ProductHe172748s.Find(id);
                var c = PRN211_FA23_SE1733_2Context.INSTANCE.CategoryHe172748s.ToList();
                ViewBag.c = c;
                ViewBag.p = p;
            }
            return View("Product");
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection f)
        {
            int id = int.Parse(f["bookid"]);
            string name = f["title"];
            string img = f["imageBase64"];
            int categoryId = int.Parse(f["genre"]);
            string description = f["detail1"];
            string tmp = f["detail2"];
            decimal price = decimal.Parse(f["price"]);

            var product = PRN211_FA23_SE1733_2Context.INSTANCE.ProductHe172748s.Find(id);

            if (product != null)
            {
                
                product.Name = name;
                product.Img = img;
                product.Price = price;
                product.CategoryId = categoryId;
                product.Description = description;
                product.Tmp = tmp;
                PRN211_FA23_SE1733_2Context.INSTANCE.ProductHe172748s.Update(product);
                PRN211_FA23_SE1733_2Context.INSTANCE.SaveChanges();


                var p = PRN211_FA23_SE1733_2Context.INSTANCE.ProductHe172748s.Find(id);
                var c = PRN211_FA23_SE1733_2Context.INSTANCE.CategoryHe172748s.ToList();
                ViewBag.c = c;
                ViewBag.p = p;
                ViewBag.actionmsg = "Update Successfully!";
                return View("Product");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var x = PRN211_FA23_SE1733_2Context.INSTANCE.ProductHe172748s.Find(id);
            if (x != null)
            {
                var y = PRN211_FA23_SE1733_2Context.INSTANCE.ReviewHe172748s.Where(x => x.ProductId == id).ToList();
                var z = PRN211_FA23_SE1733_2Context.INSTANCE.CartHe172748s.Where(x => x.ProductId == id).ToList();

                PRN211_FA23_SE1733_2Context.INSTANCE.ReviewHe172748s.RemoveRange(y);
                PRN211_FA23_SE1733_2Context.INSTANCE.CartHe172748s.RemoveRange(z);
                PRN211_FA23_SE1733_2Context.INSTANCE.ProductHe172748s.Remove(x);
                PRN211_FA23_SE1733_2Context.INSTANCE.SaveChanges();
            }
            return Redirect("/Admin/AllProduct");
        }
    }
}

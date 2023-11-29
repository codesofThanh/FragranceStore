using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json; // Để sử dụng JsonConvert


namespace Project.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			if (HttpContext.Session.GetString("user") != null)
				ViewBag.user = HttpContext.Session.GetString("user");
			if (HttpContext.Session.GetInt32("roleId") != null)
				ViewBag.roleId = HttpContext.Session.GetInt32("roleId");
			if (HttpContext.Session.GetInt32("CustomerId") != null)
				ViewBag.CustomerId = HttpContext.Session.GetInt32("CustomerId");


			ViewBag.p = PRN211_FA23_SE1733_2Context.INSTANCE.ProductHe172748s.Select(x => x).ToList();
			ViewBag.c = PRN211_FA23_SE1733_2Context.INSTANCE.CategoryHe172748s.Select(x => x).ToList();


			if (TempData["brand"] != null)
			{
				if (int.TryParse(TempData["brand"].ToString(), out int id))
				{
					ViewBag.p = PRN211_FA23_SE1733_2Context.INSTANCE.ProductHe172748s.Select(x => x).Where(x => x.CategoryId == id).ToList();
					ViewBag.c = PRN211_FA23_SE1733_2Context.INSTANCE.CategoryHe172748s.Select(x => x).ToList();
					ViewBag.id = id;
				}
				else
				{
					// Xử lý trường hợp không thể phân tích chuỗi thành số nguyên
				}
			}
			var lastOrderId = PRN211_FA23_SE1733_2Context.INSTANCE.OrderHe172748s.Max(x => x.Total);
                                ;


            return View("Index");
		}
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(IFormCollection f)
		{
			string user = f["username"];
			string password = f["password"];
			EmployeeHe172748? acc = PRN211_FA23_SE1733_2Context.INSTANCE.EmployeeHe172748s.FirstOrDefault(e => e.Username == user);
			CustomerHe172748? acc1 = PRN211_FA23_SE1733_2Context.INSTANCE.CustomerHe172748s.FirstOrDefault(c => c.Username == user);

			string mess = "";
			if (acc != null && acc.Password.Equals(password) || (acc1 != null && acc1.Password.Equals(password)))
			{
				HttpContext.Session.SetString("user", user);
				if (acc != null && acc.Password.Equals(password))
				{
					HttpContext.Session.SetInt32("roleId", acc.RoleRoleId);
				}
				if (acc1 != null && acc1.Password.Equals(password))
				{
					HttpContext.Session.SetInt32("CustomerId", acc1.CustomerId);
				}
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.ErrorMessage = "Đăng nhập thất bại. Vui lòng thử lại.";
				return View();
			}
		}
		public IActionResult Logout()
		{
			HttpContext.Session.Remove("user");
			HttpContext.Session.Remove("roleId");
			HttpContext.Session.Remove("CustomerId");
			return RedirectToAction("Index");
		}


		[HttpPost]
		public IActionResult ListByC(IFormCollection f)
		{
			int id = int.Parse(f["brand"]);
			//ViewBag.p = PRN211_FA23_SE1733_2Context.INSTANCE.ProductHe172748s.Select(x => x).Where(x => x.CategoryId == id).ToList();
			//if (HttpContext.Session.GetString("user") != null)
			//	ViewBag.user = HttpContext.Session.GetString("user");
			//ViewBag.c = PRN211_FA23_SE1733_2Context.INSTANCE.CategoryHe172748s.Select(x => x).ToList();
			//ViewBag.id = id;
			//return View();


			TempData["brand"] = id;

			return RedirectToAction("Index");
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Register(IFormCollection f)
		{
			string username = (f["username"]);
			string password = (f["password"]);
			string PhoneNumber = (f["PhoneNumber"]);
			string FullName = (f["PhoneNumber"]);
			string Email = (f["Email"]);
			CustomerHe172748? acc = PRN211_FA23_SE1733_2Context.INSTANCE.CustomerHe172748s.FirstOrDefault(e => e.Username == username);
			EmployeeHe172748? acc1 = PRN211_FA23_SE1733_2Context.INSTANCE.EmployeeHe172748s.FirstOrDefault(e => e.Username == username);

			if (acc != null || acc1 != null)
			{
				ViewBag.ErrorMessage = "Username existed! Choose another username.";
				return View();
			}
			else
			{
				PRN211_FA23_SE1733_2Context.INSTANCE.CustomerHe172748s.Add(new CustomerHe172748()
				{
					FullName = FullName,
					Address = "",
					PhoneNumber = PhoneNumber,
					Email = Email,
					Username = username,
					Password = password
				});
				PRN211_FA23_SE1733_2Context.INSTANCE.SaveChanges();
			}
			return View();
		}
		public IActionResult Detail(int id)
		{
			ViewBag.product = PRN211_FA23_SE1733_2Context.INSTANCE.ProductHe172748s
				.Where(x => x.Id == id) // Lọc sản phẩm theo Id
				.Join(
					PRN211_FA23_SE1733_2Context.INSTANCE.CategoryHe172748s, // Bảng Categories
					p => p.CategoryId, // Khóa ngoại trong sản phẩm
					c => c.Id, // Khóa chính trong danh mục
					(p, c) => new
					{
						Id = id,
						Name = p.Name,
						Img = p.Img,
						Price = p.Price,
						Description = p.Description,
						Tmp = p.Tmp,
						CategoryName = c.Cname
					} // Chọn các thuộc tính bạn quan tâm
				)
				.FirstOrDefault();

			//Lay comment 
			var comment = PRN211_FA23_SE1733_2Context.INSTANCE.ReviewHe172748s
				.Where(x => x.ProductId == id) // Lọc sản phẩm theo Id
				.Join(
					PRN211_FA23_SE1733_2Context.INSTANCE.CustomerHe172748s, // Bảng Categories
					p => p.CustomerCustomerId, // Khóa ngoại trong sản phẩm
					c => c.CustomerId, // Khóa chính trong danh mục
					(p, c) => new
					{
						Id = p.Id,
						CusName = c.FullName,
						Content = p.Content,
						CreateOn = p.CreateOn
					} // Chọn các thuộc tính bạn quan tâm
				)
				.ToList();
			if (HttpContext.Session.GetString("user") != null)
				ViewBag.user = HttpContext.Session.GetString("user");
			if (HttpContext.Session.GetInt32("CustomerId") != null)
				ViewBag.CustomerId = HttpContext.Session.GetInt32("CustomerId");
			if (HttpContext.Session.GetInt32("roleId") != null)
				ViewBag.roleId = HttpContext.Session.GetInt32("roleId");

			//HttpContext.Session.SetString("cart", JsonSerializer.Serialize(comment));
			ViewBag.comment = comment;
			return View();
		}
		public IActionResult Cart(int CustomerId)
		{
			if (HttpContext.Session.GetInt32("CustomerId") != null)
			{
				var cartByCustomerId = PRN211_FA23_SE1733_2Context.INSTANCE.CartHe172748s.Include(x => x.Product).Where(x => x.CustomerCustomerId == CustomerId).Where(x => x.Amount > 0).ToList();
				ViewBag.cartByCustomerId = cartByCustomerId;
				ViewBag.CustomerId = CustomerId;
				decimal total = 0;
				foreach (CartHe172748 item in cartByCustomerId)
				{
					total = total + item.Product.Price * item.Amount;
				}
				ViewBag.total = total;

				if (total == 0)
				{
					ViewBag.emptyCart = "Empty Cart!";
				}


				if (HttpContext.Session.GetString("user") != null)
					ViewBag.user = HttpContext.Session.GetString("user");
				if (HttpContext.Session.GetInt32("roleId") != null)
					ViewBag.roleId = HttpContext.Session.GetInt32("roleId");
                
				
				if (TempData["errorAddress"] != null)
				{
					ViewBag.errorAddress = TempData["errorAddress"];
                }

                    return View("Cart");
			}
			else
			{
				return RedirectToAction("Login");
			}
		}

		public IActionResult DeleteComment(int id, int proId)
		{
			var x = PRN211_FA23_SE1733_2Context.INSTANCE.ReviewHe172748s.Find(id);
			if (x != null)
			{
				PRN211_FA23_SE1733_2Context.INSTANCE.ReviewHe172748s.Remove(x);
				PRN211_FA23_SE1733_2Context.INSTANCE.SaveChanges();
			}
			return RedirectToAction("Detail", new { id = proId });
		}
		[HttpPost]
		public IActionResult Comment(IFormCollection f)
		{
			string message = f["message"];
			DateTime currentTime = DateTime.Now;
			int proId = int.Parse(f["proId"]);
			int star = 4;
			int? cusID = HttpContext.Session.GetInt32("CustomerId");
			string tmp = "empty";

			var x = new ReviewHe172748
			{
				Content = message,
				Star = star,
				CustomerCustomerId = cusID.Value,
				CreateOn = currentTime,
				ProductId = proId,
				Tmp = tmp
			};
			PRN211_FA23_SE1733_2Context.INSTANCE.ReviewHe172748s.Add(x);
			PRN211_FA23_SE1733_2Context.INSTANCE.SaveChanges();

			return RedirectToAction("Detail", new { id = proId });  // new { id = yourIdValue, data = additionalData }
		}
		public IActionResult AddToCart(int idProduct, int idCategory, int Amount, int idCustomer)
		{
			if (idCustomer != null && idCustomer != 0)//da dang nhap
			{
				if (idCategory != 0)
				{
					TempData["brand"] = idCategory;
				}
				//dong nay khong dung den
				List<CartHe172748> cart;
				if (HttpContext.Session.GetString("cart") != null)
				{
					string data = HttpContext.Session.GetString("cart");
					cart = JsonSerializer.Deserialize<List<CartHe172748>>(data);
				}
				else
				{
					cart = new List<CartHe172748>();
				}
				//dong nay khong dung den


				CartHe172748 order = PRN211_FA23_SE1733_2Context.INSTANCE.CartHe172748s.FirstOrDefault(x => x.ProductId == idProduct && x.CustomerCustomerId == idCustomer);
				if (order == null) // chua co product trong cart cua khach hang thi moi add product, +quantity ben kia
				{
					order = new CartHe172748();
					order.ProductId = idProduct;
					order.Amount = 1; //day la quantity
					order.CustomerCustomerId = idCustomer;
					PRN211_FA23_SE1733_2Context.INSTANCE.CartHe172748s.Add(order);
					PRN211_FA23_SE1733_2Context.INSTANCE.SaveChanges();
				}
				if (order != null)//quantity ben kia
				{
					order.Amount = order.Amount + 1; //day la quantity
					PRN211_FA23_SE1733_2Context.INSTANCE.SaveChanges();
				}

				HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cart));
				if (idCategory == -1)
				{
					return RedirectToAction("Detail", new { id = idProduct });
				}

				return RedirectToAction("Index");
			}
			else//chua dang nhap
			{
				return RedirectToAction("Login");
			}
		}
		[HttpPost]
		public IActionResult UpdateCart(IFormCollection f)
		{
            int customerId = int.Parse(f["customerId"]);
            var cartByCustomerId = PRN211_FA23_SE1733_2Context.INSTANCE.CartHe172748s.Where(x => x.Amount > 0 && x.CustomerCustomerId == customerId).ToList(); //sao

            if (HttpContext.Session.GetInt32("CustomerId") != null)
			{
				foreach (var item in cartByCustomerId)
				{
					int amount = int.Parse(f[item.Id.ToString()]); 
					var cartById = PRN211_FA23_SE1733_2Context.INSTANCE.CartHe172748s.FirstOrDefault(x => x.Id == item.Id);
					cartById.Amount = amount; 
					PRN211_FA23_SE1733_2Context.INSTANCE.SaveChanges();
				}


				if (f["Buy"].Equals("Buy"))
				{
					string address = f["Address"];
					if (address.Equals("") || address == null) 
					{
						ViewBag.errorAddress = "Address is not empty!";
						TempData["errorAddress"] = "Address is not empty!";
                    } 
					else
					{
						//add order
                        OrderHe172748 order = new OrderHe172748();
                        order.Address = f["Address"];
						order.Total= decimal.Parse(f["Total"]);
						order.StatusId = 1;
						order.CustomerHe172748CustomerId = int.Parse(f["customerId"]);
                        PRN211_FA23_SE1733_2Context.INSTANCE.OrderHe172748s.Add(order);
                        PRN211_FA23_SE1733_2Context.INSTANCE.SaveChanges();

						//add order detail

						//var latestOrderId1 = PRN211_FA23_SE1733_2Context.INSTANCE.OrderHe172748s.Select(x => x).ToList().Last() ;

						int latestOrderId = order.OrderId;
						//latestOrderId = latestOrderId1.OrderId + 1 ;
						foreach (var item in cartByCustomerId)
						{
							OrderDetailHe172748 orderDetailHe172748 = new OrderDetailHe172748();
							orderDetailHe172748.OrderHe172748OrderId = latestOrderId;
							orderDetailHe172748.ProductHe172748Id = item.ProductId;
							orderDetailHe172748.Quantity = item.Amount;
							decimal totalPrice = PRN211_FA23_SE1733_2Context.INSTANCE.ProductHe172748s.Where(x => x.Id == item.ProductId).Select(x => x.Price).FirstOrDefault() * item.Amount;
							orderDetailHe172748.TotalPrice = totalPrice;
							PRN211_FA23_SE1733_2Context.INSTANCE.Add(orderDetailHe172748);
						}
                        //clear cart
                        foreach (var item in cartByCustomerId)
                        {
                            int amount = int.Parse(f[item.Id.ToString()]);
                            var cartById = PRN211_FA23_SE1733_2Context.INSTANCE.CartHe172748s.FirstOrDefault(x => x.Id == item.Id);
                            cartById.Amount = 0;
                        }
                        PRN211_FA23_SE1733_2Context.INSTANCE.SaveChanges();
                    }
                }
				return RedirectToAction("Cart", new { CustomerId = customerId });

			}
			else
			{
				return RedirectToAction("Login");
			}
		}

		public IActionResult Orders(int CustomerId)
		{
            //Empty => message //chua set statusID, 1=waiting,2=shipping,3=done,4=cancel
            var listOrder = PRN211_FA23_SE1733_2Context.INSTANCE.OrderHe172748s.Where(x => x.StatusId == 0).Where(x=> x.CustomerHe172748CustomerId == CustomerId).OrderByDescending(x=>x.Total).ToList();
			if(listOrder == null)
			{
				ViewBag.messEmp = "Empty orders!";
			}
			// not empty
			else
			{
                var listStatus = PRN211_FA23_SE1733_2Context.INSTANCE.OrderHe172748s.Select(x=>x.StatusId).ToList();
				ViewBag.listStatus = listStatus;

            }
			return View();
		}
	}
}

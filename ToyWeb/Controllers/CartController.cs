using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToyData.Models;
using ToyData.Repositories;
using ToyWeb.Extensions;
using ToyWeb.Services;

namespace ToyWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly IToyService toyService;
        private readonly IToyRepository toyRepository;

        public CartController(IToyRepository toyRepository, IToyService toyService)
        {
            this.toyRepository = toyRepository;
            this.toyService = toyService;
        }

        public ActionResult Index()
        {
            if (HttpContext.Session.Get("cart") == null)
            {
                List<ShoppingCart> cart = new List<ShoppingCart>();

                HttpContext.Session.SetObject("cart", cart);
            }

            return View();
        }

        public ActionResult Add(string id)
        {
            if (HttpContext.Session.GetObject<List<ShoppingCart>>("cart") == null)
            {
                List<ShoppingCart> cart = new List<ShoppingCart>();
                cart.Add(new ShoppingCart { CToy = toyRepository.FindByPrimaryKey(id), SiQty = 1 });
                HttpContext.Session.SetObject("cart", cart);
            }
            else
            {
                List<ShoppingCart> cart = HttpContext.Session.GetObject<List<ShoppingCart>>("cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].SiQty++;
                }
                else
                {
                    cart.Add(new ShoppingCart { CToy = toyRepository.FindByPrimaryKey(id), SiQty = 1 });
                }
                HttpContext.Session.SetObject("cart", cart);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(string id)
        {
            List<ShoppingCart> cart = HttpContext.Session.GetObject<List<ShoppingCart>>("cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<ShoppingCart> cart = HttpContext.Session.GetObject<List<ShoppingCart>>("cart");
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].CToy.CToyId.Equals(id))
                    return i;
            return -1;
        }

        //public CartController(ToyService toyService)
        //{
        //    this.toyService = toyService;
        //}
        //
        //public IActionResult Index()
        //{
        //    if(HttpContext.Session.Get("cart") == null)
        //    {
        //        List<Item> cart = new List<Item>();
        //
        //        HttpContext.Session.SetObject("cart", cart);
        //    }
        //    return View();
        //}
        //
        //public ActionResult Add(string id)
        //{
        //    if(HttpContext.Session.GetObject<List<Item>>("cart") == null)
        //    {
        //        List<Item> cart = new List<Item>();
        //        cart.Add(new Item { Product = toyService.Find(id), Quantity = 1 });
        //        HttpContext.Session.SetObject("cart", cart);
        //    }
        //    else
        //    {
        //        List<Item> cart = HttpContext.Session.GetObject<List<Item>>("cart");
        //        int index = isExist(id);
        //        if (index != -1)
        //        {
        //            cart[index].Quantity++;
        //        }
        //        else
        //        {
        //            cart.Add(new Item { Product = toyService.Find(id), Quantity = 1 });
        //        }
        //        HttpContext.Session.SetObject("cart", cart);
        //
        //
        //    }
        //    return RedirectToAction("Index");
        //
        //}
        //
        //public ActionResult Remove(string id)
        //{
        //    List<Item> cart = HttpContext.Session.GetObject<List<Item>>("cart");
        //    int index = isExist(id);
        //    cart.RemoveAt(index);
        //    HttpContext.Session.SetObject("cart", cart);
        //    return RedirectToAction("Index");
        //}
        //
        //private int isExist(string id)
        //{
        //    List<Item> cart = HttpContext.Session.GetObject<List<Item>>("cart");
        //    for (int i = 0; i < cart.Count; i++)
        //        if (cart[i].Product.Id.Equals(id))
        //            return i;
        //    return -1;
        //}
    }
}

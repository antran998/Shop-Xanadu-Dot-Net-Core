using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using BraintreeHttp;
using CoreShop_V2.Areas.Admin.Models;
using CoreShop_V2.Areas.Client.ViewModel;
using CoreShop_V2.Helper;
using CoreShop_V2.Paypal;
using CoreShop_V2.Service;
using FinalProjectASPDotnet.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PayPal.Core;
using PayPal.v1.Payments;

namespace CoreShop.Controllers
{
    [Area("client")]
    public class CalculationController : Controller
    {
        private readonly MyDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public CalculationController(MyDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        [Route("Cart")]
        public IActionResult Cart()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            //var cart = HttpContext.Session.GetString("cart");
            //ViewBag.total = cart.Sum(item => item.Product.Price* item.Quantity);
            ViewBag.cart = cart;
            ViewBag.index = 1;
            ViewBag.SubTotal = 0;
            return View();
        }

        [Route("/Buy")]
        [HttpPost]
        public IActionResult Buy(string id, string quantity)
        {
            if (quantity == null)
            {
                if (SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
                {
                    List<CartItem> cart = new List<CartItem>();
                    cart.Add(new CartItem { product = _context.Product.Include(p => p.category).FirstOrDefault(p => p.ProductId == id), Quantity = 1 });

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
                else
                {
                    List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
                    int index = isExist(id);
                    if (index != -1)
                    {
                        cart[index].Quantity++;
                    }
                    else
                    {
                        cart.Add(new CartItem { product = _context.Product.Include(p => p.category).FirstOrDefault(p => p.ProductId == id), Quantity = 1 });
                    }
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
            }
            else
            {
                if (SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
                {
                    List<CartItem> cart = new List<CartItem>();
                    cart.Add(new CartItem { product = _context.Product.Include(p => p.category).FirstOrDefault(p => p.ProductId == id), Quantity = Convert.ToInt32(quantity) });

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
                else
                {
                    List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
                    int index = isExist(id);
                    if (index != -1)
                    {
                        cart[index].Quantity += Convert.ToInt32(quantity);
                    }
                    else
                    {
                        cart.Add(new CartItem { product = _context.Product.Include(p => p.category).FirstOrDefault(p => p.ProductId == id), Quantity = Convert.ToInt32(quantity) });
                    }
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
            }
            return Json("Success");
        }

        [Route("Remove")]
        [HttpPost]
        public IActionResult Remove(string id)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return Json("Success");
        }

        [Route("RemoveAll")]
        [HttpPost]
        public IActionResult RemoveAll(string[] arrayId)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            //foreach(string id in arrayId)
            //{
            //    int index = isExist(id);
            //    cart.RemoveAt(index);
            //}
            cart.RemoveAll(x => x.Quantity != 0);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return Json("Success");
        }

        [Route("Updatecart")]
        [HttpPost]
        public IActionResult UpdateCart(string data)
        {
            UpdateCartViewModel[] result = JsonConvert.DeserializeObject<UpdateCartViewModel[]>(data);
            for (int i = 0; i < result.Length; i++)
            {
                List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
                int index = isExist(result[i].Id);
                string id = result[i].Id;
                if (index != -1)
                {
                    cart[index].Quantity = Convert.ToInt32(result[i].Quantity);
                }
                else
                {
                    cart.Add(new CartItem { product = _context.Product.FirstOrDefault(p => p.ProductId == id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return Json(result.Length);
        }

        private int isExist(string id)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].product.ProductId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        [Route("Checkout")]
        public async Task<IActionResult> Checkout(CheckoutViewModel checkoutViewModel)
        {
            checkoutViewModel.cartItem = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            checkoutViewModel.payPalConfig = PayPalService.GetPayPalConfig();
            if (checkoutViewModel.cartItem == null)
            {
                return RedirectToAction("Cart");
            }
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                checkoutViewModel.BillCheckout = new BillViewModel();
                checkoutViewModel.BillCheckout.CustomerName = user.Fullname;
                checkoutViewModel.BillCheckout.CustomerEmail = user.Email;
                checkoutViewModel.BillCheckout.CustomerAddress = user.Address;
                checkoutViewModel.BillCheckout.CustomerPhone = user.PhoneNumber;
            }
            return View(checkoutViewModel);
        }

        [Route("Checkout")]
        [HttpPost]
        public IActionResult Checkvalid(CheckoutViewModel checkoutViewModel)
        {
            checkoutViewModel.cartItem = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            checkoutViewModel.payPalConfig = PayPalService.GetPayPalConfig();
            var conf = PayPalService.GetPayPalConfig();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "billInfo", checkoutViewModel.BillCheckout);

            string uriSetting = "cmd=_cart" +
                                 $"&business={conf.Business}" +
                                 "&upload=1" +
                                 $"&return={conf.ReturnUrl}" +
                                 $"&cancel_return={Hosting.Name}/Checkout/Cancel" +
                                 "&no_shipping=1";
            string uriCart = "";
            int i = 1;
            double sum = 0;
            foreach (var item in checkoutViewModel.cartItem)
            {
                var priceConvert = item.product.DiscountPrice;
                
                uriCart += $"&item_number_{i}={i}" +
                           $"&item_name_{i}={item.product.ProductName}" +
                           $"&amount_{i}={priceConvert}" +
                           $"&quantity_{i}={item.Quantity}";
                sum += priceConvert * item.Quantity;
                i++;
            }

            ////Shipping
            uriCart += $"&item_number_{i}={i}" +
                        $"&item_name_{i}=Shipping Fee" +
                        $"&amount_{i}={2}" +
                        $"&quantity_{i}=1";
            //i++;

            //var discount = checkoutViewModel.cartItem.Sum(x => x.product.DiscountPrice * x.Quantity) * 0.00004;
            //discount = discount * 0.1;

            ////Discount
            //uriCart += $"&item_number_{i}={i}" +
            //            $"&item_name_{i}=Discount" +
            //            $"&amount_{i}={discount}" +
            //            $"&quantity_{i}=1";
            
            if (ModelState.IsValid)
            {
                return Redirect($"{checkoutViewModel.payPalConfig.PostUrl}?{uriSetting}{uriCart}");                
            }
            return View("checkout", checkoutViewModel);
            }

        [Route("Checkout/Success")]
        public async Task<IActionResult> Success(CheckoutViewModel checkoutViewModel)
        {
            var result = PDTHolder.Success(Request.Query["tx"].ToString());
            checkoutViewModel.cartItem = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            checkoutViewModel.BillCheckout = SessionHelper.GetObjectFromJson<BillViewModel>(HttpContext.Session, "billInfo");

            if (checkoutViewModel.BillCheckout == null)
            {
                return NotFound();
            }

            var currentBill = _mapper.Map<Bill>(checkoutViewModel.BillCheckout);
            if (_signInManager.IsSignedIn(User))
            {
                var userId = _userManager.GetUserId(User);
                currentBill.AccountId = userId;
                var userUpdateMoney = await _userManager.FindByIdAsync(userId);
                var amount = checkoutViewModel.cartItem.Sum(x => x.product.DiscountPrice * x.Quantity) + Convert.ToDouble(userUpdateMoney.MoneySpended);
                userUpdateMoney.MoneySpended = amount;
                var resultUpdate = await _userManager.UpdateAsync(userUpdateMoney);
            }

            await _context.Bill.AddAsync(currentBill);
            var addedBill = await _context.SaveChangesAsync();

            if (addedBill > 0)
            {
                List<BillDetails> newDetail = new List<BillDetails>();
                foreach (var item in checkoutViewModel.cartItem)
                {
                    var temp = _mapper.Map<BillDetails>(item);
                    temp.BillId = currentBill.BillId;
                    newDetail.Add(temp);
                }

                await _context.BillDetails.AddRangeAsync(newDetail);
                var addedBillDetail = await _context.SaveChangesAsync();

                SessionHelper.RemoveSession(HttpContext.Session, "cart");
                SessionHelper.RemoveSession(HttpContext.Session, "billInfo");
            }

            return View(checkoutViewModel);
        }

        [Route("Checkout/Cancel")]
        public async Task<IActionResult> Cancel(CheckoutViewModel checkoutViewModel)
        {
            checkoutViewModel.cartItem = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            checkoutViewModel.BillCheckout = SessionHelper.GetObjectFromJson<BillViewModel>(HttpContext.Session, "billInfo");

            if (checkoutViewModel.BillCheckout == null)
            {
                return NotFound();
            }

            var currentBill = _mapper.Map<Bill>(checkoutViewModel.BillCheckout);
            if (_signInManager.IsSignedIn(User))
            {
                var userId = _userManager.GetUserId(User);
                currentBill.AccountId = userId;
            }
            currentBill.Status = false;
            await _context.Bill.AddAsync(currentBill);
            var addedBill = await _context.SaveChangesAsync();

            if (addedBill > 0)
            {
                List<BillDetails> newDetail = new List<BillDetails>();
                foreach (var item in checkoutViewModel.cartItem)
                {
                    var temp = _mapper.Map<BillDetails>(item);
                    temp.BillId = currentBill.BillId;
                    newDetail.Add(temp);
                }

                await _context.BillDetails.AddRangeAsync(newDetail);
                var addedBillDetail = await _context.SaveChangesAsync();

                SessionHelper.RemoveSession(HttpContext.Session, "billInfo");
            }

            return RedirectToAction("index","home");
        }
    }
}
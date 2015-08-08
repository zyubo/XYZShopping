using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XYZShopping.Models;
using XYZShopping.Models.Business;
using XYZShopping.Models.Patterns;
using XYZShopping.Models.Data;
using System.Web.Security;
using System.Web.Routing;
using System.Threading;

namespace XYZShopping.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }
        public IDataAccess ida = null;
        public MembershipProvider MembershipProvider = null;

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(MembershipProvider); }
            base.Initialize(requestContext);
        }

        ProductModel cm = new ProductModel();
        ProductModel pm = new ProductModel();
        ProductModel cartItems = new ProductModel();
        OrderModel orderItemsView = new OrderModel();
        public HomeController()
        {
            //cm.Title = "book3";
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserModels model, string returnUrl)
        {
            UserModels theUser = new UserModels();
            IBusinessAuthentication ibau = GenericFactory<ShoppingBusiness, IBusinessAuthentication>.CreateInstance();
            if (ModelState.IsValid)
            {
                if (ibau.IsValidUserBusiness(model.Username, model.Password) != "")
                {
                    theUser.UserTable = ibau.GetUserBussiness(model.Username);
                    SessionFacade.USERNAME = theUser.UserTable.Rows[0][0].ToString();
                    SessionFacade.EMAIL = theUser.UserTable.Rows[0][1].ToString();
                    SessionFacade.PASSWORD = theUser.UserTable.Rows[0][2].ToString();
                    FormsService.SignIn(model.Username, model.RememberMe);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        //return RedirectToAction("Index");
                        //ViewBag.Message = "Login successful..";
                        return RedirectToAction("Index", "Home");
                        //if (SessionFacade.PAGEREQUESTED != null)
                        //    Response.Redirect(SessionFacade.PAGEREQUESTED);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsService.SignOut();
            SessionFacade.setNullToAll();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModels model, string returnUrl)
        {
            IBusinessAuthentication ibau = GenericFactory<ShoppingBusiness, IBusinessAuthentication>.CreateInstance();
            if (ModelState.IsValid)
            {
                if (ibau.RegisterBusiness(model.Username, model.Email, model.NewPassword))
                {
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        //return RedirectToAction("Index");
                        //ViewBag.Message = "Login successful..";
                        return RedirectToAction("Index", "Home");
                        //if (SessionFacade.PAGEREQUESTED != null)
                        //    Response.Redirect(SessionFacade.PAGEREQUESTED);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Register not successful.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //change password
        public ActionResult Account()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Account(UserModels model, string returnUrl)
        {
            if (SessionFacade.USERNAME == null)
                return RedirectToAction("LogIn", "Home", new { ReturnUrl = "~/Home/Account" });
            else
            {
                IBusinessAuthentication ibau = GenericFactory<ShoppingBusiness, IBusinessAuthentication>.CreateInstance();
                if (ModelState.IsValid)
                {
                    if (ibau.ChangePasswordBusiness(SessionFacade.USERNAME, model.Password, model.NewPassword))
                    {
                        if (!String.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            //return RedirectToAction("Index");
                            //ViewBag.Message = "Login successful..";
                            return RedirectToAction("Index", "Home");
                            //if (SessionFacade.PAGEREQUESTED != null)
                            //    Response.Redirect(SessionFacade.PAGEREQUESTED);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password changing not successful.");
                    }
                }

                // If we got this far, something failed, redisplay form
                return View(model);
            }
        }

        //Home
        //display: all product name and summary
        //Database: select * from product
        //link: to ShowDetails after each item

        public ActionResult Index()
        {
            //ViewData["Message"] = "欢迎使用 ASP.NET MVC!";
            ProductModel allProducts = new ProductModel();
            IBusinessAccount ibac = GenericFactory<ShoppingBusiness, IBusinessAccount>.CreateInstance();
            if (ModelState.IsValid)
            {
                allProducts.ProductTable = ibac.ViewAllProductBussiness();
                if (allProducts.ProductTable == null)
                {
                    ModelState.AddModelError("", "Retrieving products not successful.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(allProducts);
        }

        //display: details of one product. 
        //Database: select from product
        //button: addCart
        //link: ViewCart
        public ActionResult ViewProduct()
        {
            return View();
        }

        //display: all products in gridview
        //Database: bind db to gridwiew
        //Button: update and delete (for each row)
        //link: direct to AddProduct
        public ActionResult Control()
        {
            if (SessionFacade.USERNAME != "admin")
                return RedirectToAction("LogIn", "Home", new { ReturnUrl = "~/Home/Control" });
            else
            {
                ProductModel allProducts = new ProductModel();
                IBusinessAccount ibac = GenericFactory<ShoppingBusiness, IBusinessAccount>.CreateInstance();
                if (ModelState.IsValid)
                {
                    allProducts.ProductTable = ibac.ViewAllProductBussiness();
                    if (allProducts.ProductTable == null)
                    {
                        ModelState.AddModelError("", "Retrieving products not successful.");
                    }
                }

                // If we got this far, something failed, redisplay form
                return View(allProducts);
            }
        }
        public ActionResult DeleteProduct() 
        { 
            return View(); 
        }
        [HttpPost]
        public ActionResult DeleteProduct(FormCollection collection)
        {
            int productId = int.Parse(collection["ProductID"]);
            IBusinessAccount ibac = GenericFactory<ShoppingBusiness, IBusinessAccount>.CreateInstance();
            if (ModelState.IsValid)
            {
                if (ibac.DeleteProductBussiness(productId))
                {
                    return RedirectToAction("Control", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Adding product not successful.");
                }
            }

            // If we got this far, something failed, redisplay form
            return RedirectToAction("Control", "Home");
        }

        //[HttpPost]
        //public ActionResult EditProduct(ProductModel model)
        //{
            
        //}

        [HttpPost]
        public ActionResult EditProduct(FormCollection collection)
        {
            if (SessionFacade.USERNAME != "admin")
                return RedirectToAction("LogIn", "Home", new { ReturnUrl = "~/Home/EditProduct" });
            else
            {
                int productId = int.Parse(collection["ProductID"]);
                //SessionFacade.PRODUCTID = productId;
                ProductModel productToEdit = new ProductModel();
                IBusinessAccount ibac = GenericFactory<ShoppingBusiness, IBusinessAccount>.CreateInstance();
                if (ModelState.IsValid)
                {
                    productToEdit.ProductTable = ibac.ViewProductBussiness(productId);
                    if (productToEdit.ProductTable == null)
                    {
                        ModelState.AddModelError("", "Retrieving products not successful.");
                    }
                    productToEdit.Id = (int)productToEdit.ProductTable.Rows[0][0];
                    productToEdit.Title = (string)productToEdit.ProductTable.Rows[0][1];
                    productToEdit.Available = (int)productToEdit.ProductTable.Rows[0][2];
                    productToEdit.Price = (float)(double)productToEdit.ProductTable.Rows[0][3];
                    productToEdit.Image = (string)productToEdit.ProductTable.Rows[0][4];
                    productToEdit.Summary = (string)productToEdit.ProductTable.Rows[0][5];
                    productToEdit.Details = (string)productToEdit.ProductTable.Rows[0][6];
                }
                return View(productToEdit);
            }
        }

        [HttpPost]
        public ActionResult SaveProduct(FormCollection collection)
        {
            //int productId = int.Parse(collection["ProductID"]);
            //SessionFacade.PRODUCTID = productId;
            ProductModel productToSave = new ProductModel();
            productToSave.Id = int.Parse(collection["Id"]);
            productToSave.Title = collection["Title"];
            productToSave.Available = int.Parse(collection["Available"]);
            productToSave.Price = float.Parse(collection["Price"]);
            productToSave.Image = collection["Image"];
            productToSave.Summary = collection["Summary"];
            productToSave.Details = collection["Details"];
            IBusinessAccount ibac = GenericFactory<ShoppingBusiness, IBusinessAccount>.CreateInstance();
            if (ModelState.IsValid)
            {
                if (ibac.AddProductBussiness(productToSave.Id, productToSave.Title, productToSave.Available, (float)productToSave.Price, productToSave.Image, productToSave.Summary, productToSave.Details))
                {
                    return RedirectToAction("Control", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Adding product not successful.");
                }
            }
            return RedirectToAction("Control", "Home");
        }

        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductModel model, string returnUrl)
        {
            if (SessionFacade.USERNAME != "admin")
                return RedirectToAction("LogIn", "Home", new { ReturnUrl = "~/Home/AddProduct" });
            else
            {
                IBusinessAccount ibac = GenericFactory<ShoppingBusiness, IBusinessAccount>.CreateInstance();
                if (ModelState.IsValid)
                {
                    if (ibac.AddProductBussiness(model.Id, model.Title, model.Available, (float)model.Price, model.Image, model.Summary, model.Details))
                    {
                        if (!String.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            //return RedirectToAction("Index");
                            //ViewBag.Message = "Login successful..";
                            return RedirectToAction("Control", "Home");
                            //if (SessionFacade.PAGEREQUESTED != null)
                            //    Response.Redirect(SessionFacade.PAGEREQUESTED);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Adding product not successful.");
                    }
                }

                // If we got this far, something failed, redisplay form
                return View(model);
            }
        }

        //Cart
        //display: title summary image price, pcount. 
        //Database: join PRODUCT and CART.
        //link: CheckOut
        //DropDown: change count
        //Button: delete item, make editable, save changes
        public ActionResult ViewCart() 
        {
            if (SessionFacade.USERNAME == null)
                return RedirectToAction("LogIn", "Home", new { ReturnUrl = "~/Home/ViewCart" });
            else
            {
                ProductModel getCart = new ProductModel();
                float result = 0;
                IBusinessAccount ibac = GenericFactory<ShoppingBusiness, IBusinessAccount>.CreateInstance();
                if (ModelState.IsValid)
                {
                    getCart.ProductTable = ibac.ViewCartBussiness(SessionFacade.EMAIL, ref result);
                    if (getCart.ProductTable.Rows.Count != 0)
                        SessionFacade.TOTAL = float.Parse(getCart.ProductTable.Rows[0][6].ToString());
                    else
                        SessionFacade.TOTAL = 0;
                    if (getCart.ProductTable == null)
                    {
                        ModelState.AddModelError("", "Retrieving products not successful.");
                    }
                }

                // If we got this far, something failed, redisplay form
                return View(getCart);
            }
        }

        [HttpPost]
        public ActionResult AddCart(FormCollection collection)
        {
            //string str = collection["ProductID"];
            //string str2 = collection["Pcount"];
            int productId = int.Parse(collection["ProductID"]);
            int productCount = int.Parse(collection["Pcount"]); //from dropdown
            IBusinessAccount ibac = GenericFactory<ShoppingBusiness, IBusinessAccount>.CreateInstance();
            if (ModelState.IsValid)
            {
                if (ibac.AddCartBussiness(SessionFacade.EMAIL, productId, productCount))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Adding to cart not successful.");
                }
            }

            // If we got this far, something failed, redisplay form
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult EditCart(FormCollection collection)
        {
            if (SessionFacade.USERNAME == null)
                return RedirectToAction("LogIn", "Home", new { ReturnUrl = "~/Home/EditCart" });
            else
            {
                int productId = int.Parse(collection["ProductID"]);
                //SessionFacade.PRODUCTID = productId;
                ProductModel cartToEdit = new ProductModel();
                float result = 0;
                IBusinessAccount ibac = GenericFactory<ShoppingBusiness, IBusinessAccount>.CreateInstance();
                if (ModelState.IsValid)
                {
                    cartToEdit.ProductTable = ibac.ViewCartBussiness(SessionFacade.EMAIL, ref result);
                    if (cartToEdit.ProductTable == null)
                    {
                        ModelState.AddModelError("", "Retrieving products not successful.");
                    }
                    cartToEdit.Title = (string)cartToEdit.ProductTable.Rows[0][0];
                    cartToEdit.Pcount = (int)cartToEdit.ProductTable.Rows[0][4];
                    cartToEdit.Id = productId;
                }
                return View(cartToEdit);
            }
        }

        [HttpPost]
        public ActionResult DeleteCart(FormCollection collection)
        {
            int productId = int.Parse(collection["ProductID"]);
            IBusinessAccount ibac = GenericFactory<ShoppingBusiness, IBusinessAccount>.CreateInstance();
            if (ModelState.IsValid)
            {
                if (ibac.DeleteCartBussiness(SessionFacade.EMAIL, productId))
                {
                    return RedirectToAction("ViewCart", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Deleting from cart not successful.");
                }
            }

            // If we got this far, something failed, redisplay form
            return RedirectToAction("ViewCart", "Home");
        }

        [HttpPost]
        public ActionResult SaveCart(FormCollection collection)
        {
            ProductModel cartToSave = new ProductModel();
            cartToSave.Id = int.Parse(collection["Id"]);
            cartToSave.Pcount = int.Parse(collection["Pcount"]);
            IBusinessAccount ibac = GenericFactory<ShoppingBusiness, IBusinessAccount>.CreateInstance();
            if (ModelState.IsValid)
            {
                if (ibac.EditCartBussiness(SessionFacade.EMAIL, cartToSave.Id, cartToSave.Pcount))
                {
                    return RedirectToAction("ViewCart", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Adding product not successful.");
                }
            }
            return RedirectToAction("ViewCart", "Home");
        }

        //display: cart items, total price
        //link: payment information, direct to CheckOutPayment
        public ActionResult CheckOutView()
        {
            if (SessionFacade.USERNAME == null)
                return RedirectToAction("LogIn", "Home", new { ReturnUrl = "~/Home/CheckOutView" });
            else
            {
                ProductModel getCart = new ProductModel();
                float result = 0;
                IBusinessAccount ibac = GenericFactory<ShoppingBusiness, IBusinessAccount>.CreateInstance();
                if (ModelState.IsValid)
                {
                    getCart.ProductTable = ibac.ViewCartBussiness(SessionFacade.EMAIL, ref result);
                    if (getCart.ProductTable.Rows.Count != 0)
                        SessionFacade.TOTAL = float.Parse(getCart.ProductTable.Rows[0][6].ToString());
                    else
                    {
                        SessionFacade.TOTAL = 0;
                        Response.Write("<script language='javascript'>alert('Please choose you product first!')</script>");
                        Response.Write("<meta http-equiv='refresh' content='0.0;url=Index'>");
                        //return RedirectToAction("Index", "Home");
                        //Thread.Sleep(3);
                    }
                    if (getCart.ProductTable == null)
                    {
                        ModelState.AddModelError("", "Retrieving products not successful.");
                    }
                }

                // If we got this far, something failed, redisplay form
                return View(getCart);
            }
        }

        //TextBox: collect user payment information to save into session["PAYMENT"]. 
        //link: next step, direct to CheckOutConfirm
        public ActionResult CheckOutPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckOutPayment(OrderModel model, string returnUrl)
        {
            if (SessionFacade.USERNAME == null)
                return RedirectToAction("LogIn", "Home", new { ReturnUrl = "~/Home/CheckOutView" });
            else
            {
                string str = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                int i1 = int.Parse(DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString());
                SessionFacade.ORDER = new OrderModel();
                SessionFacade.ORDER.Orderid = int.Parse(DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString());
                SessionFacade.ORDER.Address = model.Address;
                SessionFacade.ORDER.Cardnum = model.Cardnum;
                return RedirectToAction("CheckOutConfirm", "Home");
            }
        }

        //display: user email, name, address, cardNUM. 
        //Database: insert when click
        //display order id, "Thank you!" and hide confirm button after click
        public ActionResult CheckOutConfirm()
        {
            OrderModel confirmOrder = new OrderModel();
            confirmOrder.Email = SessionFacade.EMAIL;
            confirmOrder.Orderid = SessionFacade.ORDER.Orderid;
            confirmOrder.Address = SessionFacade.ORDER.Address;
            confirmOrder.Cardnum = SessionFacade.ORDER.Cardnum;
            confirmOrder.Arrive = "Arrive in 2 days";
            confirmOrder.Total = SessionFacade.TOTAL;
            return View(confirmOrder);
        }

        [HttpPost]
        public ActionResult CheckOutConfirm(OrderModel model) 
        {
            if (SessionFacade.USERNAME == null)
                return RedirectToAction("LogIn", "Home", new { ReturnUrl = "~/Home/CheckOutView" });
            else
            {
                float result = 0;
                IBusinessAccount ibac = GenericFactory<ShoppingBusiness, IBusinessAccount>.CreateInstance();
                if (ModelState.IsValid)
                {
                    if (ibac.AddOrderBussiness(SessionFacade.EMAIL, SessionFacade.ORDER.Orderid, SessionFacade.ORDER.Address, SessionFacade.ORDER.Cardnum, ref result))
                    {
                        //display Transaction success notification
                        //Response.Write("<script language='javascript'>alert('Transaction success!')</script>");
                        Response.Write("<meta http-equiv='refresh' content='0.0;url=Index'>");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Transaction failed.");
                    }
                }
                //Thread.Sleep(1000);
                return Content("<script language='javascript'>alert('Transaction success!');window.location.href='Index';</script>");
            }
        }

        //display: order status, delivered or not
        public ActionResult ViewOrderStatus()
        {
            //Request.QueryString["ReturnUrl"] = "~/ViewOrderStatus.aspx";
            if (SessionFacade.EMAIL == null)
                return RedirectToAction("LogIn", "Home", new { ReturnUrl = "~/Home/ViewOrderStatus" });
            else
            {
                OrderModel allOrders = new OrderModel();
                IBusinessAccount ibac = GenericFactory<ShoppingBusiness, IBusinessAccount>.CreateInstance();
                if (ModelState.IsValid)
                {
                    allOrders.OrderTable = ibac.ViewOrderBussiness(SessionFacade.EMAIL);
                    if (allOrders.OrderTable == null)
                    {
                        ModelState.AddModelError("", "Retrieving products not successful.");
                    }
                }
                return View(allOrders);
            }
        }

        //display: company information
        public ActionResult ViewAllUsers()
        {
            //XYZShoppingEntities db = new XYZShoppingEntities();
            DataClasses1DataContext db = new DataClasses1DataContext();
            UserModels um = new UserModels();
            var results = from u in db.users
                          select new
                          {
                              username = u.username,
                              email = u.email,
                              password = u.password
                          };
            foreach (var u in results)
            {
                UserModels tmpUser = new UserModels();
                tmpUser.Username = u.username;
                tmpUser.Email = u.email;
                tmpUser.Password = u.password;
                um.UserList.Add(tmpUser);
            }


            return View(um);
        }

        //display: company information
        public ActionResult About()
        {
            return View();
        }
    }
}

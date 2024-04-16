using Microsoft.AspNetCore.Mvc;
using StoreFront.DATA.EF.Models;//Added for access to our DB context
using Microsoft.AspNetCore.Identity;//Added for access to the UserManager
using StoreFront.UI.MVC.Models;//Added for access to the CartItemViewModel
using Newtonsoft.Json;//Added for easier management of shopping cart
using System.Net.WebSockets;

namespace StoreFront.UI.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        //Fields
        private readonly DrinkStoreFrontContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        //Constructor
        public ShoppingCartController(DrinkStoreFrontContext context, UserManager<IdentityUser> userManager)
        {
            //Assignment
            _context = context;
            _userManager = userManager;
        }
        
        
        public IActionResult Index()
        {
            //Retrieve the contents from the Session shopping cart (JSON string "cart") and convert
            //them to C# using Newtonsoft.Json. After converting to C#, we can pass the collection
            //of cart contents back to the strongly-typed view to display

            //retrieve cart contents
            var sessionCart = HttpContext.Session.GetString("cart");

            //create the shell for the local (C# version) cart:
            Dictionary<int, CartItemViewModel> shoppingCart = null;

            //check to see if the session cart was null or empty
            if (sessionCart == null || sessionCart.Count() == 0)
            {
                //user either hasn't put anything in their cart, or they have removed all items 
                //set shopping cart to an empty Dictionary
                shoppingCart = new Dictionary<int, CartItemViewModel>();

                ViewBag.Message = "There are no items in your cart.";
            }
            else
            {
                ViewBag.Message = null;
                //deserialize the cart contents from JSON to C#
                shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, CartItemViewModel>>(sessionCart);
            }

            return View(shoppingCart);
        }

        public IActionResult AddToCart(int id)
        {
            //FIrst, create an empty dictionary for a LOCAL shopping cart variable
            //int (key) -> Product Id 
            //CartItemViewModel (value) -> Product and Qty
            Dictionary<int, CartItemViewModel> shoppingCart = null;

            #region Session Notes
            /*
             * Session is a tool available on the server-side that can store information for a user while they are actively using your site.
             * Typically the session lasts for 20 minutes (this can be adjusted in Program.cs).
             * Once the 20 minutes is up, the session variable is disposed.
             * 
             * Values that we can store in Session are limited to: string, int
             * - Because of this we have to get creative when trying to store complex objects (like CartItemViewModel).
             * To keep the info separated into properties we will convert the C# object to a JSON string.
             * */
            #endregion

            var sessionCart = HttpContext.Session.GetString("cart");

            //Check to see if the session object exists
            //If not, instantiate the new local connection
            if (String.IsNullOrEmpty(sessionCart))
            {
                //If the session didn't exist yet, instantiate the collection as a new object
                shoppingCart = new Dictionary<int, CartItemViewModel>();
            }
            else
            {
                //Cart already exists - transfer the existing cart items from session into our local shoppingCart
                //DeserializeObject() is a method that converts JSON to C# - we MUST tell this method which C#
                //class to convert the JSON into (in this case, Dictionary<int, CartItemViewModel>)
                shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, CartItemViewModel>>(sessionCart);
            }

            // Add newly selected products to the cart
            // Retrieve product from the DB
            Product product = _context.Products.Find(id);

            // Instantiate the CartItemViewModel object so we can add to the cart
            CartItemViewModel civm = new CartItemViewModel(1, product);//add 1 of the selected product to the cart

            //if the product was already in the cart, increase the quantity by 1
            //Else, add the new item to the cart
            if (shoppingCart.ContainsKey(product.ProductId))
            {
                //update qty
                shoppingCart[product.ProductId].Qty++;
            }
            else
            {
                shoppingCart.Add(product.ProductId, civm);
            }

            //update the session version of the cart
            //Take the local copy (shoppingCart) and serialize it as JSON
            //Then we assign that JSON string as a session value ("cart")
            string jsonCart = JsonConvert.SerializeObject(shoppingCart);
            HttpContext.Session.SetString("cart", jsonCart);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            //retrieve the vvart from
            var sessioncart = HttpContext.Session.GetString("cart");

            //convert JSON cat to C#
            Dictionary<int, CartItemViewModel> shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, CartItemViewModel>>(sessioncart);

            //remove the cart item
            shoppingCart.Remove(id);

            //if there are no remaining items in the cart, remove it from the session
            if (shoppingCart.Count == 0)
            {
                HttpContext.Session.Remove("cart");
            }
            //otherwise, update the session string with our remaining local cart contents
            else
            {
                string jsonCart = JsonConvert.SerializeObject(shoppingCart);
                HttpContext.Session.SetString("cart", jsonCart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult UpdateCart(int productId, int qty)
        {
            //retrieve the cart from session storage
            var sessionCart = HttpContext.Session.GetString("cart");

            //Deserialize from JSON to C#
            Dictionary<int, CartItemViewModel> shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, CartItemViewModel>>(sessionCart);

            //update the qty for our specific dictionary key
            shoppingCart[productId].Qty = qty;

            //update the JSON string stored in session with the new qty, then return user to Index action
            string jsonCart = JsonConvert.SerializeObject(shoppingCart);
            HttpContext.Session.SetString("cart", jsonCart);
            return RedirectToAction("Index");
        }
    }
}

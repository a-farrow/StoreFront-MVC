using StoreFront.DATA.EF.Models;

namespace StoreFront.UI.MVC.Models
{
    public class CartItemViewModel
    {
        public int Qty { get; set; }

        public Product Product { get; set; }

        //Build the constructor
        public CartItemViewModel(int qty, Product product)
        {
            //Assignment
            Qty = qty;
            Product = product;
        }
    }
}

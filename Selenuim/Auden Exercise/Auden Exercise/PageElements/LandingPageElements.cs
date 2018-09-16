using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auden_Exercise.PageElements
{
    public class LandingPageElements
    {
        public string SignInLink
        {
            get
            {
                return "//a[@class='login'][text()[contains(.,'Sign in')]]";
            }
        }

        public string ProductsContainer
        {
            get
            {
                return "homefeatured";
            }
        }

        public string ProductPrice(string price = "")
        {
            if (string.IsNullOrEmpty(price))
            {
                return "//div[@class='content_price']//span[@class='price product-price']";
            }
            else
            {
                return "//div[@class='content_price']//span[@class='price product-price'][text()[contains(.,'"+ price + "')]]";
            }
        }

        public string ProductCategory(string category)
        {
            return "//a[contains(@title, '" + category + "')][text()[contains(.,'"+ category + "')]]";
        }

        public string BtnProductView
        {
            get
            {
                return "//a[@title='View'][text()='More']";
            }
        }

        public string BtnAddToBasket
        {
            get
            {
                ////return "//button[@title='Add to cart']//span[text()[contains(.,'Add to cart')]]";
                return "//span[text()='Add to cart']";
            }
        }

        public string BtnShoppingCart
        {
            get
            {
                return "//div[@class='shopping_cart']//a";
            }
        }

        public string EmptyBasketItemCount
        {
            get
            {
                return "//span[@class='ajax_cart_no_product']";
            }
        }

        public string QuickView
        {
            get
            {
                return "//a[@class='quick-view']//span";
            }
        }

        public string ContinueShoppingButton
        {
            get
            {
                return "//span[@title='Continue shopping']//span";
            }
        }
    }
}

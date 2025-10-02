using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Utils;

namespace UI.Views
{
    public class SearchView
    {
        //public void SearchProduct()
        //{
        //    var productService = new ProductService(
        //        new ProductRepository("product.json")
        //    );
        //    int choice = 0;

        //    do
        //    {
        //        Console.WriteLine("\n1. Search product by name");
        //        Console.WriteLine("2. Search product by price range");
        //        Console.WriteLine("0. Return to main menu");
        //        choice = Inputter.Inter(
        //            "Select choice: ",
        //            0, 2,
        //            false
        //        );

        //        switch ( choice )
        //        {
        //            case 1:
        //                SearchProductByName(productService);
        //                break; 
        //            case 2:
        //                SearchProductByPriceRange(productService);
        //                break;
        //            case 0:
        //                break;
        //            default:
        //                Console.WriteLine("Invalid choice!!!");
        //                break;
        //        }
        //    }
        //    while (choice > 0 && choice < 2);
        //}

        //private void SearchProductByName(ProductService productService)
        //{
        //    string searchName = Inputter.NormalStringer(
        //        "Enter product name: ", 
        //        true
        //    );

        //    var products = productService.GetAllProductByName( searchName );

        //    if (products == null) { return; }
        //    foreach ( var product in products )
        //    {
        //        Console.WriteLine($"{product.Id} | {product.Name} | {product.Price} | {product.Stock}");
        //    }
        //}

        //private void SearchProductByPriceRange(ProductService productService)
        //{

        //    decimal minPrice = Inputter.Decimaler(
        //        "Enter min price: ", 
        //        0, decimal.MaxValue, 
        //        false
        //    );

        //    decimal maxPrice = Inputter.Decimaler(
        //        "Enter max price: ", 
        //        0, decimal.MaxValue, 
        //        false
        //    );

        //    var products = productService.GetAllProductByPriceRange(minPrice, maxPrice);

        //    if (products == null) { return; }
        //    foreach( var product in products )
        //    {
        //        Console.WriteLine($"{product.Id} | {product.Name} | {product.Price} | {product.Stock}");
        //    }
        //}
    }
}

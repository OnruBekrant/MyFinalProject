﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

internal class Program
{
    //Solid
    //Open Closed Principle
    private static void Main(string[] args)
    {
        //Data Transformation Object
        ProductTest();
        //IoC
        //CategoryTest();

    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        foreach (var category in categoryManager.GetAll())
        {
            Console.WriteLine(category.CategoryName);
        }
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        var result = productManager.GetProductDetails();

        if (result.Success == true)
        {

            foreach (var product in productManager.GetProducDetails().Data)
            {
                Console.WriteLine(product.ProductName + " / " + product.CategoryName);
            }
        }
        else { Console.WriteLine(result.Message); }
    }
}

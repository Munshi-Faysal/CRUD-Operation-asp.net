using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cold_Drinks_CURD.Models;

namespace cold_Drinks_CURD.Controllers
{
    public class CustomerController : ApiController
    {
        //GET -Retrive data
        public IHttpActionResult GetALltblColdDrinks()
        {
            IList<CustomerViewModel> products = null;
            using (var x = new dbAkijFoodEntities())

            {
                products = x.tblColdDrinks
                            .Select(c => new CustomerViewModel()
                            {
                                intColdDrinksId = c.intColdDrinksId,
                                strColdDrinksName = c.strColdDrinksName,
                                numQuantity = (decimal)c.numQuantity,
                                numUnitPrice = (decimal)c.numUnitPrice
                            }).ToList<CustomerViewModel>() ;

            if (products.Count == 0)
                {
                    return NotFound();
                }
                return Ok(products);
            }    
        }

        //POST - Insert record
        public IHttpActionResult PostNewtblColdDrinks(CustomerViewModel product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data, Please recheack");

            using (var x = new dbAkijFoodEntities())
            {
                x.tblColdDrinks.Add(new tblColdDrink()
                {
                    strColdDrinksName = product.strColdDrinksName,
                    numQuantity = (decimal)product.numQuantity,
                    numUnitPrice = (decimal)product.numUnitPrice
                });
                x.SaveChanges();
            }
            return Ok();
        }
        //PUT - Update data based on Id
        public IHttpActionResult PuttblColdDrinks(CustomerViewModel product)
        {
            if (!ModelState.IsValid)
                return BadRequest("This is invalid model, Please recheck");

            using (var x = new dbAkijFoodEntities())
            {
                var checkExistingProduct = x.tblColdDrinks.Where(c => c.intColdDrinksId == product.intColdDrinksId)
                                                          .FirstOrDefault<tblColdDrink>();
                if (checkExistingProduct != null)
                {
                    checkExistingProduct.strColdDrinksName = product.strColdDrinksName;
                    checkExistingProduct.numQuantity = product.numQuantity;
                    checkExistingProduct.numUnitPrice = product.numUnitPrice;

                    x.SaveChanges();

                }
                else
                    return NotFound();
            }
            return Ok();
        }
        //DELETE - Delete a record based on Id
       public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Please Enter valid Customer Id");
            {
                using (var x  = new dbAkijFoodEntities())
                {
                    var customer = x.tblColdDrinks
                        .Where(c => c.intColdDrinksId == id)
                        .FirstOrDefault();

                    x.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
                    x.SaveChanges();
                      
                }
                return Ok();
            }
        }
    }
}

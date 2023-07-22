using eStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eStore.Controllers
{
    public class eStoreController : ApiController
    {
        eStoreModels db = new eStoreModels();
        //Member
        [HttpGet]
        [Route("api/default/listmember")]
        public List<Models.Member> ListMember()
        {
            return db.Members.ToList();
        }
        [HttpGet]
        [Route("api/default/searchid")]
        public Models.Member GetMemberById(int memberId)
        {
            return db.Members.SingleOrDefault(mb =>  mb.MemberId == memberId);
        }
        [HttpGet]
        [Route("api/default/searchemail")]
        public Models.Member GetMemberByEmail(string email)
        {
            return db.Members.SingleOrDefault(sv => sv.Email == email);
        }
        [HttpPost]
        [Route("api/default/addmember")]
        public bool AddMember([FromBody] Models.Member member) {
            try
            {
                db.Members.Add(member);
                db.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine("Error in here", ex.Message);
                return false;
            }
        }
        [HttpPut]
        [Route("api/default/editmember")]
        public bool EditMember([FromBody] Models.Member member)
        {
            try
            {
                Models.Member old = db.Members.SingleOrDefault(mb => mb.MemberId == member.MemberId);
                old.MemberId = member.MemberId;
                old.Email = member.Email;
                old.CompanyName = member.CompanyName;
                old.City = member.City;
                old.Country = member.Country;
                old.Password = member.Password;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in here", ex.Message);
                return false;
            }
        }
        [HttpDelete]
        [Route("api/default/deletemember")]
        public bool DeleteMember(int memberId)
        {
            Models.Member mb = db.Members.SingleOrDefault(d => d.MemberId == memberId);
            if (mb != null)
            {
                db.Members.Remove(mb);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        //Product
        [HttpGet]
        [Route("api/default/listproduct")]
        public List<Models.Product> ListProduct()
        {
            return db.Products.ToList();
        }
        [HttpGet]
        [Route("api/default/searchproductname")]
        public Models.Product GetMemberByName(string productName)
        {
            return db.Products.SingleOrDefault(pn => pn.ProductName == productName);
        }
        [HttpPost]
        [Route("api/default/addproduct")]
        public bool AddProduct([FromBody] Models.Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in here", ex.Message);
                return false;
            }
        }
        [HttpPut]
        [Route("api/default/editproduct")]
        public bool EditProduct([FromBody] Models.Product product)
        {
            try
            {
                Models.Product old = db.Products.SingleOrDefault(pr => pr.ProductId == product.ProductId);
                old.ProductId = product.ProductId;
                old.ProductName = product.ProductName;
                old.weight = product.weight;
                old.UnitPrice = product.UnitPrice;
                old.UnitsInStock = product.UnitsInStock;
                
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in here", ex.Message);
                return false;
            }
        }
        [HttpDelete]
        [Route("api/default/deleteproduct")]
        public bool DeleteProduct(int productId)
        {
            Models.Product pr = db.Products.SingleOrDefault(d => d.ProductId == productId);
            if (pr != null)
            {
                db.Products.Remove(pr);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        //Order
        [HttpGet]
        [Route("api/default/listorder")]
        public List<Models.Order> ListOrder() {
            return db.Orders.ToList();
        }
        [HttpGet]
        [Route("api/default/searchorderid")]
        public Models.Order GetOrderById(int orderId) { 
            return db.Orders.SingleOrDefault(o => o.OrderId == orderId);
        }
        [HttpPost]
        [Route("api/default/addorder")]
        public bool AddOrder([FromBody] Models.Order order)
        {
            try
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in here", ex.Message);
                return false;
            }
        }
        [HttpPut]
        [Route("api/default/editorder")]
        public bool EditOrder([FromBody] Models.Order order)
        {
            try
            {
                Models.Order old = db.Orders.SingleOrDefault(o => o.OrderId == order.OrderId);
                old.OrderId = order.OrderId;
                old.MemberId = order.MemberId;
                old.OrderDate = order.OrderDate;
                old.Required = order.Required;
                old.ShippedDate = order.ShippedDate;
                old.Freight = order.Freight;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in here", ex.Message);
                return false;
            }
        }
        [HttpDelete]
        [Route("api/default/deleteorder")]
        public bool DeleteOrder(int orderId)
        {
            Models.Order or = db.Orders.SingleOrDefault(o => o.OrderId == orderId);
            if (or != null)
            {
                db.Orders.Remove(or);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        //Member user
        [Route("api/default/searchmemberbyemail")]
        public Models.Member GetEmailByEmail(string email)
        {
            return db.Members.SingleOrDefault(m => m.Email == email);
        }
    }
}

﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [ApiController]
    public class eStoreController : ControllerBase
    {
        eStoreContext _context;
        public eStoreController(eStoreContext context) 
        {
            _context = context;
        }

        //Member
        [HttpGet]
        [Route("api/default/listmember")]
        public List<Models.Member> ListMember()
        {
            return _context.Members.ToList();
        }
        [HttpGet]
        [Route("api/default/searchid")]
        public Models.Member GetMemberById(int memberId)
        {
            return _context.Members.SingleOrDefault(mb => mb.MemberId == memberId);
        }
        [HttpGet]
        [Route("api/default/searchemail")]
        public Models.Member GetMemberByEmail(string email)
        {
            return _context.Members.SingleOrDefault(sv => sv.Email == email);
        }
        [HttpPost]
        [Route("api/default/addmember")]
        public bool AddMember([FromBody] Models.Member member)
        {
            try
            {
                _context.Members.Add(member);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
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
                Models.Member old = _context.Members.SingleOrDefault(mb => mb.MemberId == member.MemberId);
                old.MemberId = member.MemberId;
                old.Email = member.Email;
                old.CompanyName = member.CompanyName;
                old.City = member.City;
                old.Country = member.Country;
                old.Password = member.Password;
                _context.SaveChanges();
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
            Models.Member mb = _context.Members.SingleOrDefault(d => d.MemberId == memberId);
            if (mb != null)
            {
                _context.Members.Remove(mb);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        //Product
        [HttpGet]
        [Route("api/default/listproduct")]
        public List<Models.Product> ListProduct()
        {
            return _context.Products.ToList();
        }
        [HttpGet]
        [Route("api/default/searchproductname")]
        public Models.Product GetMemberByName(string productName)
        {
            return _context.Products.SingleOrDefault(pn => pn.ProductName == productName);
        }
        [HttpPost]
        [Route("api/default/addproduct")]
        public bool AddProduct([FromBody] Models.Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
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
                Models.Product old = _context.Products.SingleOrDefault(pr => pr.ProductId == product.ProductId);
                old.ProductId = product.ProductId;
                old.ProductName = product.ProductName;
                old.Weight = product.Weight;
                old.UnitPrice = product.UnitPrice;
                old.UnitsInStock = product.UnitsInStock;

                _context.SaveChanges();
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
            Models.Product pr = _context.Products.SingleOrDefault(d => d.ProductId == productId);
            if (pr != null)
            {
                _context.Products.Remove(pr);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        //Order
        [HttpGet]
        [Route("api/default/listorder")]
        public List<Models.Order> ListOrder()
        {
            return _context.Orders.ToList();
        }
        [HttpGet]
        [Route("api/default/searchorderid")]
        public Models.Order GetOrderById(int orderId)
        {
            return _context.Orders.SingleOrDefault(o => o.OrderId == orderId);
        }
        [HttpPost]
        [Route("api/default/addorder")]
        public bool AddOrder([FromBody] Models.Order order)
        {
            try
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
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
                Models.Order old = _context.Orders.SingleOrDefault(o => o.OrderId == order.OrderId);
                old.OrderId = order.OrderId;
                old.MemberId = order.MemberId;
                old.OrderDate = order.OrderDate;
                old.Required = order.Required;
                old.ShippedDate = order.ShippedDate;
                old.Freight = order.Freight;

                _context.SaveChanges();
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
            Models.Order or = _context.Orders.SingleOrDefault(o => o.OrderId == orderId);
            if (or != null)
            {
                _context.Orders.Remove(or);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        //Member user
        [HttpGet]
        [Route("api/default/searchmemberbyemail/{email}/{password}")]
        public Models.Member GetEmailByEmail(string email, string password)
        {
            return _context.Members.SingleOrDefault(m => m.Email == email && m.Password == password);
        }
    }
}

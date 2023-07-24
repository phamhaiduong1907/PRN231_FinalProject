using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using Server.Models.DTO;

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

        [HttpDelete]
        [Route("api/default/product/{productId}")]
        public Models.Product GetProductById(int productId)
        {
            Models.Product pr = _context.Products.SingleOrDefault(d => d.ProductId == productId);
            
            return pr;
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

        [HttpPost]
        [Route("api/default/addtocart")]
        public bool AddToCart(List<CartDTO> carts)
        {
            if(!ModelState.IsValid) 
                return false;
            _context.Carts.AddRange(carts.Select(c => new Cart
            {
                MemberId = c.MemberId,
                ProductId = c.ProductId,
                Quantity = c.Quantity
            }).ToList());
            return _context.SaveChanges() > 0;
        }

        [HttpPut]
        [Route("api/default/updatecart")]
        public bool UpdateCart(List<CartDTO> carts)
        {
            if(!ModelState.IsValid)
                return false;
            //List<(int, int)> cartInfos = carts.Select(c => (c.MemberId, c.ProductId)).ToList();
            //List<Cart> cartsToUpdate = _context.Carts.Where(c => cartInfos.Contains(new (c.MemberId, c.ProductId))).ToList();
            try
            {
                List<Cart> cartsToUpdate = _context.Carts
                .Where(c => carts.Select(ca => ca.MemberId).Contains(c.MemberId)
                && carts.Select(ca => ca.ProductId).Contains(c.ProductId))
                .ToList();
                for (int i = 0; i < cartsToUpdate.Count; i++)
                {
                    cartsToUpdate[i].Quantity = carts[i].Quantity;
                }
                _context.Carts.UpdateRange(cartsToUpdate);
                return _context.SaveChanges() > 0;
            }
            catch(Exception ex) 
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("api/default/removefromcart")]
        public bool RemoveFromCart([FromBody]List<CartDTO> carts)
        {
            if (!ModelState.IsValid)
                return false;
            try
            {
                List<Cart> cartsToDelete = _context.Carts
                .Where(c => carts.Select(ca => ca.MemberId).Contains(c.MemberId)
                && carts.Select(ca => ca.ProductId).Contains(c.ProductId))
                .ToList();
                for (int i = 0; i < cartsToDelete.Count; i++)
                {
                    cartsToDelete[i].Quantity = carts[i].Quantity;
                }
                _context.Carts.RemoveRange(cartsToDelete);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("api/default/getcart/{memberid}")]
        public async Task<IEnumerable<object>> GetMemberCart(int memberid)
        {
            var carts = await _context.Carts
                .Include(c => c.Product)
                .Where(c => c.MemberId == memberid)
                .Select(c => new 
                {
                    MemberId = c.MemberId,
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    Product = new { ProductId = c.ProductId, ProductName = c.Product.ProductName }
                }).ToListAsync();
            
            return carts;
        }

    }
}

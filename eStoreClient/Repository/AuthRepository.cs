using eStoreClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStoreClient.Repository
{
    public class AuthRepository : IAuthRepository
    {
        eStoreModel1 db = new eStoreModel1();
        public Models.Member CheckLogin(string username, string password) => db.Members.SingleOrDefault(x => x.Email.Equals(username) && x.Password.Equals(password));
    }
}

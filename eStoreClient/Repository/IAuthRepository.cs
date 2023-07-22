using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStoreClient.Repository
{
    public interface IAuthRepository
    {
         Models.Member CheckLogin(string username, string password);
    }
}

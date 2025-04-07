using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
     public interface ITokenHelper
     {
         AccessToken CreateToken<TUser>(TUser user, List<Title> operationClaims) where TUser : IAuth;
     }
}

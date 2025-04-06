using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Manager> ManagerRegister(UserForRegisterDto managerForRegisterDto, string password);
        IDataResult<Manager> ManagerLogin(UserForLoginDto userForLoginDto);

        IDataResult<Parent> ParentRegister(UserForRegisterDto parentForRegisterDto, string password);
        IDataResult<Parent> ParentLogin(UserForLoginDto userForLoginDto);

        IResult UserExists(string email, string userType);
        IDataResult<AccessToken> CreateAccessToken(Manager manager);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager:IAuthService
    {
        IParentService _parentService;
        ITokenHelper _tokenHelper;
        IManagerService _managerService;
        ITitleService _titleService;

        public AuthManager(IParentService parentService, ITokenHelper token
            , IManagerService managerService, ITitleService titleService)
        {
            _managerService = managerService;
            _parentService = parentService;
            _tokenHelper = token;
            _titleService = titleService;
        }


        public IDataResult<Manager> ManagerRegister(UserForRegisterDto managerForRegisterDto, string password)
        {
            var emailCheck = UserExists(managerForRegisterDto.Mail, "Manager");
            if (!emailCheck.Success)
            {
                return new ErrorDataResult<Manager>(emailCheck.Message);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash, out passwordSalt);
            CktDbContext dbContext = new CktDbContext();
            var title = dbContext.Titles.Where(x => x.TitleName == managerForRegisterDto.TitleName).FirstOrDefault();
            var manager = new Manager()
            {
                FirstName = managerForRegisterDto.FirstName,
                LastName = managerForRegisterDto.LastName,
                Email = managerForRegisterDto.Mail,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Phone = managerForRegisterDto.Phone,
                TitleId = title.Id,
                Statu = true
            };
            var result = _managerService.Add(manager);
            if (result.Success)
            {
                return new SuccessDataResult<Manager>(manager, result.Message);
            }

            return new ErrorDataResult<Manager>(result.Message);
        }

        public IDataResult<Manager> ManagerLogin(UserForLoginDto userForLoginDto)
        {
            var emailCheck = _managerService.GetManagerByMail(userForLoginDto.Email);
            if (!emailCheck.Success)
            {
                return new ErrorDataResult<Manager>("Kullanıcı Kayıtlı Değil");
            }



            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, emailCheck.Data.PasswordHash,
                    emailCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<Manager>(Messages.PasswordError);
            }

            return new SuccessDataResult<Manager>(emailCheck.Data, Messages.SuccessfullLogin);
        }

        public IDataResult<Parent> ParentRegister(UserForRegisterDto parentForRegisterDto, string password)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Parent> ParentLogin(UserForLoginDto userForLoginDto)
        {
            throw new NotImplementedException();
        }

        public IResult UserExists(string email, string userType)
        {
            if (userType=="Manager")
            {
                var managerResult = _managerService.GetManagerByMail(email);
                if (managerResult.Success)
                {
                    return new ErrorResult( "Bu Mail İle Kayıtlı Bir Yönetici Mevcut!");
                }
            }
            else if (userType=="Parent")
            {
                var parentResult = _parentService.GetParentByMail(email);
                if (parentResult.Success)
                {
                    return new ErrorResult("Bu Mail İle Kayıtlı Bir Veli Mevcut!");
                }
            }

            return new SuccessResult();


        }

        public IDataResult<AccessToken> CreateAccessToken(Manager manager)
        {
            var claims = _managerService.GetTitle(manager);
            var accessToken = _tokenHelper.CreateToken(manager, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

    }
}

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
            var emailCheck = UserExists(managerForRegisterDto.Email, "Manager");
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
                Email = managerForRegisterDto.Email,
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
            var emailCheck = UserExists(parentForRegisterDto.Email, "Parent");
            if (!emailCheck.Success)
            {
                return new ErrorDataResult<Parent>(emailCheck.Message);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var parent = new Parent
            {
                FirstName = parentForRegisterDto.FirstName,
                LastName = parentForRegisterDto.LastName,
                Email = parentForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Phone = parentForRegisterDto.Phone,
                Statu = true,
            };
            var result = _parentService.Add(parent);
            if (result.Success)
            {
                return new SuccessDataResult<Parent>(parent, result.Message);
            }

            return new ErrorDataResult<Parent>(result.Message);

        }

        public IDataResult<Parent> ParentLogin(UserForLoginDto userForLoginDto)
        {
            var emailCheck = _parentService.GetParentByMail(userForLoginDto.Email);
            if (!emailCheck.Success)
            {
                return new ErrorDataResult<Parent>("Kullanıcı Kayıtlı Değil");
            }



            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, emailCheck.Data.PasswordHash,
                    emailCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<Parent>(Messages.PasswordError);
            }

            return new SuccessDataResult<Parent>(emailCheck.Data, Messages.SuccessfullLogin);
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

        public IDataResult<AccessToken> CreateAccessToken<TUser>(TUser user, string userType)where TUser:IAuth
        {
            if (userType=="Manager")
            {
                var manager= user as Manager;
                var claims = _managerService.GetTitle(manager);
                var accessToken = _tokenHelper.CreateToken(user, claims);
                return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
            }
            else if (userType == "Parent")
            {
                var claims = new List<Title>
                {
                    new Title
                    {
                        Id = 1,
                        TitleName = "Parent"
                    }
                };
                var accessToken = _tokenHelper.CreateToken(user, claims);
                return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
            }

            return new ErrorDataResult<AccessToken>();
        }

    }
}

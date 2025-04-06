using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.DTOs
{
    public class ManagerDetailsDto:IDto,IAuth
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string UserType => Title;
        public string Phone { get; set; }
        public string Title { get; set; }
        public bool Statu { get; set; }
    }
}

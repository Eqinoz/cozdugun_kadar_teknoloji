﻿namespace Core.Entities.Concrete
{
    public class Manager:IEntity,IAuth
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Phone { get; set; }
        public int TitleId { get;set; }
        public bool Statu { get; set; }
    }
}

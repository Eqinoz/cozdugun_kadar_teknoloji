using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string SchoolsListed = "Okul İsimleri Listelendi";
        public static string SchoolAdded = "Okul Eklendi";
        public static string SchoolNameInvalid = "Okul İsmi Geçersiz";
        public static string SchoolListed = "Okul Listelendi";

        public static string? AuthorizationDenied = "Kullanıcı Erişimi Yok";
        public static string ManagerRegistered = "Yönetici Eklendi";
        public static string ErrorManagerRegistered = "Yönetici Eklenemedi";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfullLogin = "Giriş Başarılı";
        public static string AccessTokenCreated = "Toke Oluşturuldu";
    }
}

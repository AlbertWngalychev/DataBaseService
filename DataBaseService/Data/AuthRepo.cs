using DataBaseService.Models;

namespace DataBaseService.Data
{
    public class AuthRepo : IAuthRepo
    {
        private readonly dipContext _contex;

        public AuthRepo(dipContext context)
        {
            _contex = context;
        }

        public bool Authentication(string userName, string pwd)
        {
            Authentication? temp = _contex.Authentications.Where(x => x.Username == userName).FirstOrDefault();

            if (temp == null)
            {
                return false;
            }

            return pwd.ComparePass(temp.Salt, temp.HashedPass);

        }

        public void ChangePassword(string userName, string oldPwd, string newPwd)
        {
            var auth = _contex.Authentications.Where(x => x.Username == userName).FirstOrDefault();
            if (auth == null)
            {
                throw new ArgumentNullException(nameof(userName));
            }

            if (!Authentication(userName, oldPwd))
            {
                throw new Exception("Не верный пароль");
            }

            auth.Salt = PasswordHash.GenerateSalt();
            auth.HashedPass = newPwd.CreatePass(auth.Salt);
        }

        public void CreateUser(string name, string pwd)
        {
            if (_contex.Authentications.Where(x => x.Username == name).FirstOrDefault() != null)
            {
                throw new Exception("Такой пользователь уже существует!");
            }

            byte[] salt = PasswordHash.GenerateSalt();

            _contex.Authentications.Add(new Authentication()
            {
                Username = name,
                Salt = salt,
                HashedPass = pwd.CreatePass(salt)
            });

        }


        public void SaveChanges()
        {
            _contex.SaveChanges();
        }
    }


}

namespace DataBaseService.Data
{
    public interface IAuthRepo
    {
        void CreateUser(string name, string pwd);
        void ChangePassword(string userName, string oldPwd, string newPwd);
        bool Authentication(string userName, string pwd);
        void SaveChanges();
    }
}

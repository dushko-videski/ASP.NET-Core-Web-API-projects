namespace Services.Interfaces
{
    public interface IUserService
    {
        UserModel Login(string username, string password);
        void Register(RegisterModel registerModel);

    }
}

using Bull.Ga.Common.AppModels;

namespace Bull.Ga.Business.Interfaces
{
    public interface IUserServices
    {
        UserAuth? GetUserById(string userId);
    }
}

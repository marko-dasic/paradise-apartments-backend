namespace API.Core.TokenStorage
{
    public interface ITokenStorage
    {
        void AddToken(string id);
        bool TokenExists(string id);
        void InvalidateToken(string id);
    }
}

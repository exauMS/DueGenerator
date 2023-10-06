using Microsoft.AspNetCore.Identity;

namespace JwtApi.Interfaces
{
    public interface IDeleteService
    {
        string delete(int id);
    }
}

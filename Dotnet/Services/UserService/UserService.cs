using System.Security.Claims;

namespace Web.Services
{
    public interface IUserService2
    {
        string GetUserId();
        string GetUserRole();
        bool IsAuthenticated();
    }

    public class UserService2 : IUserService2
    {
        private readonly IHttpContextAccessor _httpContext;
        public UserService2(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        
        public string GetUserId()
        {
            if(_httpContext.HttpContext == null || _httpContext.HttpContext.User == null) return "jebi se";
            return _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public string GetUserRole()
        {
            return _httpContext.HttpContext.User.FindFirst(ClaimTypes.Role.ToString()).Value;
        }
        
        public bool IsAuthenticated()
        {
            return _httpContext.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
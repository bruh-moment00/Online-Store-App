namespace Online_Store_Backend.AuthHelpers
{
    internal static class AuthHelper
    {
        internal static bool CheckSameUserId(HttpContext context, long id)
        {
            return (context.User.Claims.Where(c => c.Type == "id" && c.Value == id.ToString()).Count() != 0);
        }
    }
}

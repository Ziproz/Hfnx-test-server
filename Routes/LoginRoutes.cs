
namespace FnxTest.Routes
{
    public static class LoginRoutes
    {
        public static void MapLogin(this IEndpointRouteBuilder app)
        {
            var userGroup = app.MapGroup("api/login");
            userGroup.MapPost("authenticate", (ILoginService loginService, [FromBody] UserLoginRequest loginRequest) =>
            {
                var token = loginService.Authenticate(loginRequest.Username, loginRequest.Password);
                if (token == null)
                    return Results.Unauthorized();

                return Results.Ok(new { Token = token });
            })
            //.WithName("Login")
            .AllowAnonymous();
        }


    }
}

using Microsoft.AspNetCore.Mvc;

public class FakeAuthenticationService
{
    public bool IsUserAuthenticated(string username, string password)
    {
        // Basit bir kullanıcı doğrulama mantığı - Test amaçlı
        return username == "test" && password == "test";
    }
}

[ApiController]
[Route("api/[controller]")]
public class FakeUserController : ControllerBase
{
    private readonly FakeAuthenticationService _authService;

    public FakeUserController(FakeAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] UserCredentials credentials)
    {
        if (credentials == null)
        {
            return BadRequest("Invalid credentials");
        }

        var username = credentials.Username;
        var password = credentials.Password;

        if (_authService.IsUserAuthenticated(username, password))
        {
            return Ok("Authentication successful");
        }
        else
        {
            return Unauthorized("Authentication failed");
        }
    }
}

public class UserCredentials
{
    public string Username { get; set; }
    public string Password { get; set; }
}



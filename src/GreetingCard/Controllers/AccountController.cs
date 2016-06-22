using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GreetingCard.Controllers
{
    public class AccountController : Controller
    {
        #region Temple
        //private readonly IMembershipService _membershipService;
        //private readonly IUserRepository _userRepository;
        //private readonly ILoggingRepository _loggingRepository;

        //public AccountController(IMembershipService membershipService,
        //    IUserRepository userRepository,
        //    ILoggingRepository _errorRepository)
        //{
        //    _membershipService = membershipService;
        //    _userRepository = userRepository;
        //    _loggingRepository = _errorRepository;
        //}


        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel user)
        //{
        //    IActionResult _result = new ObjectResult(false);
        //    GenericResult _authenticationResult = null;

        //    try
        //    {
        //        MembershipContext _userContext = _membershipService.ValidateUser(user.Email, user.Password);

        //        if (_userContext.User != null)
        //        {
        //            IEnumerable<Role> _roles = _userRepository.GetUserRoles(user.Email);
        //            List<Claim> _claims = new List<Claim>();
        //            foreach (Role role in _roles)
        //            {
        //                Claim _claim = new Claim(ClaimTypes.Role, "Admin", ClaimValueTypes.String, user.Email);
        //                _claims.Add(_claim);
        //            }
        //            await HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
        //                new ClaimsPrincipal(new ClaimsIdentity(_claims, CookieAuthenticationDefaults.AuthenticationScheme)),
        //                new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
        //                {
        //                    IsPersistent = user.RememberMe,
        //                    ExpiresUtc = DateTime.UtcNow.AddSeconds(60),
        //                    AllowRefresh = false
        //                });


        //            _authenticationResult = new GenericResult()
        //            {
        //                Succeeded = true,
        //                Message = "Authentication succeeded"
        //            };
        //        }
        //        else
        //        {
        //            _authenticationResult = new GenericResult()
        //            {
        //                Succeeded = false,
        //                Message = "Authentication failed"
        //            };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _authenticationResult = new GenericResult()
        //        {
        //            Succeeded = false,
        //            Message = ex.Message
        //        };

        //        _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
        //        _loggingRepository.Commit();
        //    }

        //    _result = new ObjectResult(_authenticationResult);
        //    return _result;
        //}

        //[HttpPost("logout")]
        //public async Task<IActionResult> Logout()
        //{
        //    try
        //    {
        //        await HttpContext.Authentication.SignOutAsync("Cookies");
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
        //        _loggingRepository.Commit();

        //        return BadRequest();
        //    }

        //}

        //[Route("register")]
        //[HttpPost]
        //public IActionResult Register([FromBody] RegisterViewModel user)
        //{
        //    IActionResult _result = new ObjectResult(false);
        //    GenericResult _registrationResult = null;

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            User _user = _membershipService.CreateUser(user.Username, user.Email, user.Password, new int[] { 1 });

        //            if (_user != null)
        //            {
        //                _registrationResult = new GenericResult()
        //                {
        //                    Succeeded = true,
        //                    Message = "Registration succeeded"
        //                };
        //            }
        //        }
        //        else
        //        {
        //            _registrationResult = new GenericResult()
        //            {
        //                Succeeded = false,
        //                Message = "Invalid fields."
        //            };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _registrationResult = new GenericResult()
        //        {
        //            Succeeded = false,
        //            Message = ex.Message
        //        };

        //        _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
        //        _loggingRepository.Commit();
        //    }

        //    _result = new ObjectResult(_registrationResult);
        //    return _result;
        //}
        #endregion

    }
}

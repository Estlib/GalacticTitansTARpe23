using GalacticTitans.ApplicationServices.Services;
using GalacticTitans.Core.Domain;
using GalacticTitans.Core.Dto;
using GalacticTitans.Core.Dto.AccountsDtos;
using GalacticTitans.Core.ServiceInterface;
using GalacticTitans.Data;
using GalacticTitans.Models;
using GalacticTitans.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GalacticTitans.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly GalacticTitansContext _context;
        private readonly IEmailsServices _emailsServices;
        private readonly IPlayerProfilesServices _playerProfilesServices;
        public AccountsController
            (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            GalacticTitansContext context,
            IEmailsServices emailsServices,
            IPlayerProfilesServices playerProfilesServices
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _emailsServices = emailsServices;
            _playerProfilesServices = playerProfilesServices;
        }

        /// <summary>
        /// VIEW-GET.
        /// Seeks user, checks if user has password.
        /// If has password, redirects to "ChangePassword" view.
        /// If user doesnt have password, returns "AddPassword" view.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AddPassword()
        {
            var user = await _userManager.GetUserAsync(User);
            var userHasPassword = await _userManager.HasPasswordAsync(user);
            if ( userHasPassword )
            {
                RedirectToAction("ChangePassword");
            }
            return View();
        }
        /// <summary>
        /// DATA-POST.
        /// Seeks user. Gets result, using AddPasswordAsync method where user that was seeked, is given to it with password from model as second parameter.
        /// Checks if adding of password is unsuccessful, in which case enumerates errors, and returns the view.
        /// If is successful, then it refreshes the users signin status, and returns "AddPasswordConfirmation" view.
        /// ModelState validity is checked, possible errors not given a view in GT error display system.
        /// </summary>
        /// <param name="model">Model containing necessary data</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddPassword(AddPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _userManager.AddPasswordAsync(user, model.NewPassword);
                if (!result.Succeeded) 
                { 
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
                await _signInManager.RefreshSignInAsync(user);
                return View("AddPasswordConfirmation");  
            }
            return View(model);
        }
        /// <summary>
        /// VIEW-GET. returns "ChangePassword" view.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        /// <summary>
        /// DATA-POST. checks if user is available, if not, redirects to "Login" view.
        /// Edits users password using ChangePassWordAsync(), giving it found user, old password from model and new password from model.
        /// Checks if changing of password is unsuccessful, in which case enumerates errors, and returns the view.
        /// If is successful, then it refreshes the users signin status, and returns "ChangePasswordConfirmation" view.
        /// ModelState validity is checked, user null is checked, possible errors not given a view in GT error display system.
        /// If ModelState validity is false, it returns the same view, with the data.
        /// </summary>
        /// <param name="model">Model containing necessary data</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
                await _signInManager.RefreshSignInAsync(user);
                return View("ChangePasswordConfirmation");
            }
            return View(model);
        }

        /// <summary>
        /// VIEW-GET. returns "ForgotPassword" view.
        /// Has [AllowAnonymous] so users that are not logged in can change password.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid) 
            { 
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null && await _userManager.IsEmailConfirmedAsync(user))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "Accounts", new {email = model.Email, token = token}, Request.Scheme);
                    // !!

                    return View("ForgotPasswordConfirmation");
                }
                return View("ForgotPasswordConfirmation");
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword()
        {
            var user = await _userManager.GetUserAsync(User);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (token == null || user.Email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            var model = new ResetPasswordViewModel
            {
                Token = token,
                Email = user.Email
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        if(await _userManager.IsLockedOutAsync(user))
                        {
                            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow);
                        }
                        await _signInManager.SignOutAsync();
                        await _userManager.DeleteAsync(user);
                        return RedirectToAction("ResetPasswordConfirmation", "Accounts");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return RedirectToAction("ResetPasswordConfirmation", "Accounts");
                }
                await _userManager.DeleteAsync(user);
                return RedirectToAction("ResetPasswordConfirmation", "Accounts");
            }

            return RedirectToAction("ResetPasswordConfirmation", "Accounts");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation() 
        { 
            return View(); 
        }

        // user register methods
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    City = model.City,
                    ProfileType = model.ProfileType
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                TempData["NewUserID"] = user.Id;
                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var confirmationLink = Url.Action("ConfirmEmail", "Accounts", new { userId = user.Id, token = token }, Request.Scheme);

                    EmailTokenDto newsignup = new();
                    newsignup.Token = token;
                    newsignup.Body = $"Thank you for signing up, klikka här:  {confirmationLink}";
                    newsignup.Subject = "GalacticTitans Register";
                    newsignup.To = user.Email;

                    _emailsServices.SendEmailToken(newsignup, token);
                    if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administrations");
                    }

                    return RedirectToAction("NewProfile", "PlayerProfiles");

                    //List<string> errordatas = 
                    //    [
                    //    "Area", "Accounts", 
                    //    "Issue", "Success", 
                    //    "StatusMessage", "Registration Success", 
                    //    "ActedOn", $"{model.Email}", 
                    //    "CreatedAccountData", $"{model.Email}\n{model.City}\n[password hidden]\n[password hidden]"
                    //    ];
                    //ViewBag.ErrorDatas = errordatas;
                    //ViewBag.ErrorTitle = "You have successfully registered";
                    //ViewBag.ErrorMessage = "Before you can log in, please confirm email from the link" +
                    //    "\nwe have emailed to your email address.";

                    ////var newprofileforthisuser = _context


                    //return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

                }
                else
                {

                    List<string> rawerrors = new();
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        rawerrors.Add(error.Description.ToString());
                    }
                    List<string> errordatas = ["Area", "Register", "Issue", "Registration failure", "ModelState errors =>", $"{string.Join("\n", rawerrors.ToArray())}"];
                    ViewBag.ErrorDatas = errordatas;
                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
            }
            return RedirectToAction("AccountCreated");
        }
        [HttpGet]
        public IActionResult AccountCreated()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null) { return RedirectToAction("Index", "Home"); }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) 
            {
                ViewBag.ErrorMessage = $"The user with id of {userId} is not valid";
                return View("Shared", "Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            List<string> errordatas =
                        [
                        "Area", "Accounts",
                        "Issue", "Failure",
                        "StatusMessage", "Confirmation Failure",
                        "ActedOn", $"{user.Email}",
                        "CreatedAccountData", $"{user.Email}\n{user.City}\n[password hidden]\n[password hidden]"
                        ];
            if (result.Succeeded)
            {
                errordatas =
                        [
                        "Area", "Accounts",
                        "Issue", "Success",
                        "StatusMessage", "Confirmation Success",
                        "ActedOn", $"{user.Email}",
                        "CreatedAccountData", $"{user.Email}\n{user.City}\n[password hidden]\n[password hidden]"
                        ];
                ViewBag.ErrorDatas = errordatas;
                return View();

            }
            
            ViewBag.ErrorDatas = errordatas;
            ViewBag.ErrorTitle = "Email cannot be confirmed";
            ViewBag.ErrorMessage = $"The users email, with userid of {userId}, cannot be confirmed.";
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // user login & logout methods
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnURL)
        {
            LoginViewModel vm = new()
            {
                ReturnURL = returnURL,
                // extval
            };

            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model,string? returnURL)
        {
            // extval
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if(user != null && !user.EmailConfirmed && (await _userManager.CheckPasswordAsync(user, model.Password)))
                {
                    ModelState.AddModelError(string.Empty, "Your email hasn't been confirmed yet. Please check your Email spam folders.");
                    return View(model);
                }
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);
                if (result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnURL) && Url.IsLocalUrl(returnURL))
                    {
                        return Redirect(returnURL);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                if (result.IsLockedOut)
                {
                    return View("AccountLocked");
                }
                ModelState.AddModelError("", "Invalid Login Attempt, please contact admin.");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }    
}

﻿//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using TrainSeatReservation.Commons;
using TrainSeatReservation.Commons.EmailService;
using TrainSeatReservation.EntityFramework.Models;

namespace TrainSeatReservation.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IEmailService _emailService;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            //_emailSender = emailSender;
            _emailService = emailService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required (ErrorMessage ="Imię jest obowiązkowe")]
            [Display(Name = "Imię")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Nazwisko jest obowiązkowe")]
            [Display(Name = "Nazwisko")]
            public string Surname { get; set; }
            [Required(ErrorMessage = "Email jest obowiązkowy")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Hasło jest obowiązkowe")]
            [StringLength(100, ErrorMessage = "{0} musi mieć od {2} do {1} znaków długości.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Hasło")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Potwierdzenie hasła")]
            [Compare("Password", ErrorMessage = "Hasło oraz potwierdzenie hasła nie są takie same.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new User { UserName = Input.Email, Email = Input.Email, Name = Input.Name, Surname = Input.Surname };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Client").Wait();
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    var subject = "Potwierdzenie stworzenia konta";
                    var content = $"Proszę potwierdzić swoje konto <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>tutaj</a>.";
                    _emailService.SendVerificationEmail(user.Name, user.Surname, user.Email, subject, content);
                    /// await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}

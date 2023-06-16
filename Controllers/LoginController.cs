
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab11.Controllers;

using lab11.Models;

public class AccountController : Controller
{
    // GET: Account/Login
    [AllowAnonymous] 
    public ActionResult Login(string returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    // POST: Account/Login
    [HttpPost]
    [AllowAnonymous] 
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginViewModel model, string? returnUrl)
    {
        if (ModelState.IsValid)
        {

            if (true || model.Username == "admin" && model.Password == "password")
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid username or password.");
        }

        return View(model);
    }
}


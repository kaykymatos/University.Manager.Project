// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace University.Manager.Project.IdentityServer.Pages.Account.AccessDenied;

public class Index : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = default!;
    public void OnGet()
    {
    }
    public async Task<IActionResult> OnPost()
    {
        return !string.IsNullOrEmpty(Input.ReturnUrl) ? Redirect(Input.ReturnUrl) : Page();

    }
}

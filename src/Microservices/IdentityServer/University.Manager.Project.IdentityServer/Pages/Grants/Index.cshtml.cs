// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using Duende.IdentityServer.Events;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace University.Manager.Project.IdentityServer.Pages.Grants;

[SecurityHeaders]
[Authorize]
public class Index : PageModel
{
    private readonly IIdentityServerInteractionService _interaction;
    private readonly IClientStore _clients;
    private readonly IResourceStore _resources;
    private readonly IEventService _events;

    public Index(IIdentityServerInteractionService interaction,
        IClientStore clients,
        IResourceStore resources,
        IEventService events)
    {
        _interaction = interaction;
        _clients = clients;
        _resources = resources;
        _events = events;
    }

    public ViewModel View { get; set; } = default!;

    public async Task OnGet()
    {
        IEnumerable<Duende.IdentityServer.Models.Grant> grants = await _interaction.GetAllUserGrantsAsync();

        List<GrantViewModel> list = [];
        foreach (Duende.IdentityServer.Models.Grant grant in grants)
        {
            Duende.IdentityServer.Models.Client? client = await _clients.FindClientByIdAsync(grant.ClientId);
            if (client != null)
            {
                Duende.IdentityServer.Models.Resources resources = await _resources.FindResourcesByScopeAsync(grant.Scopes);

                GrantViewModel item = new()
                {
                    ClientId = client.ClientId,
                    ClientName = client.ClientName ?? client.ClientId,
                    ClientLogoUrl = client.LogoUri,
                    ClientUrl = client.ClientUri,
                    Description = grant.Description,
                    Created = grant.CreationTime,
                    Expires = grant.Expiration,
                    IdentityGrantNames = resources.IdentityResources.Select(x => x.DisplayName ?? x.Name).ToArray(),
                    ApiGrantNames = resources.ApiScopes.Select(x => x.DisplayName ?? x.Name).ToArray()
                };

                list.Add(item);
            }
        }

        View = new ViewModel
        {
            Grants = list
        };
    }

    [BindProperty]
    public string? ClientId { get; set; }

    public async Task<IActionResult> OnPost()
    {
        await _interaction.RevokeUserConsentAsync(ClientId);
        await _events.RaiseAsync(new GrantsRevokedEvent(User.GetSubjectId(), ClientId));
        Telemetry.Metrics.GrantsRevoked(ClientId);

        return RedirectToPage("/Grants/Index");
    }
}

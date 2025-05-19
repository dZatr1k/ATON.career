using Aton.Career.UserService.Data;
using Aton.Career.UserService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aton.Career.UserService.Requirements.Handlers;

public class ActiveUserOrAdminHandler(IUserContextService userContext, IUserRepository repository) : AuthorizationHandler<ActiveUserOrAdminRequirement>
{
    private readonly IUserContextService _userContext = userContext;
    private readonly IUserRepository _repository = repository;

    protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, ActiveUserOrAdminRequirement requirement)
    {
        var userLogin = _userContext.Login;
        if (string.IsNullOrEmpty(userLogin))
            return;

        var routeLogin = _userContext.RouteValues["login"]?.ToString();

        if (string.IsNullOrEmpty(routeLogin))
            return;

        var user = await _repository.GetByLogin(userLogin);
        if (user == null)
            return;

        if (user.Admin)
        {
            context.Succeed(requirement);
            return;
        }

        if (userLogin == routeLogin && user.RevokedOn == null)
        {
            context.Succeed(requirement);
            return;
        }

    }
}

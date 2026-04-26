using Microsoft.AspNetCore.Mvc;
using StoreBackend.Api.Mappers;
using StoreBackend.Facade;

namespace StoreBackend.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserFacade userFacade;

    public UserController(IUserFacade userFacade)
    {
        this.userFacade = userFacade;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await userFacade.GetAllAsync();
        var models = UserMapper.ToModel(users);
        return Ok(models);
    }

    [HttpGet("{externalId}")]
    public async Task<IActionResult> GetUser(Guid externalId)
    {
        var user = await userFacade.GetByExternalIdAsync(externalId);

        if (user == null)
        {
            return NotFound();
        }

        var model = UserMapper.ToModel(user);
        return Ok(model);
    }
}
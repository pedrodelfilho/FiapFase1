using Microsoft.AspNetCore.Mvc;

namespace FiapFase1.Api.Controllers.Shared;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class ApiControllerBase : ControllerBase { }

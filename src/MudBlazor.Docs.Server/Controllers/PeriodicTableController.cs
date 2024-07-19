using Microsoft.AspNetCore.Mvc;
using MudBlazor.Examples.Data;
using MudBlazor.Examples.Data.Models;

namespace MudBlazor.Docs.Server.Controllers;

[Route("wasm/webapi/[controller]")]
[Route("webapi/[controller]")]
[ApiController]
public class PeriodicTableController : ControllerBase
{
    private readonly IPeriodicTableService _periodicTableService;

    public PeriodicTableController(IPeriodicTableService periodicTableService)
    {
        _periodicTableService = periodicTableService;
    }

    [HttpGet("/webapi/periodictable-advanced-search")]
    public async Task<GridData<Element>> Get(string? search, string? sortBy, string? sortDirection, int skip, int take)
    {
        var page = await _periodicTableService.GetElements(search, sortBy, sortDirection, skip, take);
        return new GridData<Element>
        {
            TotalItems = page.Item1,
            Items = page.Item2
        };
    }

    //[HttpGet("{search}")]
    //public Task<IEnumerable<Element>> Get(string search) => _periodicTableService.GetElements(search);

    [HttpGet]
    public Task<IEnumerable<Element>> Get() => _periodicTableService.GetElements();
}

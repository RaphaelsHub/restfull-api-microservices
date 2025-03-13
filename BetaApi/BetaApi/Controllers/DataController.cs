using BetaApi.Interfaces;
using BetaApi.MicroServices;
using BetaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BetaApi.Controllers;

[ApiController]
[Route("betaApi/[controller]")]
public class DataController(IDataService dataService, AlphaApiClient alphaApiClient) : ControllerBase
{
    [HttpGet]
    public IActionResult GetData()
    {
        var data = dataService.GetAll();
        return Ok(new { Message = "Hello from BetaApi!", Data = data });
    }

    [HttpPost]
    public IActionResult PostData([FromBody] Data data)
    {
        if (data == null || string.IsNullOrWhiteSpace(data.Name))
        {
            return BadRequest(new { Message = "Invalid data provided in BetaApi!" });
        }

        dataService.Add(data);
        return Ok(new { Message = "Data added successfully in BetaApi!", Data = data });
    }

    [HttpPut("{id}")]
    public IActionResult PutData(int id, [FromBody] Data updatedData)
    {
        var existingData = dataService.GetById(id);
        if (existingData == null)
        {
            return NotFound(new { Message = "Data not found in BetaApi!" });
        }
        
        updatedData = updatedData with { Id = id };

        dataService.Update(updatedData);
        return Ok(new { Message = "Data updated successfully in BetaApi!", Data = updatedData });
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteData(int id)
    {
        var data = dataService.GetById(id);
        if (data == null)
        {
            return NotFound(new { Message = "Data not found in BetaApi!" });
        }

        dataService.Delete(id);
        return Ok(new { Message = $"Data with Id {id} deleted successfully from BetaApi!" });
    }

    [HttpGet("alpha")]
    public async Task<IActionResult> GetAlphaData()
    {
        var result = await alphaApiClient.GetDataFromAlphaApi();
        return Ok(result);
    }

    [HttpPost("alpha")]
    public async Task<IActionResult> PostAlphaData([FromBody] Data data)
    {
        var result = await alphaApiClient.PostDataToAlphaApi(data);
        return Ok(result);
    }

    [HttpPut("alpha/{id}")]
    public async Task<IActionResult> PutAlphaData(int id, [FromBody] Data data)
    {
        var result = await alphaApiClient.PutDataToAlphaApi(id, data);
        return Ok(result);
    }

    [HttpDelete("alpha/{id}")]
    public async Task<IActionResult> DeleteAlphaData(int id)
    {
        var result = await alphaApiClient.DeleteDataFromAlphaApi(id);
        return Ok(result);
    }
}

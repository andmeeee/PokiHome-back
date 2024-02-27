using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokiHome.Demo.Data;
using PokiHome.Demo.Data.Entities;

namespace PokiHome.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController:ControllerBase
{
    private readonly ApplicationContext _reactContext;
    public HomeController(ApplicationContext reactContext)
    {
        _reactContext = reactContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var home = await _reactContext.Home.ToListAsync();
        return Ok(home);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Home newHome)
    {
        _reactContext.Home.Add(newHome);
        await _reactContext.SaveChangesAsync();
        return Ok(newHome);
    }

    [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _reactContext.Home.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _reactContext.Home.Remove(entity);
            await _reactContext.SaveChangesAsync();

            return NoContent();
        }
    
     [HttpPut("{id}")]
        public async Task<IActionResult> PutHome(int id, [FromBody] Home bodyHome, [FromQuery] Home queryHome)
        {
            if (id != bodyHome.Id || id != queryHome.Id)
            {
                return BadRequest();
            }

            // Выбираем объект Home на основе приоритета
            Home homeToUpdate = bodyHome ?? queryHome;

            _reactContext.Entry(homeToUpdate).State = EntityState.Modified;

            try
            {
                await _reactContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool HomeExists(int id)
        {
            return _reactContext.Home.Any(e => e.Id == id);
        }
    
        
    
}
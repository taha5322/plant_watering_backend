using Microsoft.AspNetCore.Mvc;
using watering_api.Models;

namespace watering_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private static Plant[] storage = Enumerable.Range(1, 6).Select(index => new Plant
            {
                Date = DateTime.Now.ToString(),
                Name = "Plant " + (index),
                IsAlive = true
            })
            .ToArray();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Plant> Get()
        {
            Console.WriteLine("GET");
            return storage;
        }


        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plant>> PostTodoItem(Plant newPlant)
        {
            Console.WriteLine("POST");
            
            Plant[] tempArray = new Plant[storage.Length];
            storage.CopyTo(tempArray, 0);
            // return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            Plant[] arrTarget = new Plant[ tempArray.Length + 1];
            tempArray.CopyTo(arrTarget, 0);
            arrTarget[storage.Length - 1] =  new Plant {
                Date = newPlant.Date,
                Name = newPlant.Name,
                IsAlive = newPlant.IsAlive
            };

            Plant[] newStorage = new Plant[arrTarget.Length];
            arrTarget.CopyTo(newStorage, 0);
            storage = newStorage;

            return CreatedAtAction("", new { id = newPlant.Name }, newPlant);
        }


        [HttpPatch]
        public async Task<IActionResult> PutTodoItem( Plant editedPlant)
        {
            Console.WriteLine("PATCH");

            String name = editedPlant.Name;
            char numchar =name.Last();
            int num = numchar - '0';

            if (num > 5 || num<1)
            {
                return BadRequest();
            }

            storage[num-1] = new Plant
            {
                Date = editedPlant.Date,
                Name = editedPlant.Name,
                IsAlive = editedPlant.IsAlive
            };

            return NoContent();

        }
    }
}
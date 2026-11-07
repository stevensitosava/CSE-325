
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Models;

namespace PizzaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    // Temporary in-memory database
    private static List<Pizza> pizzas = new()
    {
        new Pizza
        {
            Id = 1,
            Name = "Margherita",
            Price = 12.50m,
            Description = "Tomato, mozzarella and basil"
        },
        new Pizza
        {
            Id = 2,
            Name = "Pepperoni",
            Price = 14.50m,
            Description = "Tomato, mozzarella and pepperoni"
        },
        new Pizza
        {
            Id = 3,
            Name = "Hawaiian",
            Price = 15.00m,
            Description = "Ham, pineapple and mozzarella"
        }
    };

    // GET: api/pizza
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
    {
        return Ok(pizzas);
    }

    // GET: api/pizza/1
    [HttpGet("{id}")]
    public ActionResult<Pizza> GetById(int id)
    {
        var pizza = pizzas.FirstOrDefault(p => p.Id == id);

        if (pizza == null)
            return NotFound();

        return Ok(pizza);
    }

    // POST: api/pizza
    [HttpPost]
    public ActionResult<Pizza> Create(Pizza newPizza)
    {
        newPizza.Id = pizzas.Count > 0
            ? pizzas.Max(p => p.Id) + 1
            : 1;

        pizzas.Add(newPizza);

        return CreatedAtAction(
            nameof(GetById),
            new { id = newPizza.Id },
            newPizza
        );
    }

    // PUT: api/pizza/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza updatedPizza)
    {
        var pizza = pizzas.FirstOrDefault(p => p.Id == id);

        if (pizza == null)
            return NotFound();

        pizza.Name = updatedPizza.Name;
        pizza.Price = updatedPizza.Price;
        pizza.Description = updatedPizza.Description;

        return NoContent();
    }

    // DELETE: api/pizza/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = pizzas.FirstOrDefault(p => p.Id == id);

        if (pizza == null)
            return NotFound();

        pizzas.Remove(pizza);

        return NoContent();
    }
}

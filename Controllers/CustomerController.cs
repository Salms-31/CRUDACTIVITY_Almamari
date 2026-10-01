using Microsoft.AspNetCore.Mvc;
using CRUDACTIVITY_Almamari.Data;
using CRUDACTIVITY_Almamari.Models;

namespace CRUDACTIVITY_Almamari.Controllers
{
public class CustomersController : Controller
{
private readonly ApplicationDbContext _db;

    public CustomersController(ApplicationDbContext db)
    {
        _db = db;
    }

    // Shows the list
    public IActionResult Index()
    {
        var customers = _db.Customers.ToList();
        return View(customers);
    }

    // Shows the empty add-form
    public IActionResult Create()
    {
        return View();
    }

    // Saves a new customer
    [HttpPost]
    public IActionResult Create(Customer customer)
    {
        _db.Customers.Add(customer);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }

    // EDIT - show the edit form
    public IActionResult Edit(int id)
    {
        var customer = _db.Customers.Find(id);

        if (customer == null)
            return RedirectToAction("Index");

        return View(customer);
    }

    // EDIT - save the changes
    [HttpPost]
    public IActionResult Edit(Customer customer)
    {
        _db.Customers.Update(customer);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }

    // DELETE - remove the customer
    public IActionResult Delete(int id)
    {
        var customer = _db.Customers.Find(id);

        if (customer != null)
        {
            _db.Customers.Remove(customer);
            _db.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}


}
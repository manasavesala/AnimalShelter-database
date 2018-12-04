using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  public class AnimalShelterController : Controller
  {
    [HttpGet("/animal/new")]
    public ActionResult New()
    {
        return View();
    }

    [HttpPost("/animal/index")]
    public ActionResult Create(string AnimalName, string AnimalType, string AnimalDate, string AnimalBreed)
    {
        Animal newAnimal = new Animal(AnimalName, AnimalType, AnimalDate, AnimalBreed);
        newAnimal.Save();
        List<Animal> allAnimals = Animal.GetAll();
        return View("Index", allAnimals);
    }

    [HttpGet("/animal/index")]
    public ActionResult Show(string AnimalName, string AnimalType, string AnimalDate, string AnimalBreed)
    {
        List<Animal> allAnimals = Animal.GetAll();
        return View("Index", allAnimals);
    }

    [HttpGet("/animal/show")]
    public ActionResult Show()
    {
      return View ();
    }

    [HttpGet("/animal/show/{animalId}")]
    public ActionResult Show(int animalId)
    {
        List<Animal>allAnimals = Animal.GetAnimal(animalId);
        return View("Show", allAnimals);
    }

  }
}

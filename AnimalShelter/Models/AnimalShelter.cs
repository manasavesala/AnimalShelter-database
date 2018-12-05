using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using AnimalShelter;

namespace AnimalShelter.Models
{
  public class Animal
  {
    private string _name;
    private string _type;
    private string _date;
    private string _breed;
    private int _id;

    public Animal(string name, string type, string date, string breed, int id=0)
    {
      _name = name;
      _type = type;
      _date = date;
      _breed = breed;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }
    public void SetName(string name)
    {
      _name = name;
    }

    public string GetType()
    {
      return _type;
    }
    public void SetType(string type)
    {
      _type = type;
    }
    public string GetDate()
    {
      return _date;
    }
    public void SetDate(string date)
    {
      _date = date;
    }
    public string GetBreed()
    {
      return _breed;
    }
    public void SetBreed(string breed)
    {
      _breed = breed;
    }
    public int GetId()
    {
      return _id;
    }

    public static List<Animal> GetAll()
    {
      List<Animal> allAnimalsList = new List<Animal> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM animalshelter;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int animalId = rdr.GetInt32(4);
        string animalName = rdr.GetString(0);
        string animalType = rdr.GetString(1);
        string animalDate = rdr.GetString(2);
        string animalBreed= rdr.GetString(3);

        Animal newAnimalShelter = new Animal(animalName, animalType, animalDate, animalBreed, animalId); // <--- This line now uses two arguments!
        allAnimalsList.Add(newAnimalShelter);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allAnimalsList;
    }

    public static List<Animal> GetSortedbyDate()
    {
      List<Animal> allAnimalsList = new List<Animal> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM animalshelter ORDER BY date ASC;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int animalId = rdr.GetInt32(4);
        string animalName = rdr.GetString(0);
        string animalType = rdr.GetString(1);
        string animalDate = rdr.GetString(2);
        string animalBreed= rdr.GetString(3);

        Animal newAnimalShelter = new Animal(animalName, animalType, animalDate, animalBreed, animalId); // <--- This line now uses two arguments!
        allAnimalsList.Add(newAnimalShelter);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allAnimalsList;
    }

    public static List<Animal> GetAnimal(int passedInId)
    {
      List<Animal> allAnimalsList = new List<Animal> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM animalshelter WHERE id = " + passedInId + ";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int animalId = rdr.GetInt32(4);
        string animalName = rdr.GetString(0);
        string animalType = rdr.GetString(1);
        string animalDate = rdr.GetString(2);
        string animalBreed= rdr.GetString(3);

        Animal newAnimalShelter = new Animal(animalName, animalType, animalDate, animalBreed, animalId); // <--- This line now uses two arguments!
        allAnimalsList.Add(newAnimalShelter);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allAnimalsList;
    }

    public void Save()
   {
     MySqlConnection conn = DB.Connection();
     conn.Open();
     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"INSERT INTO animalshelter (name,type, date, breed) VALUES (@AnimalName,@AnimalType, @AnimalDate, @AnimalBreed );";

     MySqlParameter name = new MySqlParameter();
     name.ParameterName = "@AnimalName";
     name.Value = _name;
     cmd.Parameters.Add(name);

     MySqlParameter type = new MySqlParameter();
     type.ParameterName = "@AnimalType";
     type.Value = _type;
     cmd.Parameters.Add(type);

     MySqlParameter date = new MySqlParameter();
     date.ParameterName= "@AnimalDate";
     date.Value = _date;
     cmd.Parameters.Add(date);

      MySqlParameter breed = new MySqlParameter();
      breed.ParameterName = "@AnimalBreed";
      breed.Value = _breed;
      cmd.Parameters.Add(breed);

     cmd.ExecuteNonQuery();
     _id = (int) cmd.LastInsertedId;  // Notice the slight update to this line of code!
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
   }

  }
}

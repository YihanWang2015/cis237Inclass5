using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass5
{
    class Program
    {
        static void Main(string[] args)
        {
            //AdventureWorks2012Entities adventure = new AdventureWorks2012Entities();

            //int counter = 0;
            //Guid id = Guid.NewGuid();

            //foreach (Person person in adventure.People)
            //{
            //    if (counter == 0)

            //    {
            //        id = person.rowguid;
            //    }

            //    if (counter++ > 20)
            //    {
            //        break;
            //    }
            //    Console.WriteLine(counter +"  "+ person.FirstName + " " + person.LastName + " " + person.rowguid);
            //}

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine(adventure.People.Find(id));

            //foreach (EmailAddress email in adventure.EmailAddresses)
            //{
            //    Console.WriteLine(email);
            //}




            //**************************************************************
            //List out all of the cars in the table
            //**************************************************************


            //Get access to the collection of tables we can interact with.
            CarsYWangEntities carsYWangEntities = new CarsYWangEntities();


            //Loop through all of the cars in the table called Cars.
            foreach(Car car in carsYWangEntities.Cars)
            {
                Console.WriteLine("ID: "+car.id + " " + "MAKE: "+car.make + " " + "MODEL:"+car.model);
            }

            //**************************************************************
            //Find a specific one by any property
            //**************************************************************

            //FIRST one to find back
            //Call the Where method on the table Cars and pass it in a lambda expression for
            //the criteria we are looking for. There is nothing special about the work car
            //in the part that reads: car => car.id =="VOLCD1914" . It could be any characters
            //we want it to be. car made sense. Also, car represents the  object we want to do
            //the where clause on. That's why we have car.id =="VOLCD1914".
            Car carToFind = carsYWangEntities.Cars.Where(c => c.id == "V0LCD1814").First();


            //We can look for a specific model from the database with a where clause based on any criteria we want.
            //Here we are doing it with the Car's model instead of its id.
            Car otherCarToFind = carsYWangEntities.Cars.Where(car => car.model == "Challenger").First();


            //Print them out.
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(carToFind.id + " " + carToFind.make + " " + carToFind.model );

            Console.WriteLine(otherCarToFind.id + " " + otherCarToFind.make + " " + otherCarToFind.model);


            //*********************************************************************************
            //Find a car based on the primary id
            //*********************************************************************************
            //NOTE:This currently doesn't work because I forgot to set a primary id on the table.
            //Will hopefully fix it soon.

            //Pull out a car from the table based on the primary Id
            //TODO: uncomment when primary id is fixed
           // Car foundCar = carsYWangEntities.Cars.Find("V0LCD1814");

            //Print it out
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("Hohoho");
            //Console.WriteLine(foundCar.id + " " + foundCar.make + " " + foundCar.model);

            //*******************************************************************************
            //Add a new Car to the database
            //*******************************************************************************

            //Make an instance of a new car
            Car newCarToAdd = new Car();

            //Assign properties to the parts of the model
            newCarToAdd.id = "88888";
            newCarToAdd.make = "Nissan";
            newCarToAdd.model = "GT-R";
            newCarToAdd.horsepower = 550;
            newCarToAdd.cylinders = 8;
            newCarToAdd.year = "2016";
            newCarToAdd.type = "Car";

            //Add the new car to the Cars table
            //TODO: UNCOMMENT WHEN PRIMARY ID IS FIXED
           // carsYWangEntities.Cars.Add(newCarToAdd);

            //This method call actually does the work of saving the changes to the database.
            //carsYWangEntities.SaveChanges();





            //**********************************************************************
            //How to do an update
            //****************************************************************

            //Get a car out of the database that we would like to update
            Car carToFindForUpdate = carsYWangEntities.Cars.Find("V0LCD1814");

            //Update some of the properties of the car we found. Dont need to update all of them
            //if we don't want to. I choose these 4.
            carToFindForUpdate.make = "Nissan";
            carToFindForUpdate.model = "GT-R";
            carToFindForUpdate.horsepower = 550;
            carToFindForUpdate.cylinders = 8;

            //Save the changes to the database.
            carsYWangEntities.SaveChanges();




            //=========================================================================

            //**********************************************************************
            //How to do an delete
            //****************************************************************

            //Get a car out of the database that we would like to update
            Car carToFindForDelete = carsYWangEntities.Cars.Find("V0LCD1814");

           //Remove the Car from the Cars table
            carsYWangEntities.Cars.Remove(carToFindForDelete);

            //Save the changes to the database.
            carsYWangEntities.SaveChanges();






        }
    }
}

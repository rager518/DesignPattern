using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Creational
{
    #region 指导者

    /// <summary>
    /// The 'Director' class
    /// </summary>
    class Director
    {
        // Builder uses a complex series of steps
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    #endregion 

    #region 建造者

    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract BuilderProduct GetResult();
    }

    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    class ConcreteBuilder1 : Builder
    {
        private BuilderProduct _product = new BuilderProduct();

        public override void BuildPartA()
        {
            _product.Add("PartA");
        }

        public override void BuildPartB()
        {
            _product.Add("PartB");
        }

        public override BuilderProduct GetResult()
        {
            return _product;
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    class ConcreteBuilder2 : Builder
    {
        private BuilderProduct _product = new BuilderProduct();

        public override void BuildPartA()
        {
            _product.Add("PartX");
        }

        public override void BuildPartB()
        {
            _product.Add("PartY");
        }

        public override BuilderProduct GetResult()
        {
            return _product;
        }
    }

    #endregion

    #region 产品

    /// <summary>
    /// The 'Product' class
    /// </summary>
    class BuilderProduct
    {
        private List<string> _parts = new List<string>();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\nProduct Parts -------");
            foreach (string part in _parts)
                Console.WriteLine(part);
        }
    }

    #endregion

    /*---------------真实场景-----------------*/

    #region 指导者

    /// <summary>
    /// The 'Director' class
    /// </summary>
    class Shop
    {
        // Builder uses a complex series of steps
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }

    #endregion

    #region 建造者

    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    abstract class VehicleBuilder
    {
        protected Vehicle vehicle;

        // Gets vehicle instance
        public Vehicle Vehicle
        {
            get { return vehicle; }
        }

        // Abstract build methods
        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }

    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder()
        {
            vehicle = new Vehicle("MotorCycle");
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "MotorCycle Frame";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "500 cc";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }


    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            vehicle = new Vehicle("Car");
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "Car Frame";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "2500 cc";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "4";
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "4";
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder3' class
    /// </summary>
    class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            vehicle = new Vehicle("Scooter");
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "Scooter Frame";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "50 cc";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }

    #endregion

    #region 产品

    /// <summary>
    /// The 'Product' class
    /// </summary>
    class Vehicle
    {
        private string _vehicleType;
        private Dictionary<string, string> _parts =
          new Dictionary<string, string>();

        // Constructor
        public Vehicle(string vehicleType)
        {
            this._vehicleType = vehicleType;
        }

        // Indexer
        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vehicle Type: {0}", _vehicleType);
            Console.WriteLine(" Frame : {0}", _parts["frame"]);
            Console.WriteLine(" Engine : {0}", _parts["engine"]);
            Console.WriteLine(" #Wheels: {0}", _parts["wheels"]);
            Console.WriteLine(" #Doors : {0}", _parts["doors"]);
        }
    }

    #endregion
}

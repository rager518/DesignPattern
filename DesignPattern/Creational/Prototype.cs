using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Creational
{
    /// <summary>
    /// The 'Prototype' abstract class
    /// </summary>
    abstract class Prototype
    {
        private string _id;

        // Constructor
        public Prototype(string id)
        {
            this._id = id;
        }

        // Gets id
        public string Id
        {
            get { return _id; }
        }

        public abstract Prototype Clone();
    }

    /// <summary>
    /// A 'ConcretePrototype' class 
    /// </summary>
    class ConcretePrototype1 : Prototype
    {
        // Constructor
        public ConcretePrototype1(string id)
            : base(id)
        {
        }

        // Returns a shallow copy
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    /// <summary>
    /// A 'ConcretePrototype' class 
    /// </summary>
    class ConcretePrototype2 : Prototype
    {
        // Constructor
        public ConcretePrototype2(string id)
            : base(id)
        {
        }

        // Returns a shallow copy
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    /*---------------真实场景-----------------*/
    /// <summary>
    /// The 'Prototype' abstract class
    /// </summary>
    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    /// <summary>
    /// The 'ConcretePrototype' class
    /// </summary>
    class Color : ColorPrototype
    {
        private int _red;
        private int _green;
        private int _blue;

        // Constructor
        public Color(int red, int green, int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }

        // Create a shallow copy
        public override ColorPrototype Clone()
        {
            Console.WriteLine(
              "Cloning color RGB: {0,3},{1,3},{2,3}",
              _red, _green, _blue);

            return this.MemberwiseClone() as ColorPrototype;
        }
    }

    /// <summary>
    /// Prototype manager
    /// </summary>
    class ColorManager
    {
        private Dictionary<string, ColorPrototype> _colors =
          new Dictionary<string, ColorPrototype>();

        // Indexer
        public ColorPrototype this[string key]
        {
            get { return _colors[key]; }
            set { _colors.Add(key, value); }
        }
    }

}

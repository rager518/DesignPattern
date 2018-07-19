using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Creational
{
    #region 工厂

    public abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    public class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    public class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }

    }
    #endregion

    #region 产品

    public abstract class AbstractProductA
    {

    }

    public abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }

    public class ProductA1 : AbstractProductA
    {
    }

    public class ProductA2 : AbstractProductA
    {
    }

    public class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name +
              " interacts with " + a.GetType().Name);
        }
    }

    public class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name +
              " interacts with " + a.GetType().Name);
        }
    }

    #endregion

    #region 客户端

    public class AbstractFactoryClient
    {
        private AbstractProductA _abstractProductA;
        private AbstractProductB _abstractProductB;

        // Constructor
        public AbstractFactoryClient(AbstractFactory factory)
        {
            _abstractProductB = factory.CreateProductB();
            _abstractProductA = factory.CreateProductA();
        }

        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }

    #endregion

    /*---------------真实场景-----------------*/

    #region 工厂

    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>
    class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>
    class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    #endregion

    #region 产品

    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>
    abstract class Herbivore
    {
    }

    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// </summary>
    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    class Wildebeest : Herbivore
    {
    }

    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    class Bison : Herbivore
    {
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }

    #endregion

    #region 客户端

    /// <summary>
    /// The 'Client' class 
    /// </summary>
    class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        // Constructor
        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }

    #endregion
}

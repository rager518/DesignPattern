using DesignPattern.Behavioral;
using DesignPattern.Creational;
using DesignPattern.Structural;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunAbstractFactory();
            //RunAbstractFactoryRealWorld();
            //RunBuilder();
            //RunBuilderRealWorld();
            //RunFactoryMethod();
            //RunFactoryMethodRealWorld();
            //RunPrototype();
            //RunPrototypeRealWorld();
            //RunSingleton();
            //RunSingletonRealWorld();

            //RunAdapter();
            //RunAdapterRealWorld();
            //RunBridge();
            //RunBridgeRealWorld();
            //RunComposite();
            //RunCompositeRealWorld();
            //RunDecorator();
            //RunDecoratorRealWorld();
            //RunFacade();
            //RunFacadeRealWorld();
            //RunFlyWeight();
            //RunFlyWeightRealWorld();
            //RunProxy();
            //RunProxyRealWorld();

            //RunChainofResp();
            //RunChainofRespRealWorld();
            //RunCommand();
            //RunCommandRealWorld();
            //RunInterpreter();
            //RunInterpreterRealWorld();
            //RunIterator();
            //RunIteratorRealWorld();
            //RunMediator();
            //RunMediatorRealWorld();
            //RunMemento();
            //RunMementoRealWorld();
            //RunObserver();
            //RunObserverRealWorld();
            //RunState();
            //RunStateRealWorld();
            //RunStrategy();
            //RunStrategyRealWorld();
            //RunTemplateMethod();
            //RunTemplateMethodRealWorld();
            //RunVisitor();
            RunVisitorRealWorld();

            // Wait for user input
            Console.ReadKey();
        }

        #region Creational
        static void RunAbstractFactory()
        {
            // 工厂是抽象化的 即可以有多个工厂
            // 隐藏产品的实例化过程【隐藏生产过程】
            // 不同工厂生产不同类型产品【产品有共性（统一继承某产品基类），有产品组概念】
            // 单个工厂内的产品可以互相调用
            AbstractFactory factory1 = new ConcreteFactory1();
            AbstractFactoryClient client1 = new AbstractFactoryClient(factory1);
            client1.Run();

            // Abstract factory #2
            AbstractFactory factory2 = new ConcreteFactory2();
            AbstractFactoryClient client2 = new AbstractFactoryClient(factory2);
            client2.Run();
        }
        static void RunAbstractFactoryRealWorld()
        {
            // Create and run the African animal world
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            // Create and run the American animal world
            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
        }

        static void RunBuilder()
        {
            // 建造者关系一个产品的构造
            // 产品构造通常很复杂或者需要分部构造
            Director director = new Director();

            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            // Construct two products
            director.Construct(b1);
            BuilderProduct p1 = b1.GetResult();
            p1.Show();

            director.Construct(b2);
            BuilderProduct p2 = b2.GetResult();
            p2.Show();
        }
        static void RunBuilderRealWorld()
        {
            VehicleBuilder builder;

            // Create shop with vehicle builders
            Shop shop = new Shop();

            // Construct and display vehicles
            builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();
        }

        static void RunFactoryMethod()
        {
            // 工厂方法生成的产品一般是单一
            Creator[] creators = new Creator[2];

            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            // Iterate over creators and create products
            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}",
                  product.GetType().Name);
            }
        }
        static void RunFactoryMethodRealWorld()
        {
            Document[] documents = new Document[2];

            documents[0] = new Resume();
            documents[1] = new Report();

            // Display document pages
            foreach (Document document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (Page page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }
            }
        }

        static void RunPrototype()
        {
            // 原型更在于产品可以快速复制
            Prototype p1 = new ConcretePrototype1("I");
            Prototype c1 = (ConcretePrototype1)p1.Clone();
            Console.WriteLine("Cloned: {0}", c1.Id);

            Prototype p2 = new ConcretePrototype2("II");
            Prototype c2 = (ConcretePrototype2)p2.Clone();
            Console.WriteLine("Cloned: {0}", c2.Id);
        }
        static void RunPrototypeRealWorld()
        {
            ColorManager colormanager = new ColorManager();

            // Initialize with standard colors
            colormanager["red"] = new Color(255, 0, 0);
            colormanager["green"] = new Color(0, 255, 0);
            colormanager["blue"] = new Color(0, 0, 255);

            // User adds personalized colors
            colormanager["angry"] = new Color(255, 54, 0);
            colormanager["peace"] = new Color(128, 211, 128);
            colormanager["flame"] = new Color(211, 34, 20);

            // User clones selected colors
            Color color1 = colormanager["red"].Clone() as Color;
            Color color2 = colormanager["peace"].Clone() as Color;
            Color color3 = colormanager["flame"].Clone() as Color;
        }

        static void RunSingleton()
        {
            // 单体对象只有一个
            // 单体构造函数不能是public 防止重复
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            // Test for same instance
            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }
        }
        static void RunSingletonRealWorld()
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            // Same instance?
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            // Load balance 15 server requests
            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }
        }
        #endregion

        #region Behavioral

        static void RunChainofResp()
        {
            // 职责链 更在于链式结构  类与类之间存在依赖关系
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            // Generate and process request
            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }
        }
        static void RunChainofRespRealWorld()
        {
            // Setup Chain of Responsibility
            Approver larry = new ChainofRespDirector();
            Approver sam = new VicePresident();
            Approver tammy = new President();

            larry.SetSuccessor(sam);
            sam.SetSuccessor(tammy);

            // Generate and process purchase requests
            Purchase p = new Purchase(2034, 350.00, "Assets");
            larry.ProcessRequest(p);

            p = new Purchase(2035, 32590.10, "Project X");
            larry.ProcessRequest(p);

            p = new Purchase(2036, 122100.00, "Project Y");
            larry.ProcessRequest(p);

        }
        static void RunCommand()
        {
            // 发起者 命令 接收者 三者脱离
            // Create receiver, command, and invoker
            Receiver receiver = new Receiver();
            SimpleCommand command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            // Set and execute command
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
        static void RunCommandRealWorld()
        {
            // Create user and let her compute
            User user = new User();

            // User presses calculator buttons
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            // Undo 4 commands
            user.Undo(4);

            // Redo 3 commands
            user.Redo(3);
        }
        static void RunInterpreter()
        {
            // 解释器在于有个全局类
            InterpreterContext context = new InterpreterContext();

            // Usually a tree 
            ArrayList list = new ArrayList();

            // Populate 'abstract syntax tree' 
            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());

            // Interpret
            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }
        }
        static void RunInterpreterRealWorld()
        {
            string roman = "MCMXXVIII";
            Context context = new Context(roman);

            // Build the 'parse tree'
            List<Expression> tree = new List<Expression>();
            tree.Add(new ThousandExpression());
            tree.Add(new HundredExpression());
            tree.Add(new TenExpression());
            tree.Add(new OneExpression());

            // Interpret
            foreach (Expression exp in tree)
            {
                exp.Interpret(context);
            }

            Console.WriteLine("{0} = {1}",
              roman, context.Output);
        }
        static void RunIterator()
        {
            // 对象的一个集合
            ConcreteAggregate a = new ConcreteAggregate();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";

            // Create Iterator and provide aggregate
            SimpleIterator i = a.CreateIterator();

            Console.WriteLine("Iterating over collection:");

            object item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }
        }
        static void RunIteratorRealWorld()
        {
            // Build a collection
            Collection collection = new Collection();
            collection[0] = new Item("Item 0");
            collection[1] = new Item("Item 1");
            collection[2] = new Item("Item 2");
            collection[3] = new Item("Item 3");
            collection[4] = new Item("Item 4");
            collection[5] = new Item("Item 5");
            collection[6] = new Item("Item 6");
            collection[7] = new Item("Item 7");
            collection[8] = new Item("Item 8");

            // Create iterator
            Iterator iterator = collection.CreateIterator();

            // Skip every other item
            iterator.Step = 2;

            Console.WriteLine("Iterating over collection:");

            for (Item item = iterator.First();
                !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item.Name);
            }
        }
        static void RunMediator()
        {
            // 中介含有所有具体的操作类 每个类含有一个中介
            ConcreteMediator m = new ConcreteMediator();

            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);

            m.Colleague1 = c1;
            m.Colleague2 = c2;

            c1.Send("How are you?");
            c2.Send("Fine, thanks");
        }
        static void RunMediatorRealWorld()
        {
            Chatroom chatroom = new Chatroom();

            // Create participants and register them
            Participant George = new Beatle("George");
            Participant Paul = new Beatle("Paul");
            Participant Ringo = new Beatle("Ringo");
            Participant John = new Beatle("John");
            Participant Yoko = new NonBeatle("Yoko");

            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);

            // Chatting participants
            Yoko.Send("John", "Hi John!");
            Paul.Send("Ringo", "All you need is love");
            Ringo.Send("George", "My sweet Lord");
            Paul.Send("John", "Can't buy me love");
            John.Send("Yoko", "My sweet love");
        }
        static void RunMemento()
        {
            // 可以理解用一个类来储存另一个类状态
            Originator o = new Originator();
            o.State = "On";

            // Store internal state
            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();

            // Continue changing originator
            o.State = "Off";

            // Restore saved state
            o.SetMemento(c.Memento);
        }
        static void RunMementoRealWorld()
        {
            SalesProspect s = new SalesProspect();
            s.Name = "Noel van Halen";
            s.Phone = "(412) 256-0990";
            s.Budget = 25000.0;

            // Store internal state
            ProspectMemory m = new ProspectMemory();
            m.Memento = s.SaveMemento();

            // Continue changing originator
            s.Name = "Leo Welch";
            s.Phone = "(310) 209-7111";
            s.Budget = 1000000.0;

            // Restore saved state
            s.RestoreMemento(m.Memento);
        }
        static void RunObserver()
        {
            // 一对多 一个变化 通知多个
            // Configure Observer pattern
            ConcreteSubject s = new ConcreteSubject();

            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));

            // Change subject and notify observers
            s.SubjectState = "ABC";
            s.Notify();
        }
        static void RunObserverRealWorld()
        {
            IBM ibm = new IBM("IBM", 120.00);
            ibm.Attach(new Investor("Sorros"));
            ibm.Attach(new Investor("Berkshire"));

            // Fluctuating prices will notify investors
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;
        }
        static void RunState()
        {
            // 有个全局环境类 用以检测状态变化
            // Setup context in a state
            StateContext c = new StateContext(new ConcreteStateA());

            // Issue requests, which toggles state
            c.Request();
            c.Request();
            c.Request();
            c.Request();
        }
        static void RunStateRealWorld()
        {
            // Open a new account
            Account account = new Account("Jim Johnson");

            // Apply financial transactions
            account.Deposit(500.0);
            account.Deposit(300.0);
            account.Deposit(550.0);
            account.PayInterest();
            account.Withdraw(2000.00);
            account.Withdraw(1100.00);
        }
        static void RunStrategy()
        {
            // 一个全局类
            StrategyContext context;

            // Three contexts following different strategies
            context = new StrategyContext(new ConcreteStrategyA());
            context.ContextInterface();

            context = new StrategyContext(new ConcreteStrategyB());
            context.ContextInterface();

            context = new StrategyContext(new ConcreteStrategyC());
            context.ContextInterface();
        }
        static void RunStrategyRealWorld()
        {
            // Two contexts following different strategies
            StragegySortedList studentRecords = new StragegySortedList();

            studentRecords.Add("Samual");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");

            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();
        }
        static void RunTemplateMethod()
        {
            AbstractClass aA = new ConcreteClassA();
            aA.TemplateMethod();

            AbstractClass aB = new ConcreteClassB();
            aB.TemplateMethod();
        }
        static void RunTemplateMethodRealWorld()
        {
            DataAccessObject daoCategories = new Categories();
            daoCategories.Run();

            DataAccessObject daoProducts = new Products();
            daoProducts.Run();
        }
        static void RunVisitor()
        {
            // 多对多的关系
            // Setup structure
            ObjectStructure o = new ObjectStructure();
            o.Attach(new ConcreteElementA());
            o.Attach(new ConcreteElementB());

            // Create visitor objects
            ConcreteVisitor1 v1 = new ConcreteVisitor1();
            ConcreteVisitor2 v2 = new ConcreteVisitor2();

            // Structure accepting visitors
            o.Accept(v1);
            o.Accept(v2);
        }
        static void RunVisitorRealWorld()
        {
            // Setup employee collection
            Employees e = new Employees();
            e.Attach(new Clerk());
            e.Attach(new VisitorDirector());
            e.Attach(new VisitorPresident());

            // Employees are 'visited'
            e.Accept(new IncomeVisitor());
            e.Accept(new VacationVisitor());
        }

        #endregion

        #region Structural

        static void RunAdapter()
        {
            // 适配器为中转类 用于调节用户使用接口 和目标接口
            // Create adapter and place a request
            Target target = new Adapter();
            target.Request();
        }
        static void RunAdapterRealWorld()
        {
            // Non-adapted chemical compound
            Compound unknown = new Compound("Unknown");
            unknown.Display();

            // Adapted chemical compounds
            Compound water = new RichCompound("Water");
            water.Display();

            Compound benzene = new RichCompound("Benzene");
            benzene.Display();

            Compound ethanol = new RichCompound("Ethanol");
            ethanol.Display();
        }

        static void RunBridge()
        {
            // 抽象与实现之间分离开【不采用继承方式】
            // 实现方式可以多样化【继承】
            Abstraction ab = new RefinedAbstraction();

            // Set implementation and call
            ab.Implementor = new ConcreteImplementorA();
            ab.Operation();

            // Change implemention and call
            ab.Implementor = new ConcreteImplementorB();
            ab.Operation();
        }
        static void RunBridgeRealWorld()
        {
            // Create RefinedAbstraction
            Customers customers = new Customers("Chicago");

            // Set ConcreteImplementor
            customers.Data = new CustomersData();

            // Exercise the bridge
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Add("Henry Velasquez");

            customers.ShowAll();
        }

        static void RunComposite()
        {
            // 复合对象针对树结构 最底层节点为叶子节点 复合节点可包含叶子
            // Create a tree structure
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));

            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            // Add and remove a leaf
            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            root.Display(1);
        }
        static void RunCompositeRealWorld()
        {
            // Create a tree structure 
            CompositeElement root =
              new CompositeElement("Picture");
            root.Add(new PrimitiveElement("Red Line"));
            root.Add(new PrimitiveElement("Blue Circle"));
            root.Add(new PrimitiveElement("Green Box"));

            // Create a branch
            CompositeElement comp =
              new CompositeElement("Two Circles");
            comp.Add(new PrimitiveElement("Black Circle"));
            comp.Add(new PrimitiveElement("White Circle"));
            root.Add(comp);

            // Add and remove a PrimitiveElement
            PrimitiveElement pe =
              new PrimitiveElement("Yellow Line");
            root.Add(pe);
            root.Remove(pe);

            // Recursively display nodes
            root.Display(1);
        }

        static void RunDecorator()
        {
            // 装饰更在于给产品赋予额外的行为
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();
        }
        static void RunDecoratorRealWorld()
        {
            // Create book
            Book book = new Book("Worley", "Inside ASP.NET", 10);
            book.Display();

            // Create video
            Video video = new Video("Spielberg", "Jaws", 23, 92);
            video.Display();

            // Make video borrowable, then borrow and display
            Console.WriteLine("\nMaking video borrowable:");

            Borrowable borrowvideo = new Borrowable(video);
            borrowvideo.BorrowItem("Customer #1");
            borrowvideo.BorrowItem("Customer #2");

            borrowvideo.Display();
        }

        static void RunFacade()
        {
            // 外观只有一个接口  内部把其他子接口封装起来
            Facade facade = new Facade();

            facade.MethodA();
            facade.MethodB();
        }
        static void RunFacadeRealWorld()
        {
            Mortgage mortgage = new Mortgage();

            // Evaluate mortgage eligibility for customer
            Customer customer = new Customer("Ann McKinsey");
            bool eligible = mortgage.IsEligible(customer, 125000);

            Console.WriteLine("\n" + customer.Name +
                " has been " + (eligible ? "Approved" : "Rejected"));
        }

        static void RunFlyWeight()
        {
            // 享元模式更在于对象的重复利用 对象可以存储在内存中 或其他地方
            // Arbitrary extrinsic state
            int extrinsicstate = 22;

            FlyweightFactory factory = new FlyweightFactory();

            // Work with different flyweight instances
            Flyweight fx = factory.GetFlyweight("X");
            fx.Operation(--extrinsicstate);

            Flyweight fy = factory.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);

            Flyweight fz = factory.GetFlyweight("Z");
            fz.Operation(--extrinsicstate);

            UnsharedConcreteFlyweight fu = new
              UnsharedConcreteFlyweight();

            fu.Operation(--extrinsicstate);
        }
        static void RunFlyWeightRealWorld()
        {
            // Build a document with text
            string document = "AAZZBBZB";
            char[] chars = document.ToCharArray();

            CharacterFactory factory = new CharacterFactory();

            // extrinsic state
            int pointSize = 10;

            // For each character use a flyweight object
            foreach (char c in chars)
            {
                pointSize++;
                Character character = factory.GetCharacter(c);
                character.Display(pointSize);
            }
        }

        static void RunProxy()
        {
            // 代理和适配的区别 是都可以直接访问对象 
            Proxy proxy = new Proxy();
            proxy.Request();
        }
        static void RunProxyRealWorld()
        {
            // Create math proxy
            MathProxy proxy = new MathProxy();

            // Do the math
            Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
            Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));
        }

        #endregion
    }
}

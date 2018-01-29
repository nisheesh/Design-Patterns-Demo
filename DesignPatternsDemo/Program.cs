using System;
using System.Collections.Generic;
using DesignPatternsDemo.Decorator_Pattern.Component;
using DesignPatternsDemo.Decorator_Pattern.Concrete_Components;
using DesignPatternsDemo.Decorator_Pattern.Concrete_Decorators;
using DesignPatternsDemo.Facade_Pattern;
using DesignPatternsDemo.Facade_Pattern.SubSystems;
using DesignPatternsDemo.Observer_Pattern;

namespace DesignPatternsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInput = 0;
            do
            {
                userInput = DisplayMenu();
                switch (userInput)
                {
                    case 1:
                        DecoratorPattern();
                        break;
                    case 2:
                        FacadePattern();
                        break;
                    case 3:
                        ObserverPattern();
                        break;
                }
            } while (userInput != 0);
        }

        #region Menu
        private static int DisplayMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("============================== MENU ====================================");
            Console.WriteLine("Choose your Option:");
            Console.WriteLine();
            Console.WriteLine("1. Decorator Pattern");
            Console.WriteLine("2. Facade Pattern");
            Console.WriteLine("3. Observer Pattern");
            Console.WriteLine("0. Exit");
            Console.Write("Choose Your Option: ");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
        #endregion

        #region Decorator Pattern
        private static void DecoratorPattern()
        {
            Console.WriteLine("");
            Console.WriteLine("========================= Decorator Pattern ========================");

            // Let us create a Simple Cake Base first
            CakeBase cBase = new CakeBase();
            PrintProductDetails(cBase);

            //Lets add some cream, to cake
            CreamDecorator creamCake = new CreamDecorator(cBase);
            PrintProductDetails(creamCake);

            //Lets add cherry to my base cake.
            CherryDecorator cherryCake = new CherryDecorator(cBase);
            PrintProductDetails(cherryCake);

            //Lets add cherry to my cream cake.
            CherryDecorator cherryCreamCake = new CherryDecorator(creamCake);
            PrintProductDetails(cherryCreamCake);

            NamemDecorator namecake = new NamemDecorator(cherryCreamCake);
            PrintProductDetails(namecake);
            // Pastry product will be here.

            Console.ReadKey();
            Console.WriteLine("");
        }

        private static void PrintProductDetails(IBakeryComponent component)
        {
            Console.WriteLine(); // some whitespace for readability
            Console.WriteLine("Item: {0}, Price: {1}", component.GetName(), component.GetPrice());
        }
        #endregion

        #region Facade Pattern

        private static void FacadePattern()
        {
            Console.WriteLine("");
            Console.WriteLine("========================= Facade Pattern ========================");
            OnlineShoppingSystem();

            Console.ReadKey();

            OnlineShoppingSystem_WithFacade();

            Console.ReadKey();
            Console.WriteLine("");
        }

        private static void OnlineShoppingSystem()
        {
            Console.WriteLine("");
            Console.WriteLine("================ Online Shopping Without Facade Object ===============");
            Console.WriteLine("");

            // Creating the Order/Product details
            OrderDetails orderDetails = new OrderDetails(
                                                         "C# Design Pattern Book",      //Product Name
                                                         "Simplified book on design patterns in C#",    //Description
                                                          500,  //Price
                                                          10,   //Discount in %
                                                          "SF-1, Chitrakut Complex",    //Address Line 1
                                                          "Nr. Pasha Bhai Park, Gotri, Vadodara, Gujarat, India", //Address Line 2 
                                                          390007, // Pincode
                                                          "4156213754" //Card details
                                                         );


            // Updating the inventory.
            IInventory inventory = new InventoryManager();
            inventory.Update(orderDetails.ProductNo);

            // Verfying various details for the order such as the shipping address.
            IOrderVerify orderVerify = new OrderVerificationManager();
            orderVerify.VerifyShippingAddress(orderDetails.PinCode);

            // Calculating the final cost after applying various discounts.
            ICosting costManger = new CostManager();
            orderDetails.Price = costManger.ApplyDiscounts(orderDetails.Price, orderDetails.DiscountPercent);

            // Going through various steps if payment gateway like card verification, charging from the card.
            IPaymentGateway paymentGateWay = new PaymentGatewayManager();
            paymentGateWay.VerifyCardDetails(orderDetails.CardNo);
            paymentGateWay.ProcessPayment(orderDetails.CardNo, orderDetails.Price);

            // Completing the order by providing Logistics.
            ILogistics logistics = new LogisticsManager();
            logistics.ShipProduct(orderDetails.ProductName, $"{orderDetails.AddressLine1}, {orderDetails.AddressLine2} - {orderDetails.PinCode}.");
        }


        private static void OnlineShoppingSystem_WithFacade()
        {
            Console.WriteLine("");
            Console.WriteLine("================ Online Shopping With Facade Object ==================");
            Console.WriteLine("");
            // Creating the Order/Product details
            OrderDetails orderDetails = new OrderDetails(
                                                         "C# Design Pattern Book",      //Product Name
                                                         "Simplified book on design patterns in C#",    //Description
                                                          500,  //Price
                                                          10,   //Discount in %
                                                          "SF-1, Chitrakut Complex",    //Address Line 1
                                                          "Nr. Pasha Bhai Park, Gotri, Vadodara, Gujarat, India", //Address Line 2 
                                                          390007, // Pincode
                                                          "4156213754" //Card details
                                                         );

            // Using Facade
            OnlineShoppingFacade facade = new OnlineShoppingFacade();
            facade.FinalizeOrder(orderDetails);
        }
        #endregion

        #region Observer Pattern
        private static void ObserverPattern()
        {
            Console.WriteLine("");
            Console.WriteLine("========================= Observer Pattern ========================");

            Subject store = new Subject();

            // Observer1 takes a subscription to the store
            Observer nisheesh = new Observer("Nisheesh");
            store.Subscribe(new Observer("Nisheesh"));

            // Observer2 also subscribes to the store
            Observer mahek = new Observer("Mahek");
            store.Subscribe(mahek);

            Console.WriteLine("========== UPDATE 1 =============");
            store.Inventory++;
            Console.ReadKey();

            //Nisheesh unsubscribes and Jignesh subscribes to notifications.
            store.Unsubscribe(nisheesh);
            Observer jignesh = new Observer("Jignesh");
            store.Subscribe(jignesh);

            Console.WriteLine("========== UPDATE 2 =============");
            store.Inventory++;

            Console.ReadKey();
            Console.WriteLine("");
        }
        #endregion

        #region Program To Interface

        private static void ProgramToInterfaceNotImplementation()
        {
            #region Maintainability
            LoggerBad loggerBad = new LoggerBad();
            loggerBad.LogMessage("test");

            IEnumerable<string> logs = loggerBad.GetLast10Messages();

            foreach (string s in logs)
            {
                Console.WriteLine(s);
            }
            #endregion

            #region Extensibility
            ILogger loggerToFile = new LogToFile();
            loggerToFile.LogMessage("This message would be logged in file");

            ILogger loggerToCloud = new LogToCloud();
            loggerToCloud.LogMessage("This message would be logged in cloud");

            ILogger loggerTodb = new LogToDb();
            loggerTodb.LogMessage("This message would be logged in db");
            #endregion
        }
        #endregion
    }

    #region Maintainablity
    class LoggerBad
    {
        public void LogMessage(string msg)
        {
            Console.WriteLine("Log Message -" + msg);
        }

        public string[] GetLast10Messages()
        {
            return new string[]
            {
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
            };
        }

        //public List<string> GetLast10Messages()
        //{
        //    return new List<string>(){
        //    "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
        //    };
        //}
    }
    #endregion

    #region Extensibility
    interface ILogger
    {
        void LogMessage(string msg);
    }

    class LogToFile : ILogger
    {
        public void LogMessage(string msg)
        {
            // Log the message to file
        }
    }

    class LogToCloud : ILogger
    {
        public void LogMessage(string msg)
        {
            // Log the message to cloud.
        }
    }

    class LogToDb : ILogger
    {
        public void LogMessage(string msg)
        {
            Console.WriteLine("Log to DB");
        }
    }

    #endregion
}

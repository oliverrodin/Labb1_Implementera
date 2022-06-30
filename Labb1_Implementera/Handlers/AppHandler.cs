using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb1_Implementera.Singelton;
using Labb1_Implementera.Strategy;

namespace Labb1_Implementera.Handlers
{
    public class AppHandler
    {
        /// <summary>
        /// Hälsar användare välkommen
        /// </summary>
        public void Welcome()
        {
            Console.WriteLine("Welcome to the Speaker Rental Store!\n" +
                              "We help you to create amazing sound on your party or concert!\n" +
                              "But first who are you?\n" +
                              "");
        }

        /// <summary>
        /// Användare får skriva in personuppgifter som sparas i min singelton class
        /// </summary>
        public void AddCostumerInformation()
        {
            var fullName = "";
            var email = "";
            var address = "";

            Console.Write("Your full name: ");
            fullName = Console.ReadLine();
            Console.Clear();

            Console.Write("Your email: ");
            email = Console.ReadLine();
            Console.Clear();

            Console.Write("Your address: ");
            address = Console.ReadLine();
            Console.Clear();

            //Skapar singelton instance och asignar properties till den.
            UserInformation customer = UserInformation.Instance;
            UserInformation.Instance.Fullname = fullName;
            UserInformation.Instance.Email = email;
            UserInformation.Instance.Address = address;

            //Här använder jag singelton properties för att skriva ut dessa i konsollen. 
            Console.WriteLine($"This is you:\n" +
                              $"\n" +
                              $"{UserInformation.Instance.Fullname}\n" +
                              $"{UserInformation.Instance.Email}\n" +
                              $"{UserInformation.Instance.Address}" +
                              $"\n" +
                              $"Please press enter to go to next step!");
            Console.ReadLine();
            Console.Clear();



        }

        public void ChoosePackage()
        {
            bool run = true;
            do
            {
                Console.WriteLine("Please choose an alternative to see if it fits your happening!\n" +
                                  "");
                Console.WriteLine("\n" +
                                  "1. Big Speaker Package\n" +
                                  "2. Medium Speaker Package\n" +
                                  "3. Small Speaker Package\n" +
                                  "");
                var input = ParseInt(Console.ReadLine());

                if (input < 0 || input > 3)
                {
                    Console.WriteLine("Invalid input, press enter and try again!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    var packageDetails = ShowPackageDetails(input);

                    Console.WriteLine($"\n" +
                                      $"Enter (yes) to accept or (no) to go back: ");
                    var validateInput = Console.ReadLine();

                    if (validateInput.ToLower() == "yes")
                    {
                        run = false;
                        DeliveryType(packageDetails);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        continue;
                    }


                    
                }
            } while (run);


        }
        /// <summary>
        /// method med funktionalitet och hanteringen av mitt strategy pattern som består
        /// av olika delivery typer
        /// </summary>
        /// <param name="chosenPackage"></param>
        public void DeliveryType(ISpeakerPackage chosenPackage)
        {
            //Instansierar contextet från strategy patternet
            var deliveryType = new DeliveryContext();

            var deliveryCost = 0.0m;
            bool run = true;
            do
            {
                Console.Clear();
                Console.WriteLine("¤¤¤¤ Delivery ¤¤¤¤\n" +
                                 "------------------\n" +
                                 "\n" +
                                 "\n" +
                                 "Please choose a delivery option:\n" +
                                 "\n" +
                                 "1. Pick up at warehouse.\n" +
                                 "2. Delivery to address.\n" +
                                 "3. Delivery to address and setup.");

                var input = ParseInt(Console.ReadLine());

                if (input < 0 || input > 3)
                {
                    Console.WriteLine("Invalid input, press enter and try again!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    run = false;
                    // Sätter och Anropar den rätta strategien baserat på användarens val.
                    switch (input)
                    {
                        case 1:
                            deliveryType.SetDeliveryType(new WarehousePickup());
                            deliveryCost = deliveryType.GetDeliveryCost();
                            break;
                        case 2:
                            deliveryType.SetDeliveryType(new HomeDelivery());
                            deliveryCost = deliveryType.GetDeliveryCost();
                            break;
                        case 3:
                            deliveryType.SetDeliveryType(new HomeDeliveryWithSetup());
                            deliveryCost = deliveryType.GetDeliveryCost();
                            break;
                    }

                    //Skriver ut kvitto hämtar personuppgifter från singelton
                    //hämtar valt speaker package 
                    //oc vald delivery typ
                    Console.Clear();
                    Console.WriteLine($"######## Receipt #########\n" +
                                      $"--------------------------\n" +
                                      $"Customer:\n" +
                                      $"{UserInformation.Instance.Fullname}\n" +
                                      $"{UserInformation.Instance.Email}\n" +
                                      $"{UserInformation.Instance.Address}\n" +
                                      $"--------------------------\n" +
                                      $"{chosenPackage.GetPackageName()}:\n" +
                                      $"-- ${chosenPackage.GetPrice()}\n" +
                                      $"\n" +
                                      $"{deliveryType.GetDelivaryType()}:\n" +
                                      $"-- ${deliveryType.GetDeliveryCost()}\n" +
                                      $"--------------------------\n" +
                                      $"Total cost:\n" +
                                      $"-- ${chosenPackage.GetPrice() + deliveryType.GetDeliveryCost()}\n" +
                                      $"--------------------------\n" +
                                      $"Thank you {UserInformation.Instance.Fullname} for your order!");
                    Console.WriteLine("\n" +
                                      "Press enter to quit!");
                    Console.ReadLine();

                } 
            } while (run);


        }

        private ISpeakerPackage ShowPackageDetails(int input)
        {
            Console.Clear();

            // Kallar på factoryklassen i factory method pattern.  
            var packageDetails = SpeakerPackageFactory.GetSpeakerPackage(input);

            Console.WriteLine($"Package name: {packageDetails.GetPackageName()} ");
            Console.WriteLine($"Price: ${packageDetails.GetPrice()}");
            Console.WriteLine($"Coverage: for venues with max {packageDetails.GetAudienceCoverage()} people\n");

            

            return packageDetails;

        }

        private int ParseInt(string input)
        {
            bool isNumeric;
            int output;

            isNumeric = int.TryParse(input, out output);

            if (isNumeric)
            {
                return output;
            }
            else
            {
                return -1;
            }
        }
    }
}

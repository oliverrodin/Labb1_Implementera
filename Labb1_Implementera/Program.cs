
//Factory Method, 

using Labb1_Implementera.Handlers;

namespace Labb1_Implementera
{
    public class Program
    {
        // Jag Använder mig av factory method pattern, Singelton Pattern och Stratrgy Pattern.
        static void Main(string[] args)
        {
            AppHandler run = new AppHandler();

            run.Welcome();
            run.AddCostumerInformation();
            run.ChoosePackage();
            
            Console.ReadLine();
        }

        
    }
}


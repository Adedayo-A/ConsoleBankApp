using BankApp.Pages;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FactoryClass nFactoryClass = new FactoryClass();

                WelcomePage.Menu(nFactoryClass);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("---------------");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
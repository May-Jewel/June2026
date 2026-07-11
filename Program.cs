using System.Security.Cryptography.X509Certificates;
using static JuneC_.ConsoleApp1.Program;

namespace JuneC_.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello, World!");
            Console.ReadKey();
            string message=Console.ReadLine();
            Console.WriteLine("Hello "+ message);
            Console.ReadLine();*/
            //Console.Write("Pleas enter number:");
            //string d = Console.ReadLine();
            //int result = Convert.ToInt32(d);
            //string p = "Mg Mg";
            //p = "Aung Aung";
            //var message2 = "Your name is" + d + "ma mg";
            //var message3 = $"Your name is\" + {d} + \"ma mg";
            //DateTime dt;
            //Console.ReadLine();



            PaymentType payment = PaymentType.QRPay;
            if (payment == PaymentType.WavePay)
            {

            }
            else if (payment == PaymentType.AYAPay)
            {

            }
            else
            {
                throw new Exception("Invalid payment");
            }

            switch (payment)
            {
                case PaymentType.KBZPay:
                    break;
                case PaymentType.WavePay:
                    break;
                case PaymentType.AYAPay:
                    break;
                case PaymentType.QRPay:
                    break;
                default:
                    throw new Exception("Invalid type");
            }
            Console.ReadLine();
        }
        public enum PaymentType
        {
            None,
            KBZPay,
            WavePay,
            AYAPay,
            QRPay
        }
    }
}
public class TansferService
{
    public void WalletTransfer(string fromMoblieNo, string toMobileNo, decimal amount)
    {

    }
}

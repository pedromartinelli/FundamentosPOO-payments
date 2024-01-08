using System;

namespace Payments
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using and Dispose
            using (var payment = new BoletoPayment(DateTime.Now.AddMonths(1)))
            {
                payment.Pay("342131");
            }
        }
    }

    /*  
        Modificadores de acesso: 
        private: acessado apenas dentro da classe
        protected: acessado dentro da classe e pelos filhos
        internal: acessado dentro da classe, pelos filhos e no namespace
        public: acessado em toda a aplicação 
    */

    // Encapsulamento   // Using and Dispose
    public class Payment : IDisposable
    {

        // Método construtor
        public Payment(DateTime expireAt)
        {

        }

        // Propriedades
        public DateTime ExpireAt { get; set; }
        public Address BillingAddress { get; set; }

        // Métodos     // Assinatura do método
        public virtual void Pay(string number) { }

        // Sobrecarga de método        // Assinatura do método
        public virtual void Pay(string number, DateTime paymentDate) { }

        // Polimorfismo
        public override string ToString()
        {
            return ExpireAt.ToString("dd,mm,aa");
        }

        // Using and Dispose
        public virtual void Dispose() 
        {
            Console.WriteLine("Finalizando pagamento\n");
        }
    }

                            // Herança
    public class BoletoPayment : Payment
    {

        // Método construtor
        public BoletoPayment(DateTime expireAt) : base(expireAt)
        {
            Console.WriteLine($"\nIniciando pagamento com boleto... \n*Vencimento: {expireAt}\n");
        }


        public string BoletoNumber { get; set; }

        // Polimorfismo
        // Sobrescrita de métodos
        public override void Pay(string number) 
        {
            Console.WriteLine($"Pagar com boleto de numero {number}\n");
        }
    }

       // Classe selada - não pode ser extendida
    public sealed class CreditCardPayment : Payment 
    {

        // Método construtor
        public CreditCardPayment(DateTime expireAt) : base(expireAt)
        {

        }

        public string CreditCardNumber { get; set; }

        // Polimorfismo
        public override void Pay(string number) 
        {
            InstallmentsPay("10");
        }

        // Abstração
        private void InstallmentsPay(string number)
        {

        }
    }

    // Classe estatica - não pode ser instanciada
    public static class Settings
    {
        public static string API_URL { get; set; }
    }

    // Tipos complexos
    public class Address
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
    }

    public enum PaymentType
    {
        Boleto = 1,
        CreditCard = 2
    }
}
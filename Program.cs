using System;

namespace Payments
{
    class Program
    {
        static void Main(string[] args)
        {
            var payment = new BoletoPayment();
            payment.Pay("123");
        }
    }

    /* Modificadores de acesso: 
        private: acessado apenas dentro da classe
        protected: acessado dentro da classe e pelos filhos
        internal: acessado dentro da classe, pelos filhos e no namespace
        public: acessado em toda a aplicação 
     */

    // Encapsulamento
    public class Payment
    {
        // Propriedades
        public DateTime ExpireAt { get; set; }
        public Address BillingAddress { get; set; }

        // Métodos
        public virtual void Pay(string number) 
        {
            Console.WriteLine("Pagar");
        }

        // Sobrecarga de método
        public virtual void Pay(string number, DateTime paymentDate) { }

        // Polimorfismo
        public override string ToString()
        {
            return ExpireAt.ToString("dd,mm,aa");
        } 
    }

    // Herança
    class BoletoPayment : Payment
    {
        public string BoletoNumber { get; set; }

        // Polimorfismo
        // Sobrescrita de métodos
        public override void Pay(string number) 
        {
            base.Pay(number);
            Console.WriteLine($"Pagar com boleto de numero {number}");
        }

    }

    class CreditCardPayment : Payment 
    {
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

    // Tipos complexos
    public class Address
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
    }
}
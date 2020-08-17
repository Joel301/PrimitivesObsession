using System;

namespace PrimitivesObsession
{
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = new Cliente(Guid.NewGuid(), "000.000.000-00");

            Console.ReadLine();
        }
    }

    public class Cliente
    {
        public Cliente(Guid id, Cpf cpf)
        {
            Id = id;
            Cpf = cpf;
        }

        public Guid Id { get; set; }

        public Cpf Cpf { get; set; }
    }

    public struct Cpf
    {
        private readonly string _value;

        private Cpf(string value)
        {
            _value = value;
        }

        public override string ToString() 
            => _value;

        public static Cpf Parse(string value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new ArgumentException("CPF inválido");
        }

        public static bool TryParse(string value, out Cpf cpf)
        {            
            cpf = new Cpf(value);

            // lógica de validação...

            return false;
        }

        public static implicit operator Cpf(string value)
            => Parse(value);
    }
}

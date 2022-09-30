namespace Desafio.Internal.Talent.Api
{
    public class Cliente : ICliente
    {
        public Guid Id { get;  set; }

        public string FirstName { get;  set; }

        public string SecondName { get;  set; }

        public int Age { get;  set; }

        public DateTime Born { get;  set; }

        public Cliente(string firstName, string secondName, int age, DateTime born)
        {
            FirstName = firstName;
            SecondName = secondName;
            Age = age;
            Born = born;
        }

        public Cliente()
        {
        }

        public void CadastrarCliente(string cliente)
        {
            throw new NotImplementedException();
        }

        public void ObterCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void ExcluirCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
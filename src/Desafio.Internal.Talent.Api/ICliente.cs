namespace Desafio.Internal.Talent.Api
{
    public interface ICliente
    {
        void CadastrarCliente(string cliente);
        void ObterCliente(Cliente cliente);
        void ExcluirCliente(Cliente cliente);
    }
}

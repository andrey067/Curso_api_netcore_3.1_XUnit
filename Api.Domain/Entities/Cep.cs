using Api.Domain.Entities;

namespace Domain.Entities
{
    public class Cep : BaseEntity
    {
        public string NumeroCep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public long MunicipioId { get; private set; }
        public virtual Municipio Municipio { get; private set; }

        //EF Core
        protected Cep() { }

        public Cep(string numeroCep, string logradouro, string numero, long municipioId)
        {
            NumeroCep = numeroCep;
            Logradouro = logradouro;
            Numero = numero;
            MunicipioId = municipioId;
        }

        public void AlterarNumeroCep(string novoNumeroCep) => NumeroCep = novoNumeroCep;
        public void AlterarLogradouro(string novoLogradouro) => Logradouro = novoLogradouro;
        public void AlterarNumero(string novoNumero) => Numero = novoNumero;
        public void AlterarMunicipioId(long novoMunicipioId) => MunicipioId = novoMunicipioId;
    }
}

using Api.Domain.Entities;

namespace Domain.Entities
{
    public class Municipio : BaseEntity
    {
        public string Nome { get; private set; }
        public int CodIBGE { get; private set; }
        public long UfId { get; private set; }
        public virtual Uf Uf { get; private set; }

        public Municipio(string nome, int codIBGE, long ufId)
        {
            Nome = nome;
            CodIBGE = codIBGE;
            UfId = ufId;
        }


        public void AlterarNome(string nome) => Nome = nome;
        public void AlterarCodIBGE(int codIBGE) => CodIBGE = codIBGE;
        public void AlterarUf(long ufId) => UfId = ufId;
    }
}

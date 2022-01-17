using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class MunicipioModel : BaseModel
    {
        private string _nome;
        private int _codIBGE;
        private Guid _ufId;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }


        public int CodIBGE
        {
            get { return _codIBGE; }
            set { _codIBGE = value; }
        }


        public Guid UfId
        {
            get { return _ufId; }
            set { _ufId = value; }
        }


    }
}

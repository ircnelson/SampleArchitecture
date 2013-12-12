using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleArchiteture.Dominio.Exceptions;

namespace SampleArchiteture.Dominio.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; private set; }

        public Cliente()
        {
            Ativo = true;
            Endereco = new Endereco();
        }

        public void Inativar()
        {
            if (!Ativo)
                throw new ClienteException("Este cliente já está inativo.", this);

            Ativo = false;
        }

        public void Ativar()
        {
            if (Ativo)
                throw new ClienteException("Este cliente já está ativo.", this);

            Ativo = true;
        }
    }
}

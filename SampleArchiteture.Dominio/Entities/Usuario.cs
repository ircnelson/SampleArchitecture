using SampleArchiteture.Dominio.Exceptions;

namespace SampleArchiteture.Dominio.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; protected set; }
        public bool RecebeNovidades { get; protected internal set; }

        public virtual Endereco Endereco { get; set; }

        public Usuario()
        {
            Ativo = true;
            Endereco = new Endereco();
        }

        public void Inativar()
        {
            if (!Ativo)
                throw new UsuarioException("Este usuario já está inativo.", this);

            Ativo = false;
        }

        public void Ativar()
        {
            if (Ativo)
                throw new UsuarioException("Este usuario já está ativo.", this);

            Ativo = true;
        }
    }
}

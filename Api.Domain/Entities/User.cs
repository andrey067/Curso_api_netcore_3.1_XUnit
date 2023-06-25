namespace Api.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }

        private void AlterarNome(string nome) => Name = nome;
        private void AlternateEmail(string email) => Email = email;

        public void AlterarUsuario(string nome, string email)
        {
            AlterarNome(nome);
            AlternateEmail(email);
        }
    }
}
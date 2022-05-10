using System;


namespace CadastroCorretores.Models
{
    public class CorretorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; } 
    }
}

using System.Xml.Serialization;

namespace ANP___Atividade___Cliente.Models
{
    public class Cliente
    {
        [XmlRoot("Clientes")]
        public class Clientes
        {
            [XmlElement("Cliente")]
            public List<Cliente> ListaClientes { get; set; }
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Rg {  get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}

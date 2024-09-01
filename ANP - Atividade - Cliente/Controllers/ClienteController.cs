using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using ANP___Atividade___Cliente.Models;
using ANP___Atividade___Cliente.Recursos;
using ANP___Atividade___Cliente.Dtos;
using System.Xml;
using System.Xml.Linq;

namespace ANP___Atividade___Cliente.Controllers
{
    [Route("Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        XmlCriador XmlCriador = new XmlCriador();
        [HttpGet("{Id}")]
        public IActionResult GetByed(int Id)
        {
            XmlCriador.CarregarXml();
            var xml = XDocument.Load("DocumentoXml.XML");
            var ClienteXml = xml.Descendants("Cliente").FirstOrDefault(x => (int)x.Element("Id") == Id);

            if (ClienteXml == null)
            {
                return BadRequest("Cliente não encontrado.");
            }

            return Ok(ClienteXml.ToString());
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClienteDTO item)
        {
            XmlCriador.CarregarXml();
            var xml = XDocument.Load("DocumentoXml.XML");
            int contador = xml.Descendants("Cliente").Count();

            var cliente = new Cliente();

            cliente.Id = contador + 1;
            cliente.Nome = item.Nome;
            cliente.DataNascimento = item.DataNascimento;
            cliente.Sexo = item.Sexo;
            cliente.Rg = item.Rg;
            cliente.Cpf = item.Cpf;

            if(ValidadorCPF.ValidaCPF(cliente.Cpf) == true)
            {
                cliente.Endereco = item.Endereco;
                cliente.Cidade = item.Cidade;
                cliente.Estado = item.Estado;
                cliente.Telefone = item.Telefone;
                cliente.Email = item.Email;

                XmlCriador.GravarXml(cliente);

                return StatusCode(StatusCodes.Status201Created, cliente);
            }
            else
            {
                return BadRequest("CPF Inválido.");
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] ClienteDTO item)
        {
            XmlCriador.CarregarXml();
            var xml = XDocument.Load("DocumentoXml.XML");
            var ClienteXml = xml.Descendants("Cliente").FirstOrDefault(x => (int)x.Element("Id") == Id);

            if (ClienteXml == null)
            {
                return BadRequest("Cliente não encontrado.");
            }

            ClienteXml.Element("Nome").Value = item.Nome;
            ClienteXml.Element("DataNascimento").Value = item.DataNascimento.ToString("dd-MM-yyyy");
            ClienteXml.Element("Sexo").Value = item.Sexo;
            ClienteXml.Element("Rg").Value = item.Rg;
            ClienteXml.Element("Cpf").Value = item.Cpf;

            if (ValidadorCPF.ValidaCPF(ClienteXml.Element("Cpf").Value) == true)
            {
                ClienteXml.Element("Endereco").Value = item.Endereco;
                ClienteXml.Element("Cidade").Value = item.Cidade;
                ClienteXml.Element("Estado").Value = item.Estado;
                ClienteXml.Element("Telefone").Value = item.Telefone;
                ClienteXml.Element("Email").Value = item.Email;

                return Ok(ClienteXml.ToString());
            }
            else
            {
                return BadRequest("CPF Inválido.");
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            XmlCriador.CarregarXml();
            var xml = XDocument.Load("DocumentoXml.XML");
            var ClienteXml = xml.Descendants("Cliente").FirstOrDefault(x => (int)x.Element("Id") == Id);

            if (ClienteXml == null)
            {
                return BadRequest("Cliente não encontrado.");
            }

            ClienteXml.Remove();
            xml.Save("DocumentoXml.XML");

            return Ok(ClienteXml.ToString());
        }
    }
}

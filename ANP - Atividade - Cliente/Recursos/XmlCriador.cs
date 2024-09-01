using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using ANP___Atividade___Cliente.Models;
using Microsoft.AspNetCore.Http;

namespace ANP___Atividade___Cliente.Recursos
{
    internal class XmlCriador
    {
        private string xmlFilePath = "DocumentoXml.XML";
        
        public void CarregarXml()
        {
            XDocument DocumentoXml;

            if (File.Exists(xmlFilePath))
            {
                DocumentoXml = XDocument.Load(xmlFilePath);
            }
            else
            {
                DocumentoXml = new XDocument(new XElement("Clientes"));
                DocumentoXml.Save(xmlFilePath);
            }
        }
        public void GravarXml(Cliente cliente)
        {
            XDocument DocumentoXml;
            DocumentoXml = XDocument.Load(xmlFilePath);

            XElement novoRegistro = new XElement("Cliente",
                new XElement("Id", cliente.Id),
                new XElement("Nome", cliente.Nome.Trim()),
                new XElement("DataNascimento", cliente.DataNascimento),
                new XElement("Sexo", cliente.Sexo.Trim()),
                new XElement("Rg", cliente.Rg.Trim()),
                new XElement("Cpf", cliente.Cpf.Trim()),
                new XElement("Endereco", cliente.Endereco.Trim()),
                new XElement("Cidade", cliente.Cidade.Trim()),
                new XElement("Estado", cliente.Estado.Trim()),
                new XElement("Telefone", cliente.Telefone.Trim()),
                new XElement("Email", cliente.Email.Trim())
            );

            DocumentoXml.Root.Add(novoRegistro);
            DocumentoXml.Save(xmlFilePath);
        }
    }
}

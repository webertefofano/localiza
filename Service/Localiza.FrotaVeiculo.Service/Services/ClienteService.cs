using FluentValidation;
using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Localiza.FrotaVeiculo.Domain.Interfaces;
using Localiza.FrotaVeiculo.Infra.Data.Context.Localiza;
using Localiza.FrotaVeiculo.Service.Services;
using Localiza.FrotaVeiculo.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Service.Services
{
    public class ClienteService : IClienteService
    {   
        private readonly ContextLocaliza _contextLocaliza;

        public ClienteService(ContextLocaliza contextLocaliza)
        {
            _contextLocaliza = contextLocaliza;
        }
           
        /// <summary>
        /// Insere Cliente.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>Retorna o Id inserido</returns>
        public int AddCliente(Cliente cliente)
        {        
            Validators<Cliente>.Validate(cliente, Activator.CreateInstance<ClienteValidator>());
            
            _contextLocaliza.Clientes.Add(cliente);
            _contextLocaliza.SaveChanges();

            return cliente.IdCliente;
        }

        /// <summary>
        /// Listar Cliente pelo CPF e/ou parte do nome.
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public List<Cliente> ListarClientes(long cpf, string nome)
        {
            List<Cliente> clientes = new List<Cliente>();

            if (cpf != 0 && !string.IsNullOrEmpty(nome))
            {
                clientes = (from C in _contextLocaliza.Clientes
                            where C.Cpf == cpf && C.Nome.Contains(nome)
                            select C
                            )
                            .ToList();
            }
            else if (cpf != 0)
            {
                clientes = (from C in _contextLocaliza.Clientes
                            where C.Cpf == cpf
                            select C
                            )
                            .ToList();
            }
            else
            {
                clientes = (from C in _contextLocaliza.Clientes
                            where C.Nome.Contains(nome)
                            select C
                            )
                            .ToList();
            }

            return clientes;
        }


        /// <summary>
        /// Atualiza endereço do Cliente.
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="Endereco"></param>
        /// <param name="Numero"></param>
        /// <param name="Bairro"></param>
        /// <param name="Cidade"></param>
        /// <param name="Estado"></param>
        public void UpdEnderecoCliente(int idCliente, string Endereco, string Numero, string Bairro, string Cidade, string Estado)
        {
            Cliente cliente = _contextLocaliza.Clientes.Find(idCliente);
            cliente.Endereco = Endereco;
            cliente.Numero = Numero;
            cliente.Bairro = Bairro;
            cliente.Cidade = Cidade;
            cliente.Estado = Estado;

            Validators<Cliente>.Validate(cliente, Activator.CreateInstance<ClienteValidator>());

            _contextLocaliza.Clientes.Update(cliente);
            _contextLocaliza.SaveChanges();            
        }
    }
}
using FluentValidation;
using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Domain.Interfaces
{
    public interface IClienteService
    {
        /// <summary>
        /// Insere Cliente.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>Retorna o Id inserido</returns>
        int AddCliente(Cliente cliente);

        /// <summary>
        /// Listar Cliente pelo CPF e/ou parte do nome.
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        List<Cliente> ListarClientes(long cpf, string nome);

        /// <summary>
        /// Atualiza endereço do Cliente.
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="Endereco"></param>
        /// <param name="Numero"></param>
        /// <param name="Bairro"></param>
        /// <param name="Cidade"></param>
        /// <param name="Estado"></param>
        void UpdEnderecoCliente(int idCliente, string Endereco, string Numero, string Bairro, string Cidade, string Estado);
    }
}

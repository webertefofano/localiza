using FluentValidation;
using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Domain.Interfaces
{
    public interface IVeiculoService
    {
        /// <summary>
        /// Insere Veículo.
        /// </summary>
        /// <param name="veiculo"></param>
        /// <returns>Retorna o Id inserido</returns>
        int AddVeiculo(Veiculo veiculo);

        /// <summary>
        /// Busca veículo pela placa.
        /// </summary>        
        /// <param name="placa"></param>
        /// <returns></returns>
        Veiculo BuscaVeiculoPelaPlaca(string placa);

        /// <summary>
        /// Listar Veículo pelo Modelo e/ou Fabricante.
        /// </summary>
        /// <param name="idModelo"></param>
        /// <param name="idFabricante"></param>
        /// <returns></returns>
        List<Veiculo> ListarVeiculos(int idModelo, int idFabricante);
    }
}

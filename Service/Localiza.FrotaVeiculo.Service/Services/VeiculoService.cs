using FluentValidation;
using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Localiza.FrotaVeiculo.Domain.Interfaces;
using Localiza.FrotaVeiculo.Infra.Data.Context.Localiza;
using Localiza.FrotaVeiculo.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Service.Services
{
    public class VeiculoService : IVeiculoService
    {        
        private readonly ContextLocaliza _contextLocaliza;

        public VeiculoService(ContextLocaliza contextLocaliza)
        {
            _contextLocaliza = contextLocaliza;
        }

        /// <summary>
        /// Insere Veículo.
        /// </summary>
        /// <param name="veiculo"></param>
        /// <returns>Retorna o Id inserido</returns>
        public int AddVeiculo(Veiculo veiculo)
        {
            Validators<Veiculo>.Validate(veiculo, Activator.CreateInstance<VeiculoValidator>());

            _contextLocaliza.Veiculos.Add(veiculo);
            _contextLocaliza.SaveChanges();

            return veiculo.IdVeiculo;
        }

        /// <summary>
        /// Busca veículo pela placa.
        /// </summary>        
        /// <param name="placa"></param>
        /// <returns></returns>
        public Veiculo BuscaVeiculoPelaPlaca(string placa)
        {
            Veiculo veiculo = (from V in _contextLocaliza.Veiculos
                               where V.Placa == placa
                               select V
                              )
                              .FirstOrDefault();
                        
            return veiculo;
        }


        /// <summary>
        /// Listar Veículo pelo Modelo e/ou Fabricante.
        /// </summary>
        /// <param name="idModelo"></param>
        /// <param name="idFabricante"></param>
        /// <returns></returns>
        public List<Veiculo> ListarVeiculos(int idModelo, int idFabricante)
        {
            List<Veiculo> veiculos = new List<Veiculo>();

            if (idModelo != 0 && idFabricante != 0)
            {
                veiculos = (from M in _contextLocaliza.Modelos
                            from V in _contextLocaliza.Veiculos.Where(v => v.IdModelo == idModelo)
                            where M.IdFabricante == idFabricante
                            select V
                            )
                            .ToList();
            }
            else if (idModelo != 0)
            {
                veiculos = (from V in _contextLocaliza.Veiculos
                            where V.IdModelo == idModelo
                            select V
                            )
                            .ToList();
            }
            else
            {
                veiculos = (from M in _contextLocaliza.Modelos
                            where M.IdFabricante == idFabricante
                            select M into Modelo
                            from V in _contextLocaliza.Veiculos.Where(v => v.IdModelo == Modelo.IdModelo)
                            select V
                           )
                           .ToList();
            }

            return veiculos;
        }
    }
}
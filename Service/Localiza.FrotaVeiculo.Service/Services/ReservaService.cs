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
    public class ReservaService : IReservaService
    {
        private readonly ContextLocaliza _contextLocaliza;

        public ReservaService(ContextLocaliza contextLocaliza)
        {
            _contextLocaliza = contextLocaliza;
        }

        /// <summary>
        /// Insere Reserva.
        /// </summary>
        /// <param name="reserva"></param>
        /// <returns>Retorna o Id inserido</returns>
        public int AddReserva(Reserva reserva)
        {
            Validators<Reserva>.Validate(reserva, Activator.CreateInstance<ReservaValidator>());

            Reserva reservaVeiculo = (from R in _contextLocaliza.Reservas
                                      where R.IdVeiculo == reserva.IdVeiculo
                                      && R.DataDevolucao == null
                                      select R
                                     ).FirstOrDefault();

            if (reservaVeiculo != null)
            {
                return -1;
            }

            _contextLocaliza.Reservas.Add(reserva);
            _contextLocaliza.SaveChanges();

            return reserva.IdReserva;
        }

        /// <summary>
        /// Listar Reservas de um Cliente.
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public List<Reserva> ListarReservas(int idCliente)
        {
            List<Reserva> reservas = (from R in _contextLocaliza.Reservas
                                      where R.IdCliente == idCliente
                                      select R
                                     )
                                     .ToList();

            return reservas;
        }

        /// <summary>
        /// Listar reservas que já tiveram os veículos retirados pelos respectivos clientes em um intervalo de datas.
        /// </summary>
        /// <param name="dataInicio"></param>
        /// <param name="dataFim"></param>
        /// <returns></returns>
        public List<Reserva> ListarReservasPorDataRetirada(DateTime dataInicio, DateTime dataFim)
        {
            List<Reserva> reservas = (from R in _contextLocaliza.Reservas
                                      where R.VeiculoRetirado == true
                                      && (R.DataRetirada >= dataInicio && R.DataRetirada <= dataFim)
                                      select R
                                     )
                                     .ToList();

            return reservas;
        }

        /// <summary>
        /// Atualiza a data de retirada de uma reserva e a data prevista de devolução.
        /// </summary>
        /// <param name="IdReserva"></param>
        /// <param name="DataRetirada"></param>
        /// <param name="DataPrevistaDevolucao"></param>
        public void UpdDataRetiradaDataPrevista(int idReserva, DateTimeOffset dataRetirada, DateTimeOffset? dataPrevistaDevolucao)
        {
            Reserva reserva = (from R in _contextLocaliza.Reservas
                               where R.IdReserva == idReserva
                               select R
                              )
                              .FirstOrDefault();

            reserva.DataRetirada = dataRetirada;
            reserva.DataPrevistaDevolucao = dataPrevistaDevolucao;
            reserva.VeiculoRetirado = true;

            _contextLocaliza.Reservas.Update(reserva);
            _contextLocaliza.SaveChanges();
        }

        /// <summary>
        /// Atualiza a data de devolução.
        /// </summary>
        /// <param name="IdReserva"></param>        
        /// <param name="DataDevolucao"></param>
        public void UpdDataDevolucao(int idReserva, DateTimeOffset? dataDevolucao)
        {
            Reserva reserva = (from R in _contextLocaliza.Reservas
                               where R.IdReserva == idReserva
                               select R
                              )
                              .FirstOrDefault();

            Validators<Reserva>.Validate(reserva, Activator.CreateInstance<ReservaValidator>());

            reserva.DataDevolucao = dataDevolucao;
            
            _contextLocaliza.Reservas.Update(reserva);
            _contextLocaliza.SaveChanges();
        }

        /// <summary>
        /// Lista placas que que estão com a data de devolução da reserva vencida.
        /// </summary>
        /// <returns></returns>
        public List<string> ListaPlacasVencidas()
        {
            List<string> placas = (from V in _contextLocaliza.Veiculos
                                   from R in _contextLocaliza.Reservas.Where(r => r.IdVeiculo == V.IdVeiculo)
                                   where R.DataPrevistaDevolucao < System.DateTime.Now.Date && R.DataDevolucao == null
                                   select V.Placa
                                  )
                                  .Distinct()
                                  .ToList();

            return placas;
        }
    }
}
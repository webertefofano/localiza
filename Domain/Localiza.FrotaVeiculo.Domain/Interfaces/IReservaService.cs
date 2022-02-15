using FluentValidation;
using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Domain.Interfaces
{
    public interface IReservaService
    {
        /// <summary>
        /// Insere Reserva.
        /// </summary>
        /// <param name="reserva"></param>
        /// <returns>Retorna o Id inserido</returns>
        int AddReserva(Reserva reserva);

        /// <summary>
        /// Listar Reservas de um Cliente.
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        List<Reserva> ListarReservas(int idCliente);

        /// <summary>
        /// Listar reservas que já tiveram os veículos retirados pelos respectivos clientes em um intervalo de datas.
        /// </summary>
        /// <param name="dataInicio"></param>
        /// <param name="dataFim"></param>
        /// <returns></returns>
        List<Reserva> ListarReservasPorDataRetirada(DateTime dataInicio, DateTime dataFim);

        /// <summary>
        /// Atualiza a data de retirada de uma reserva e a data prevista de devolução.
        /// </summary>
        /// <param name="IdReserva"></param>
        /// <param name="DataRetirada"></param>
        /// <param name="DataPrevistaDevolucao"></param>
        void UpdDataRetiradaDataPrevista(int IdReserva, DateTimeOffset DataRetirada, DateTimeOffset? DataPrevistaDevolucao);

        /// <summary>
        /// Atualiza a data de devolução.
        /// </summary>
        /// <param name="IdReserva"></param>        
        /// <param name="DataDevolucao"></param>
        void UpdDataDevolucao(int idReserva, DateTimeOffset? dataDevolucao);

        /// <summary>
        /// Lista placas que que estão com a data de devolução da reserva vencida.
        /// </summary>
        /// <returns></returns>
        List<string> ListaPlacasVencidas();
    }
}
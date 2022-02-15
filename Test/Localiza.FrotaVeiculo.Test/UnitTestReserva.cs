using Localiza.FrotaVeiculo.Application.Controllers;
using Localiza.FrotaVeiculo.Application.Models.Reserva;
using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Localiza.FrotaVeiculo.Domain.Interfaces;
using Localiza.FrotaVeiculo.Infra.Data.Context.Localiza;
using Localiza.FrotaVeiculo.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Localiza.FrotaVeiculo.Test
{
    public class UnitTestReserva
    {
        private ReservaController _reservaController = new ReservaController((IReservaService) new Mock<IReservaService>().Object);

        [Fact]
        public void AddReservaTest()
        {
            //Arrange
            ReservaModel reservaModel = new ReservaModel
            {
                DataPrevistaDevolucao = System.DateTime.Now,
                IdCliente = 0,
                IdVeiculo = 0
            };

            //Act
            var reservaServiceStub = new Mock<IReservaService>();
            reservaServiceStub.Setup(serv => serv.AddReserva(It.IsAny<Reserva>())).Returns(-1);
            var result = _reservaController.AddReserva(reservaModel);

            //Assert
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public void ListarReservasDoClienteTest()
        {
            //Arrange
            int IdCliente = 0;            

            //Act
            var reservaServiceStub = new Mock<IReservaService>();
            reservaServiceStub.Setup(serv => serv.ListarReservas(It.IsAny<int>())).Returns(null as List<Reserva>);
            var result = _reservaController.ListarReservasDoCliente(IdCliente);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void ListarReservasPorDataRetiradaTest()
        {
            //Arrange
            DateTime dataInicio = System.DateTime.Now;
            DateTime dataFim = System.DateTime.Now;

            //Act
            var reservaServiceStub = new Mock<IReservaService>();
            reservaServiceStub.Setup(serv => serv.ListarReservas(It.IsAny<int>())).Returns(null as List<Reserva>);
            var result = _reservaController.ListarReservasPorDataRetirada(dataInicio, dataFim);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdDataRetiradaDataPrevistaTest()
        {
            //Arrange
            UpdDataRetiradaDataDevolucaoModel updDataRetiradaDataDevolucaoModel = new UpdDataRetiradaDataDevolucaoModel
            {
                DataPrevistaDevolucao = System.DateTime.Now,
                DataRetirada = System.DateTime.Now,
                IdReserva = 0
            };

            //Act
            var reservaServiceStub = new Mock<IReservaService>();
            object p = reservaServiceStub.Setup(serv => serv.UpdDataRetiradaDataPrevista(updDataRetiradaDataDevolucaoModel.IdReserva, updDataRetiradaDataDevolucaoModel.DataRetirada, updDataRetiradaDataDevolucaoModel.DataPrevistaDevolucao));

            var result = _reservaController.UpdDataRetiradaDataPrevista(updDataRetiradaDataDevolucaoModel);

            ////Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdDataDevolucaoTest()
        {
            //Arrange
            UpdDataDevolucaoModel updDataDevolucaoModel = new UpdDataDevolucaoModel
            {
                DataDevolucao = null,
                IdReserva = 0
            };

            //Act
            var reservaServiceStub = new Mock<IReservaService>();
            object p = reservaServiceStub.Setup(serv => serv.UpdDataDevolucao(updDataDevolucaoModel.IdReserva, updDataDevolucaoModel.DataDevolucao));

            var result = _reservaController.UpdDataDevolucao(updDataDevolucaoModel);

            ////Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ListaPlacasVencidasTest()
        {
            //Arrange
            
            //Act
            var reservaServiceStub = new Mock<IReservaService>();
            reservaServiceStub.Setup(serv => serv.ListaPlacasVencidas()).Returns(null as List<string>);
            var result = _reservaController.ListaPlacasVencidas();

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
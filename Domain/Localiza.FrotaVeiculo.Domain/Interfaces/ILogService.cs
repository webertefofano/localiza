using FluentValidation;
using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Domain.Interfaces
{
    public interface ILogService
    {
        /// <summary>
        /// Insere Log.
        /// </summary>
        /// <param name="log"></param>        
        void AddLog(Log log);
    }
}

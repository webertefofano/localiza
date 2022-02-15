using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Localiza.FrotaVeiculo.Domain.Interfaces;
using Localiza.FrotaVeiculo.Infra.Data.Context.Localiza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ContextLocaliza _contextLocaliza;

        public BaseRepository(ContextLocaliza contextMax)
        {
            _contextLocaliza = contextMax;
        }

        public void Insert(TEntity obj)
        {
            _contextLocaliza.Set<TEntity>().Add(obj);
            _contextLocaliza.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _contextLocaliza.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contextLocaliza.SaveChanges();
        }

        public void Delete(int id)
        {
            _contextLocaliza.Set<TEntity>().Remove(Select(id));
            _contextLocaliza.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _contextLocaliza.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _contextLocaliza.Set<TEntity>().Find(id);
    }
}
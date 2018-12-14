using Meta.Entities.Contextos;
using Meta.Entities.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Meta.Repository
{
 public   class RepositorioBase<T> where T: class
    {
        protected readonly DbContext Context;
        private DbSet<T> _entities;

        public RepositorioBase(DbContext context)
        {
            this.Context = context;
            this._entities = Context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await this._entities.AddAsync(entity);

            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await this._entities.AddRangeAsync(entities);

            return entities;
        }

        public async Task<IEnumerable<T>> FindAsyc(Expression<Func<T, bool>> predicado)
        {
            return await _entities.Where(predicado).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsyc()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            this._entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            this._entities.RemoveRange(entities);
        }

        public T Update(T entity)
        {
            this._entities.Update(entity);


            return entity;
        }

    }


    public class RepositorioRol : RepositorioBase<Rol>, IRepositorioRol
    {
        public RepositorioRol(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioGrupo : RepositorioBase<Grupo>, IRepositorioGrupo
    {
        public RepositorioGrupo(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }


    public class RepositorioPais : RepositorioBase<Pais>, IRepositorioPais
    {
        public RepositorioPais(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioEntidad : RepositorioBase<Entidad>, IRepositorioEntidad
    {
        public RepositorioEntidad(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioLocalizacion : RepositorioBase<Localizacion>, IRepositorioLocalizacion
    {
        public RepositorioLocalizacion(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioPasarela : RepositorioBase<Pasarela>, IRepositorioPasarela
    {
        public RepositorioPasarela(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioRedPago : RepositorioBase<RedPago>, IRepositorioRedPago
    {
        public RepositorioRedPago(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }


    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioUsuarioEntidad : RepositorioBase<UsuarioEntidad>, IRepositorioUsuarioEntidad
    {
        public RepositorioUsuarioEntidad(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }



    public class RepositorioGrupoPais : RepositorioBase<GrupoPais>, IRepositorioGrupoPais
    {
        public RepositorioGrupoPais(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }

    public class RepositorioTransaccion : RepositorioBase<Transaccion>, IRepositorioTransaccion
    {
        public RepositorioTransaccion(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }


    public class RepositorioEstadoTransaccion : RepositorioBase<TransaccionEstado>, IRepositorioTransaccionEstado
    {
        public RepositorioEstadoTransaccion(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }


    public class RepositorioRegla : RepositorioBase<Regla>, IRepositorioRegla
    {
        public RepositorioRegla(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }

        public async Task<IEnumerable<Regla>> GetReglasAllInclude(int ide)
        {
            return await appDbContext.Reglas
                 .Include(e => e.Entidad)
                 .Include(g => g.Grupo)
                 .Include(p => p.Pais)
                 .Include(r => r.RedPago)
                 .Include(p => p.Pasarela)
                 .Include(u => u.Usuario)
                 .Where(x => x.EntidadId == ide)
                 .ToListAsync();
        }
    }

    public class RepositorioAfiliacion : RepositorioBase<Afiliacion>, IRepositorioAfiliacion
    {
        public RepositorioAfiliacion(AppDbContext contexto) : base(contexto)
        {
        }

        public AppDbContext appDbContext
        {
            get { return Context as AppDbContext; }
        }
    }


}

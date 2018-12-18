using Meta.Entities.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Meta.Repository
{
  public interface IRepositorioBase<T> where T:class
    {

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsyc();

        Task<IEnumerable<T>> FindAsyc(Expression<Func<T, bool>> predicado);

        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        T Update(T entity);

    }

    public interface IRepositorioRol : IRepositorioBase<Rol>
    {
    }
    public interface IRepositorioGrupo : IRepositorioBase<Grupo>
    {
      
    }
    public interface IRepositorioPais : IRepositorioBase<Pais>
    {
    }
    public interface IRepositorioEntidad : IRepositorioBase<Entidad>
    {
    }
    public interface IRepositorioLocalizacion : IRepositorioBase<Localizacion>
    {
    }
    public interface IRepositorioPasarela : IRepositorioBase<Pasarela>
    {
    }
    public interface IRepositorioRedPago : IRepositorioBase<RedPago>
    {
    }
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
    }
    public interface IRepositorioUsuarioEntidad : IRepositorioBase<UsuarioEntidad>
    {
    }
    public interface IRepositorioGrupoPais : IRepositorioBase<GrupoPais>
    {
        Task<IEnumerable<GrupoPais>> GetGrupoConPais(int idg);
    }


    public interface IRepositorioTransaccion : IRepositorioBase<Transaccion>
    {
    }

    public interface IRepositorioTransaccionEstado : IRepositorioBase<TransaccionEstado>
    {
    }


    public interface IRepositorioRegla : IRepositorioBase<Regla>
    {
        Task<IEnumerable<Regla>> GetReglasAllInclude(int ide);
    }

    public interface IRepositorioAfiliacion : IRepositorioBase<Afiliacion>
    {
    }

    public interface IRepositorioDivisa : IRepositorioBase<Divisa>
    {
    }
}

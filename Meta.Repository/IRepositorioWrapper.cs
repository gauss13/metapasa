using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meta.Repository
{
    public interface IRepositorioWrapper : IDisposable
    {

        IRepositorioRol Roles { get; }
        IRepositorioGrupo Grupos { get; }
        
        IRepositorioPais Paises { get; }
        IRepositorioEntidad Entidades { get; }
        IRepositorioLocalizacion Localizaciones { get; }
        IRepositorioPasarela Pasarelas { get; }
        IRepositorioRedPago RedPagos { get; }
        IRepositorioUsuario Usuarios { get; }
        IRepositorioUsuarioEntidad UsuarioEntidades { get; }
        IRepositorioGrupoPais GrupoPaises { get; }
        IRepositorioTransaccion Transacciones { get; }
        IRepositorioTransaccionEstado TransaccionEstados { get; }
        IRepositorioRegla Reglas { get; }
        Task<int> CompleteAsync();

    }
}

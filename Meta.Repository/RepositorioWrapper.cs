using Meta.Entities.Contextos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meta.Repository
{
    public class RepositorioWrapper : IRepositorioWrapper
    {
        AppDbContext _Context { get; }
        public RepositorioWrapper(AppDbContext context)
        {
            _Context = context;

            Roles = new RepositorioRol(_Context);
            Grupos = new RepositorioGrupo(_Context);
            Paises = new RepositorioPais(_Context);
            Entidades = new RepositorioEntidad(_Context);
            Localizaciones = new RepositorioLocalizacion(_Context);
            Pasarelas = new RepositorioPasarela(_Context);
            RedPagos = new RepositorioRedPago(_Context);
            Usuarios = new RepositorioUsuario(_Context);
            UsuarioEntidades = new RepositorioUsuarioEntidad(_Context);
            GrupoPaises = new RepositorioGrupoPais(_Context);
            Transacciones = new RepositorioTransaccion(_Context);
            TransaccionEstados = new RepositorioEstadoTransaccion(_Context);
            Reglas = new RepositorioRegla(_Context);
            Afiliaciones = new RepositorioAfiliacion(_Context);
            Divisas = new RepositorioDivisa(_Context);

        }


        public IRepositorioRol Roles { get; private set; }
        public IRepositorioGrupo Grupos { get; private set; }
        public IRepositorioPais Paises { get; private set; }
        public IRepositorioEntidad Entidades { get; private set; }
        public IRepositorioLocalizacion Localizaciones { get; private set; }
        public IRepositorioPasarela Pasarelas { get; private set; }
        public IRepositorioRedPago RedPagos { get; private set; }
        public IRepositorioUsuario Usuarios { get; private set; }
        public IRepositorioUsuarioEntidad UsuarioEntidades { get; private set; }
        public IRepositorioGrupoPais GrupoPaises { get; private set; }
        public IRepositorioTransaccion Transacciones { get; private set; }
        public IRepositorioTransaccionEstado TransaccionEstados { get; private set; }
        public IRepositorioRegla Reglas { get; private set; }
        public IRepositorioAfiliacion Afiliaciones { get; private set; }

        public IRepositorioDivisa Divisas { get; private set; }


        public async Task<int> CompleteAsync()
        {
            return await this._Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            // liberar los recuros de memoria
            this._Context.Dispose();
        }

        
    }
}

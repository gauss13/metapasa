using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.Entities.Modelos
{
   public class Regla
    {


        //- La regla es por entidad, cada entidad tendrá su propia regla de, entidad, grupo y de pais

        //- Regla 1: Default entidad, si grupo es null y pais es null. 

        //- Regla 2: Por Grupo en la entidad, si pais es null. 

        //- Regla 3: Por Pais, cuando el Grupo es null. 

        //En caso de exister las tres reglas, la prioridad de las reglas es:  3,2,1

        //(si un pais no tiene regla de pais, ni esta en un grupo, se tomará la regla 1)
        //(si un pais no tiene regla de pais, pero esta en un grupo, se tomará la regla 2)
        //(si el pais tiene su propia regla, siempre se tomará la regla 3 con mayor prioridad a las demas reglas)



        public int Id { get; set; }
        public int EntidadId { get; set; }
        public int? GrupoId { get; set; }
        public int? PaisId { get; set; }
        public int PasarelaId { get; set; }
        public int? RedPagoId { get; set; }
        public bool DefaultEntidad { get; set; }// identificador adicional para la entidades
        public int UsuarioId { get; set; }
        public DateTime FechaReg { get; set; }
        //nav
        public Entidad Entidad{ get; set; }
        public Grupo Grupo { get; set; }
        public Pais Pais { get; set; }
        public RedPago RedPago { get; set; }
        public Pasarela Pasarela { get; set; }
        public Usuario Usuario { get; set; }
    }
}

using AutoMapper;
using Datos.EF.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Profiles
{
    public class CatalogoProfile : Profile
    {
        public CatalogoProfile()
        {
            #region "estados"
            //de EF -> Entidad
            CreateMap<Estado, Entidades.Catalogos.Estado>();

            //de Entidad -> EF
            CreateMap<Entidades.Catalogos.Estado, Estado>();
            #endregion


            #region "paises y ciudades"
            //de EF -> Entidad
            CreateMap<Pais, Entidades.Catalogos.Pais>();
            //de Entidad -> EF
            CreateMap<Entidades.Catalogos.Pais, Pais>();


            //de EF -> Entidad
            CreateMap<Ciudad, Entidades.Catalogos.Ciudad>();
            //de Entidad -> EF
            CreateMap<Entidades.Catalogos.Ciudad, Ciudad>();
            #endregion


            #region "moneda"

            //de EF -> Entidad
            CreateMap<Moneda, Entidades.Catalogos.Moneda>();
            //de Entidad -> EF
            CreateMap<Entidades.Catalogos.Moneda, Moneda>();

            //de EF -> Entidad
            CreateMap<MonedaDenominacion, Entidades.Catalogos.MonedaDenominacion> ();
            //de Entidad -> EF
            CreateMap<Entidades.Catalogos.MonedaDenominacion, MonedaDenominacion>();

            //de EF -> Entidad
            CreateMap<TasaCambio, Entidades.Catalogos.TasaCambio>();
            //de Entidad -> EF
            CreateMap<Entidades.Catalogos.TasaCambio, TasaCambio>();

            //de EF -> Entidad
            CreateMap<Impuestos, Entidades.Catalogos.Impuesto>();
            //de Entidad -> EF
            CreateMap<Entidades.Catalogos.Impuesto, Impuestos>();

            #endregion


            #region "Concepto y Tipo"

            CreateMap<Concepto, Entidades.Catalogos.Concepto>();
            //de Entidad -> EF
            CreateMap<Entidades.Catalogos.Concepto, Concepto>();


            CreateMap<ConceptoTipo, Entidades.Catalogos.ConceptoTipo>();
            //de Entidad -> EF
            CreateMap<Entidades.Catalogos.ConceptoTipo, ConceptoTipo>();

            #endregion


            #region "Documento"
            //de EF -> Entidad
            CreateMap<DocumentoMadre, Entidades.Catalogos.DocumentoMadre>();
            //de Entidad -> EF
            CreateMap<Entidades.Catalogos.DocumentoMadre, DocumentoMadre>();


            #endregion


        }
    }
}

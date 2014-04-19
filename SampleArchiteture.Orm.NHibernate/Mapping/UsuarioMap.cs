using FluentNHibernate.Mapping;
using SampleArchiteture.Dominio.Entities;

namespace SampleArchiteture.Orm.NHibernate.Mapping
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(e => e.Id);

            Not.LazyLoad();
        }
    }
}

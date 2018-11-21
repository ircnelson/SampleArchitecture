namespace SampleArchitecture.Core.Entities
{
    public class Cidade
    {
        public int Id { get; set; }

        public int UfId { get; set; }
        public Uf Uf { get; set; }
    }
}
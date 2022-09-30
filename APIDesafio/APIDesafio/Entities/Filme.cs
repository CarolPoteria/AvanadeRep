namespace APIDesafio.Entities
{
    public class Filme
    {
        public int ID { get; set; }
        public string Nome { get; set; }         
        public DateTime DataLancamento { get; set; }
        public string Diretor { get; set; }
        public int IDGenero { get; set; }
    }
}

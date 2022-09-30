namespace APIDesafio.Entities
{
    public class Aluguel
    {
        public int ID { get; set; }
        public int IDCliente { get; set; }
        public int IDFilme { get; set; }
        public DateTime DataLocacao { get; set; }
    }
}

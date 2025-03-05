namespace UsuarioApp.Domain.Entities
{
    public class HistoricoAtividade
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }


        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }


    }
}
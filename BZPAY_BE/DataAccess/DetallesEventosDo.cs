namespace BZPAY_BE.DataAccess
{
    public class DetalleEventoDo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string TipoEvento { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoEscenario { get; set; }
        public string Escenario { get; set; }
        public string Localizacion { get; set; }

    }
}

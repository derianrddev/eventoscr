namespace BZPAY_BE.DataAccess
{
    public class DetalleAsientoDo
    {
        public int Id { get; set; }

        public int IdEvento { get; set; }

        public string TipoAsiento { get; set; } = null!;

        public int Cantidad { get; set; }

    }
}

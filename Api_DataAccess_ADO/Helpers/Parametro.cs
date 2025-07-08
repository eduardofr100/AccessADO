namespace Api_DataAccess_ADO.Helpers
{
    public class Parametro
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }

        public Parametro(string nombre, string valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
}

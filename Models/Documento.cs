using Microsoft.AspNetCore.Http;

namespace ExemploCrudMySql.Models
{
    public class Documento
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Processo { get; set; }
        public string Categoria { get; set; }
        public string Arquivo { get; set; }
        public IFormFile file { get; set; }
    }
}

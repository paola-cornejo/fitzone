using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Login.Oauth.Areas.Socio.Data
{
    public class Socio
    {

        [Key]        
        public int idSocio { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string mail { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string idDomicilio  { get; set; }

    }
}

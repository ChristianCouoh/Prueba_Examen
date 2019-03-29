using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gestion_Asistencias.Models
{

    public class Profesores
    {
        /// <summary>
        /// Creo el modelo, utilizo DataAnnotations para definir cual es la llave del modelo, y para definir que quiero
        /// que muestre en las etiquetass que genere la vista así como los mensajes que ha de mostrar en caso que sea un campo requerido 
        /// y el usaurio no capture nada.
        /// </summary>
        [Key]
        [Display(Name = "ID PROFESOR")]
        [Required(ErrorMessage = "DEBE CAPTURAR EL {0}")]
        public int id { get; set; }
        [Display(Name = "NOMBRE PROFESOR")]
        [Required(ErrorMessage = "DEBE CAPTURAR EL {0}")]
        public string Nombre { get; set; }
        [Display(Name = "DIRECCION PROFESOR")]
        [Required(ErrorMessage = "DEBE CAPTURAR LA {0}")]
        public string Direccion { get; set; }
        [Required]
        [Display(Name = "TELEFONO PROFESOR")]
        public string Telefono { get; set; }

    }
}
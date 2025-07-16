using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALQANCHA.Models
{
    public class Cancha
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "La cantidad de jugadores es obligatoria")]
        [Range(5, 8, ErrorMessage = "La cantidad de jugadores debe ser 5, 6 u 8")]
        [Display(Name = "Cantidad de Jugadores")]
        public int CantJugadores { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(250, MinimumLength = 20, ErrorMessage = "La descripción debe tener entre 20 y 250 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "El teléfono debe tener entre 5 y 30 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El precio por hora es obligatorio")]
        [Display(Name = "Precio por Hora")]
        public int PrecioXHora { get; set; }

        [Required]
        public bool Reservada { get; set; }

        [Required]
        public bool Confirmada { get; set; }
    }
}

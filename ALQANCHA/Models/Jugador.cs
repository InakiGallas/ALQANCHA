
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALQANCHA.Models
{
    public class Jugador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [StringLength(10, MinimumLength = 7, ErrorMessage = "El DNI debe tener entre 7 y 10 caracteres")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "El nombre debe tener entre 5 y 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "El apellido debe tener entre 5 y 30 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "El teléfono debe tener entre 5 y 15 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
        public string Email { get; set; }

        [Display(Name = "¿Es arquero?")]
        public bool EsArquero { get; set; }

        [Display(Name = "¿Es jugador?")]
        public bool EsJugador { get; set; }

        [Display(Name = "Fecha Disponible")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaDisponible { get; set; }

        [Display(Name = "Hora de Inicio")]
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan HoraInicio { get; set; }

        [Display(Name = "¿Está sancionado?")]
        public bool EstaSancionado { get; set; }


        public virtual ICollection<ReservaJugador> ReservaJugadores { get; set; } = new List<ReservaJugador>();
    }
}
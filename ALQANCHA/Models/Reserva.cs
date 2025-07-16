using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALQANCHA.Models
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int? AdministradorId { get; set; }

        [ForeignKey(nameof(AdministradorId))]
        public virtual Administrador? Administrador { get; set; }

        [Required]
        public int? CanchaId { get; set; }

        [ForeignKey(nameof(CanchaId))]
        public virtual Cancha? Cancha { get; set; }

        [Display(Name = "Fecha de Reserva")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaReserva { get; set; }

        [Display(Name = "Hora de Inicio")]
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan HoraInicio { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "El nombre debe tener entre 5 y 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "El apellido debe tener entre 5 y 30 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La cantidad de jugadores es obligatoria")]
        public int CantJugadores { get; set; }

        public bool RequiereJugador { get; set; }
        public bool RequiereArquero { get; set; }
        public bool EsStream { get; set; }

        [EnumDataType(typeof(TipoReserva))]
        [Required(ErrorMessage = "El tipo de reserva es obligatorio")]
        public TipoReserva TipoReserva { get; set; }
        public bool Confirmada { get; set; }
        public int PrecioFinal { get; set; }


        public virtual ICollection<ReservaJugador> ReservaJugadores { get; set; } = new List<ReservaJugador>();
    }

    public enum TipoReserva
    {
        [Display(Name = "50% Mitad del Pago")]
        MitadPago = 50,

        [Display(Name = "100% Pago Completo")]
        PagoCompleto = 100
    }
}

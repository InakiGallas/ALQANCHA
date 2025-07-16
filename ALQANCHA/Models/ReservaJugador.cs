using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALQANCHA.Models
{
    public class ReservaJugador
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Reserva")]
        public int ReservaId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Jugador")]
        public int JugadorId { get; set; }

        public virtual Reserva Reserva { get; set; }
        public virtual Jugador Jugador { get; set; }
    }
}

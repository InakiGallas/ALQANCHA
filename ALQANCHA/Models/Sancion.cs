using ALQANCHA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ALQANCHA.Models
{
    public class Sancion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Jugador")]
        public int JugadorId { get; set; }

        [Required(ErrorMessage = "Debe describir el motivo de la sanción")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "El motivo de la sanción debe tener entre 5 y 250 caracteres")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Fecha de Imposición")]
        public DateTime FechaImposicion { get; set; }

      
        public virtual Jugador Jugador { get; set; }
    }
}
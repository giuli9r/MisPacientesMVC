using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MisPacientes_04.Models
{
    public class ObraSocial
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Plan { get; set; }

        [NotMapped]
        public string ObraSocialNombre
        {
            get
            {
                return string.Format("{0} - {1}", Nombre, Plan);
            }
        }

        [Display(Name = "Descripción")]
        [StringLength(120)]
        public string? Descripcion { get; set; }

        [Display(Name = "Fecha Registro")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? FechaRegistro { get; set; }


        // RELACION 1:1 con Paciente
        public Paciente? Paciente { get; set; }
    }
}

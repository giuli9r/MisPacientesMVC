using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MisPacientes_04.Models
{
    public class Paciente
    {

        /*Datos Personales*/
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Por favor, ingrese el Nombre de la persona.")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Por favor, ingrese el Apellido de la persona.")]
        public string Apellido { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Por favor, ingrese el Documento de la persona.")]
        public string DNI { get; set; }
        
        [NotMapped]
        public string PacienteNombre
        {
            get
            {
                return string.Format("{0} {1} - {2}", Nombre, Apellido, DNI);
            }
        }

        public string? Sexo { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? MedicoReferido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? NumeroAfiliado { get; set; }
        public DateTime? FechaAlta { get; set; }


        /*Datos Clinicos*/
        // ANAMNESIS - Relacion 1:1 => 1 Paciente tiene 1 Anamnesis
        public Anamnesis? Anamnesis { get; set; }

        // OBRA SOCIAL - Relacion 1:1 => 1 Paciente tiene 1 Obra Social
        [Display(Name = "Obra Social")]
        public int? ObraSocialRefId { get; set; }
        [ForeignKey("ObraSocialRefId")]
        public virtual ObraSocial? ObraSocial { get; set; }
    }
}

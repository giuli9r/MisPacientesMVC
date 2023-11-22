using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MisPacientes_04.Models
{
    public class Anamnesis
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Motivo Consulta")]
        [StringLength(600)]
        [Required(ErrorMessage = "Por favor, ingrese el motivo de la consulta.")]
        public string MotivoConsulta { get; set; }

        [Display(Name = "Enfermedad Actual")]
        [StringLength(200)]
        public string? EnfermedadActual { get; set; }

        [Display(Name = "Fecha Registro")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? FechaRegistro { get; set; }

        [NotMapped]
        public string PacienteNombreAnamnesis
        {
            get
            {
                return string.Format("{0} - {1}", MotivoConsulta, Paciente?.PacienteNombre);
            }
        }


        // RELACION 1:1 con Paciente. 1 Anamnesis corresponde a 1 Paciente
        [Display(Name = "Paciente")]
        public int? PacienteRefId { get; set; }
        [ForeignKey("PacienteRefId")]
        public virtual Paciente? Paciente { get; set; } = null;


        // RELACION 1:1 con Antecedente Familiar - 1 Anamnesis contiene 1 A.F
        public virtual AntecedenteFamiliar? AntecedenteFamiliar { get; set; }


        // RELACION 1:N con Examen Fisico - 1 Anamnesis contiene muchos examenes fisicos
        public ICollection<ExamenFisico>? ExamenFisico { get; set; }


        /* Foreing Keys */

        //[Display(Name = "Examen Fisico")]
        //public int? ExamenFisicoRefId { get; set; }
        //[ForeignKey("ExamenFisicoRefId")]
        //public virtual ExamenFisico? ExamenFisico { get; set; }

        //[Display(Name = "Estudio Complementario")]
        //public int? EstudioComplementarioRefId { get; set; }
        //public virtual EstudioComplementario? EstudioComplementario { get; set; }

        //[Display(Name = "Antecedentes Personales")]
        //public int? AntecedentesPersonalesRefId { get; set; }
        //public virtual AntecedentesPersonales? AntecedentesPersonales { get; set; }

        //[Display(Name = "Antecedentes Familiares")]
        //public int? AntecedentesFamiliaresRefId { get; set; }

        //public virtual AntecedentesFamiliares? AntecedentesFamiliares { get; set; }



    }
}

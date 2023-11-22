using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MisPacientes_04.Models
{
    public class AntecedenteFamiliar
    {

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Enfermedades Cardiovasculares")]
        [StringLength(600)]
        public string? E_Cardios { get; set; }

        [Display(Name = "Enfermedades Respiratorias")]
        [StringLength(600)]
        public string? E_Respiratorias { get; set; }

        [Display(Name = "Descripcion antecedentes")]
        [StringLength(600)]
        public string? DescripcionAntecedentes { get; set; }

        // RELACION 1:1 con Anamnesis
        // 1 Antecedente corresponde a 1 Anamnesis

        [Display(Name = "Anamnesis")]
        public int? AnamnesisRefId { get; set; }
        [ForeignKey("AnamnesisRefId")]
        public virtual Anamnesis? Anamnesis { get; set; }

    }
}

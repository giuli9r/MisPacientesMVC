﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MisPacientes_04.Models
{
    public class ExamenFisico
    {

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(200)]
        public string? Descripcion { get; set; }

        [Display(Name = "Imagen")]
        public string? ImagenExamenFisico { get; set; }

        [Display(Name = "Fecha Registro")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? FechaRegistro { get; set; }


        // RELACION 1:N con Anamnesis - 1 Anamnesis contiene muchos examenes fisicos
        [ForeignKey("Anamnesis")]
        public int? AnamnesisId { get; set; }
        public Anamnesis? Anamnesis { get; set; }

    }
}

namespace JAATfncConsumidor.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    class ModelParcial
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Estudiante { get; set; }
        [Required]
        public double Temperatura { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Fecha { get; set; }
        [DataType(DataType.Time)]
        [Required]
        public DateTime Hora { get; set; }
    }
}

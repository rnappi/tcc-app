using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppQuestionario.Models
{
    [Table("Questionario")]
    public class Questionario
    {
        public int id_Questionario { get; set; }
        public int id_Pergunta { get; set; }
        public int id_Alternativa { get; set; }
        public string Alternativa_Correta { get; set; }

        [MaxLength(100)]
        public string NomeQuestionario { get; set; }

        [MaxLength(500)]
        public string Pergunta { get; set; }

        [MaxLength(200)]
        public string DescricaoAlternativa { get; set; }
    }
}
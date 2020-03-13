using System;
using System.Collections.Generic;
using System.Text;

namespace AppQuestionario.Models
{
    public class Questionario
    {
        public int id_Questionario { get; set; }
        public int id_Pergunta { get; set; }
        public int id_Alternativa { get; set; }
        public string NomeQuestionario { get; set; }
        public string Pergunta { get; set; }
        public string DescricaoAlternativa { get; set; }
        public string Alternativa_Correta { get; set; }
    }
}
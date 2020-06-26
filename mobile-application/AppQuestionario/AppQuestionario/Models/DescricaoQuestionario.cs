using System;
using System.Collections.Generic;
using System.Text;

namespace AppQuestionario.Models
{
    public class DescricaoQuestionario
    {
        public bool AlternativaCorreta { get; set; }
        public string DescricaoAlternativa { get; set; }
        public int IdAlternativa { get; set; }
        public int IdPergunta { get; set; }
        public int IdQuestionario { get; set; }
        public string NomeQuestionario { get; set; }
        public string Pergunta { get; set; }
        public int QtdAlternativas { get; set; }
        public int QtdPerguntas { get; set; }
        public int Tentativa { get; set; }
        public int QtdAcertos { get; set; }
    }
}

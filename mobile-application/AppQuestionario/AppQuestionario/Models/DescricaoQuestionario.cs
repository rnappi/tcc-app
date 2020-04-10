using System;
using System.Collections.Generic;
using System.Text;

namespace AppQuestionario.Models
{
    public class DescricaoQuestionario
    {
        public string NomeQuestionario { get; set; }
        public int id_Questionario { get; set; }
        public int qtdAlternativas { get; set; }
        public int qtdPerguntas { get; set; }
    }
}

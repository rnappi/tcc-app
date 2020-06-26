using System;
using System.Collections.Generic;
using System.Text;

namespace AppQuestionario.Models
{
    public class RespostaAPI
    {
        public bool Status { get; set; }
        public string Msg { get; set; }
        public int IdTentativa { get; set; }
        public int QtdAcertos { get; set; }
    }
}

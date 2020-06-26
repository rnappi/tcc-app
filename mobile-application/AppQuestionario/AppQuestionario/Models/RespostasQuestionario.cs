using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppQuestionario.Models
{
    public class RespostasQuestionario
    {
        [JsonProperty("id_Aluno")]
        public int IdAluno { get; set; }

        [JsonProperty("id_Questionario")]
        public int IdQuestionario { get; set; }

        [JsonProperty("respostas")]
        public List<int> Respostas { get; set; }
    }
}

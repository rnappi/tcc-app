using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppQuestionario.Models
{
    public enum TipoLog
    {
        Login = 1,
        Logout = 2
    }

    public class LogSistema
    {
        [JsonProperty("id_Aluno")]
        public int Id_Aluno { get; set; }

        [JsonProperty("id_TipoLogSistema")]
        public TipoLog Id_TipoLogSistema { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("localizacao")]
        public string Localizacao { get; set; }
    }
}

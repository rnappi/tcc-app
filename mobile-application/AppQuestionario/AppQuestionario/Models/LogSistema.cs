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
        public int Id_Aluno { get; set; }
        public TipoLog Id_TipoLogSistema { get; set; }
        public string Descricao { get; set; }
    }
}

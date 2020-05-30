using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppQuestionario.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int ID_Aluno { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(100), Unique]
        public string Email { get; set; }

        [MaxLength(50), Unique]
        public string Usuario { get; set; }

        [MaxLength(50)]
        public string Senha { get; set; }

        public string AccessToken { get; set; }
    }
}

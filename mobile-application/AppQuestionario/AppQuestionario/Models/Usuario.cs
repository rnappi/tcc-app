using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppQuestionario.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(100), Unique]
        public string Email { get; set; }

        [MaxLength(50), Unique]
        public string Login { get; set; }

        [MaxLength(50)]
        public string Senha { get; set; }
    }
}

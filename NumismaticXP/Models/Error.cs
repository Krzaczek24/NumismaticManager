using System;
using System.ComponentModel;

namespace NumismaticXP.Models
{
    class Error
    {
        [DisplayName("Id użytkownika")]
        public uint UserId { set; get; }

        [DisplayName("Data")]
        public DateTime Date { set; get; }

        [DisplayName("Klasa")]
        public string ClassName { set; get; }

        [DisplayName("Funkcja")]
        public string FunctionName { set; get; }

        [DisplayName("Treść")]
        public string Message { set; get; }

        [DisplayName("Komentarz")]
        public string Comment { set; get; }
    }
}

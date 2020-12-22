using System;
using System.Collections.Generic;
using System.Text;

namespace IFMGBot.EF.Models
{
    public class ContactInfo
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiEletronica.Models
{
    public class MensagemRelacoes
    {
        public int idMensagem { get; set; }
        public string numeroCi { get; set; }
        public string titulo { get; set; }
        public string corpoCi { get; set; }
        public DateTime dataCadastro { get; set; }
        public string nomeUsuarioRemetente { get; set; }
        public string setorSiglaRemetente { get; set; }
        public List<string> NomesUsuariosDestinatario { get; set; }
        public int qtdAnexos { get; set; }
        public List<max_mensagem_anexo> Anexos { get; set; }
    }
}
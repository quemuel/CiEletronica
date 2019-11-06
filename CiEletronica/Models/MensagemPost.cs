using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiEletronica.Models
{
    public class MensagemPost
    {
        [Display(Name = "Assunto")]
        public string titulo_mensagem { get; set; }
        [Display(Name = "Mensagem")]
        [AllowHtml]
        public string descricao_mensagem { get; set; }
        public int id_tipo_mensagem { get; set; }
        [Display(Name = "Destinatarios")]
        public int[] ids_Destinatarios { get; set; }
        [Display(Name = "Anexo")]
        public HttpPostedFileBase[] binario_anexo { get; set; }
        //public HttpPostedFileBase binario_anexo { get; set; }
    }
}
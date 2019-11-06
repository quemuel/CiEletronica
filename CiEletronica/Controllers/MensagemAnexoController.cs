using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CiEletronica.Models;

namespace CiEletronica.Controllers
{
    public class MensagemAnexoController : Controller
    {
        private DbContextCiEletronica _dbContextCiEletronica = new DbContextCiEletronica();
        private DbContextAdUsuarios _dbContextAdUsuarios = new DbContextAdUsuarios();
        
        [HttpGet]
        public void VisualizarAnexo(int id)
        {
            max_mensagem_anexo anexo = _dbContextCiEletronica.max_mensagem_anexo.FirstOrDefault(max => max.max_id_max == id);

            Byte[] bytes = (Byte[])anexo.max_bin_arquivo;
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = anexo.max_nom_tipo;
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
        [HttpGet]
        public FileResult BaixarAnexo(int id)
        {
            max_mensagem_anexo anexo = _dbContextCiEletronica.max_mensagem_anexo.FirstOrDefault(max => max.max_id_max == id);

            Byte[] bytes = (Byte[])anexo.max_bin_arquivo;

            return File(bytes, anexo.max_nom_tipo, anexo.max_nom_arquivo);
        }
        //public FileResult Download(string id)
        //{
        //    int _arquivoId = Convert.ToInt32(id);
        //    var arquivos = oModelArquivos.ListaArquivos();

        //    string nomeArquivo = (from arquivo in arquivos
        //                          where arquivo.IDArquivo == _arquivoId
        //                          select arquivo.Caminho).First();

        //    string contentType = "application/pdf";
        //    return File(nomeArquivo, contentType, "Report.pdf");
        //}
    }
}
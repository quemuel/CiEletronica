using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiEletronica.Models;

namespace CiEletronica.Controllers
{
    public class MensagemController : Controller
    {
        public DbContextCiEletronica _dbContextCiEletronica = new DbContextCiEletronica();
        
        public ActionResult CaixaEntrada()
        {
            //ViewData["nomeMenu"] = men_mensagem.CAIXA_ENTRADA;
            return View(_dbContextCiEletronica.Set<men_mensagem>());
        }
    }
}
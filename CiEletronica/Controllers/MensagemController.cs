using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CiEletronica.Models;

namespace CiEletronica.Controllers
{
    public class MensagemController : Controller
    {
        private DbContextCiEletronica _dbContextCiEletronica = new DbContextCiEletronica();
        private DbContextAdUsuarios _dbContextAdUsuarios = new DbContextAdUsuarios();
        
        [HttpGet]
        public ActionResult CaixaEntrada()
        {
            //            INNER JOIN CI_ELETRONICA.dbo.rem_remetente rem ON rem.rem_id_men = men.men_id_men
            //INNER JOIN AD_USUARIOS.dbo.use_usuario_setor usr ON rem.rem_id_use = usr.use_id_use
            //INNER JOIN AD_USUARIOS.dbo.usu_usuario usur ON usur.usu_id_usu = usr.use_id_usu

            var mensagemRelacoes = from men in _dbContextCiEletronica.men_mensagem.AsEnumerable()
                                   join cnu in _dbContextCiEletronica.cnu_controle_numeros.AsEnumerable() on men.men_id_men equals cnu.cnu_id_men
                                   join rem in _dbContextCiEletronica.rem_remetente.AsEnumerable() on men.men_id_men equals rem.rem_id_men
                                   join user in _dbContextAdUsuarios.use_usuario_setor.AsEnumerable() on rem.rem_id_use equals user.use_id_use
                                   join usur in _dbContextAdUsuarios.usu_usuario.AsEnumerable() on user.use_id_usu equals usur.usu_id_usu
                                   join setr in _dbContextAdUsuarios.set_setor.AsEnumerable() on user.use_id_set equals setr.set_id_set
                                   join dme in _dbContextCiEletronica.dme_destinatario_mensagem.AsEnumerable() on men.men_id_men equals dme.dme_id_men
                                   join used in _dbContextAdUsuarios.use_usuario_setor.AsEnumerable() on dme.dme_id_use equals used.use_id_use
                                   join usud in _dbContextAdUsuarios.usu_usuario.AsEnumerable() on used.use_id_usu equals usud.usu_id_usu
                                   join setd in _dbContextAdUsuarios.set_setor.AsEnumerable() on used.use_id_set equals setd.set_id_set
                                   where (men.men_id_men == men.men_id_men_pai) && (cnu.cnu_id_tnu == 1) && (usud.usu_id_usu == 584)
                                   orderby men.men_dat_cadastro descending
                                   group new { men, cnu, setr, usur } by new { men.men_id_men_pai, cnu.cnu_num_controle, men.men_nom_titulo, men.men_dat_cadastro, setr.set_nom_sigla, usur.usu_nom_usuario } into tabelaResultado
                                   let mensagemRelacoesResult = tabelaResultado.FirstOrDefault()
                                   select new MensagemRelacoes
                                   {
                                       idMensagem = (int)mensagemRelacoesResult.men.men_id_men_pai,
                                       numeroCi = mensagemRelacoesResult.cnu.cnu_num_controle,
                                       titulo = mensagemRelacoesResult.men.men_nom_titulo,
                                       corpoCi = mensagemRelacoesResult.men.men_des_mensagem,
                                       dataCadastro = mensagemRelacoesResult.men.men_dat_cadastro,
                                       setorSiglaRemetente = mensagemRelacoesResult.setr.set_nom_sigla,
                                       nomeUsuarioRemetente = mensagemRelacoesResult.usur.usu_nom_usuario,
                                       qtdAnexos = _dbContextCiEletronica.max_mensagem_anexo.Where(max => max.max_id_men == mensagemRelacoesResult.men.men_id_men).Count()
                                   };


            //var mensagemRelacoesList = mensagemRelacoes;

            ViewData["nomeMenu"] = men_mensagem.CAIXA_ENTRADA;
            return View(mensagemRelacoes);
        }

        [HttpGet]
        public ActionResult VisualizarMensagem(int? id)
        {
            if(id != null)
            {
                var mensagemRelacoes = from men in _dbContextCiEletronica.men_mensagem.AsEnumerable()
                join rem in _dbContextCiEletronica.rem_remetente.AsEnumerable() on men.men_id_men equals rem.rem_id_men
                join user in _dbContextAdUsuarios.use_usuario_setor.AsEnumerable() on rem.rem_id_use equals user.use_id_use
                join usur in _dbContextAdUsuarios.usu_usuario.AsEnumerable() on user.use_id_usu equals usur.usu_id_usu
                join setr in _dbContextAdUsuarios.set_setor.AsEnumerable() on user.use_id_set equals setr.set_id_set
                join cnu in _dbContextCiEletronica.cnu_controle_numeros.AsEnumerable() on men.men_id_men equals cnu.cnu_id_men
                into ps from cnu in ps.DefaultIfEmpty()
                where (men.men_id_men_pai == id)
                orderby men.men_dat_cadastro descending
                group new { men, cnu, setr, usur } by new { men.men_id_men_pai, cnu_num_controle = cnu?.cnu_num_controle ?? String.Empty, men.men_nom_titulo, men.men_dat_cadastro, setr.set_nom_sigla, usur.usu_nom_usuario } into tabelaResultado
                let mensagemRelacoesResult = tabelaResultado.FirstOrDefault()
                select new MensagemRelacoes
                {
                    idMensagem = (int)mensagemRelacoesResult.men.men_id_men,
                    numeroCi = mensagemRelacoesResult.cnu?.cnu_num_controle ?? String.Empty,
                    titulo = mensagemRelacoesResult.men.men_nom_titulo,
                    corpoCi = mensagemRelacoesResult.men.men_des_mensagem,
                    dataCadastro = mensagemRelacoesResult.men.men_dat_cadastro,
                    setorSiglaRemetente = mensagemRelacoesResult.setr.set_nom_sigla,
                    nomeUsuarioRemetente = mensagemRelacoesResult.usur.usu_nom_usuario,
                    NomesUsuariosDestinatario = (
                        from dme in _dbContextCiEletronica.dme_destinatario_mensagem.AsEnumerable()
                        join used in _dbContextAdUsuarios.use_usuario_setor.AsEnumerable() on dme.dme_id_use equals used.use_id_use
                        join usud in _dbContextAdUsuarios.usu_usuario.AsEnumerable() on used.use_id_usu equals usud.usu_id_usu
                        join setd in _dbContextAdUsuarios.set_setor.AsEnumerable() on used.use_id_set equals setd.set_id_set
                        where dme.dme_id_men == mensagemRelacoesResult.men.men_id_men
                        select usud.usu_nom_usuario
                    ).ToList(),
                    Anexos = _dbContextCiEletronica.max_mensagem_anexo.Where(max => max.max_id_men == mensagemRelacoesResult.men.men_id_men).ToList()
                };

                ViewData["nomeMenu"] = men_mensagem.CAIXA_ENTRADA;
                return View(mensagemRelacoes);
            } else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public ActionResult NovaMensagem()
        {
            ViewBag.ids_Destinatarios = new SelectList(
                from use in _dbContextAdUsuarios.use_usuario_setor
                join usu in _dbContextAdUsuarios.usu_usuario on use.use_id_usu equals usu.usu_id_usu
                join set in _dbContextAdUsuarios.set_setor on use.use_id_set equals set.set_id_set
                join pus in _dbContextAdUsuarios.pus_perfil_usuario on use.use_id_pus equals pus.pus_id_pus
                where use.use_flg_ativo && usu.usu_flg_ativo
                orderby set.set_nom_sigla, pus.pus_flg_gestor descending, usu.usu_nom_usuario
                select new
                {
                    use.use_id_use,
                    set.set_nom_sigla,
                    pus.pus_flg_gestor,
                    usu.usu_nom_usuario,
                    descricao = set.set_nom_sigla + (pus.pus_flg_gestor ? " - Gestor " : "") + " - " + usu.usu_nom_usuario
                }

            , "use_id_use", "descricao");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovaMensagem([Bind(Include = "titulo_mensagem,descricao_mensagem,ids_Destinatarios,binario_anexo")] MensagemPost mensagemPost)
        {
            DbContextTransaction transaction = _dbContextCiEletronica.Database.BeginTransaction();
            try
            {
                men_mensagem mensagem = new men_mensagem();
                mensagem.men_nom_titulo = mensagemPost.titulo_mensagem;
                mensagem.men_des_mensagem = mensagemPost.descricao_mensagem;
                mensagem.men_id_sme = 1;
                mensagem.men_id_tme = 1;
                mensagem.men_num_autenticacao = Guid.NewGuid().ToString().Replace("-", "");
                mensagem.men_dat_cadastro = DateTime.Now;
                mensagem.men_flg_aprovacao = false;
                _dbContextCiEletronica.men_mensagem.Add(mensagem);
                _dbContextCiEletronica.SaveChanges();

                mensagem.men_id_men_pai = mensagem.men_id_men;
                _dbContextCiEletronica.Entry(mensagem).Property(m => m.men_id_men_pai).IsModified = true;
                _dbContextCiEletronica.SaveChanges();

                cnu_controle_numeros ultimoControleNumero = _dbContextCiEletronica.cnu_controle_numeros.OrderByDescending(cnu => cnu.cnu_num_ano_ci).OrderByDescending(cnu => cnu.cnu_num_ci).FirstOrDefault();

                int anoBd = (int)ultimoControleNumero.cnu_num_ano_ci;
                int anoAtual = DateTime.Now.Year;
                int numeroCi;

                if (anoBd == anoAtual)
                {
                    numeroCi = (int)(ultimoControleNumero.cnu_num_ci + 1);
                } else
                {
                    anoBd = anoAtual;
                    numeroCi = 1;
                }
                

                cnu_controle_numeros controleNumero = new cnu_controle_numeros();
                controleNumero.cnu_id_men = mensagem.men_id_men;
                controleNumero.cnu_id_tnu = 1;
                controleNumero.cnu_num_ano_ci = anoBd;
                controleNumero.cnu_num_ci = numeroCi;
                controleNumero.cnu_num_controle = numeroCi.ToString() + anoBd.ToString();
                controleNumero.cnu_dat_cadastro = DateTime.Now;
                _dbContextCiEletronica.cnu_controle_numeros.Add(controleNumero);
                _dbContextCiEletronica.SaveChanges();

                rem_remetente remetente = new rem_remetente();
                remetente.rem_id_use = 988;
                remetente.rem_id_men = mensagem.men_id_men;
                remetente.rem_dat_cadastro = DateTime.Now;
                _dbContextCiEletronica.rem_remetente.Add(remetente);
                _dbContextCiEletronica.SaveChanges();

                foreach (int id_destinatario in mensagemPost.ids_Destinatarios)
                {
                    dme_destinatario_mensagem destinatarios = new dme_destinatario_mensagem();
                    destinatarios.dme_id_use = id_destinatario;
                    destinatarios.dme_id_men = mensagem.men_id_men;
                    destinatarios.dme_id_tde = 1;
                    destinatarios.dme_dat_cadastro = DateTime.Now;
                    _dbContextCiEletronica.dme_destinatario_mensagem.Add(destinatarios);
                    _dbContextCiEletronica.SaveChanges();
                }

                foreach (HttpPostedFileBase fileBase in mensagemPost.binario_anexo)
                {
                    max_mensagem_anexo anexo = new max_mensagem_anexo();
                    anexo.max_id_men = mensagem.men_id_men;
                    anexo.max_nom_arquivo = fileBase.FileName;
                    anexo.max_dat_cadastro = DateTime.Now;
                    anexo.max_nom_tipo = fileBase.ContentType;
                    anexo.max_num_tamanho = fileBase.ContentLength;
                    anexo.max_bin_arquivo = new byte[fileBase.ContentLength];
                    fileBase.InputStream.Read(anexo.max_bin_arquivo, 0, fileBase.ContentLength);
                    _dbContextCiEletronica.max_mensagem_anexo.Add(anexo);
                    _dbContextCiEletronica.SaveChanges();
                }
                transaction.Commit();
                return RedirectToAction("CaixaEntrada");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                transaction.Rollback();
                string message = "";
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        message = string.Format("{0}: {1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                    }
                }
                Console.WriteLine(message);
                throw new InvalidOperationException(message);
            }

            ViewBag.ids_Destinatarios = new SelectList(
                from use in _dbContextAdUsuarios.use_usuario_setor
                join usu in _dbContextAdUsuarios.usu_usuario on use.use_id_usu equals usu.usu_id_usu
                join set in _dbContextAdUsuarios.set_setor on use.use_id_set equals set.set_id_set
                join pus in _dbContextAdUsuarios.pus_perfil_usuario on use.use_id_pus equals pus.pus_id_pus
                where use.use_flg_ativo && usu.usu_flg_ativo
                orderby set.set_nom_sigla, pus.pus_flg_gestor descending, usu.usu_nom_usuario
                select new
                {
                    use.use_id_use,
                    set.set_nom_sigla,
                    pus.pus_flg_gestor,
                    usu.usu_nom_usuario,
                    descricao = set.set_nom_sigla + (pus.pus_flg_gestor ? " - Gestor " : "") + " - " + usu.usu_nom_usuario
                }
            , "use_id_use", "descricao");

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiEletronica.Models
{
    public class UsuarioSetor
    {
        public UsuarioSetor(){}

        public UsuarioSetor(usu_usuario usuario, set_setor setor)
        {
            this.usu_usuario = usuario;
            this.set_setor = setor;
        }
        public set_setor set_setor { get; set; }
        public usu_usuario usu_usuario { get; set; }
    }
}
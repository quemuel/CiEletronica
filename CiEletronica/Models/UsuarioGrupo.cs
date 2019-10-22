using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiEletronica.Models
{
    public class UsuarioGrupo
    {
        public UsuarioGrupo() { }

        public UsuarioGrupo(usu_usuario usuario, gru_grupo grupo)
        {
            this.usu_usuario = usuario;
            this.gru_grupo = grupo;
        }
        public gru_grupo gru_grupo { get; set; }
        public usu_usuario usu_usuario { get; set; }
    }
}
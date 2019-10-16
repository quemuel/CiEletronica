using System.Linq;

namespace CiEletronica.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class par_parametro
    {
        public string par_nom_parametro { get; set; }
        public string par_des_retorno { get; set; }

        public static string selectNomeParametro(string nomeParametro)
        {
            var dbContextCiEletronica = new DbContextCiEletronica();
            var parametro = dbContextCiEletronica.par_parametro
                .FirstOrDefault(x => x.par_nom_parametro == nomeParametro);
            return parametro.par_des_retorno;
        }
    }
}

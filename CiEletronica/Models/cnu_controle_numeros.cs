//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CiEletronica.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cnu_controle_numeros
    {
        public int cnu_id_cnu { get; set; }
        public Nullable<int> cnu_num_ci { get; set; }
        public string cnu_num_controle { get; set; }
        public System.DateTime cnu_dat_cadastro { get; set; }
        public int cnu_id_tnu { get; set; }
        public int cnu_id_men { get; set; }
    
        public virtual men_mensagem men_mensagem { get; set; }
        public virtual tnu_tipo_numeracao tnu_tipo_numeracao { get; set; }
    }
}

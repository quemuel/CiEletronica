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
    
    public partial class meq_mensagem_arquivada
    {
        public int meq_id_meq { get; set; }
        public int meq_id_men { get; set; }
        public int meq_id_use { get; set; }
        public bool meq_flg_arquivada { get; set; }
        public string meq_des_motivo_geral { get; set; }
        public Nullable<System.DateTime> meq_dat_cancelamento { get; set; }
        public Nullable<System.DateTime> meq_dat_arquivamento { get; set; }
    
        public virtual men_mensagem men_mensagem { get; set; }
    }
}

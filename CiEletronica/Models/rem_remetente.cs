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
    
    public partial class rem_remetente
    {
        public int rem_id_rem { get; set; }
        public System.DateTime rem_dat_cadastro { get; set; }
        public Nullable<int> rem_id_men { get; set; }
        public Nullable<int> rem_id_use { get; set; }
    
        public virtual men_mensagem men_mensagem { get; set; }
    }
}

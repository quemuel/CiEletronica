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
    
    public partial class pem_perfil_menu
    {
        public int pem_id_pem { get; set; }
        public int pem_id_pus { get; set; }
        public int pem_id_men { get; set; }
    
        public virtual men_menu men_menu { get; set; }
    }
}

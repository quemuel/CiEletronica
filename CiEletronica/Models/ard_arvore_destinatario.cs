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
    
    public partial class ard_arvore_destinatario
    {
        public int id { get; set; }
        public Nullable<int> root { get; set; }
        public int lft { get; set; }
        public int rgt { get; set; }
        public short lvl { get; set; }
        public string name { get; set; }
        public bool flg_gestor { get; set; }
        public string icon { get; set; }
        public short icon_type { get; set; }
        public short active { get; set; }
        public short selected { get; set; }
        public short disabled { get; set; }
        public short @readonly { get; set; }
        public short visible { get; set; }
        public short collapsed { get; set; }
        public short movable_u { get; set; }
        public short movable_d { get; set; }
        public short movable_l { get; set; }
        public short movable_r { get; set; }
        public short removable { get; set; }
        public short removable_all { get; set; }
        public Nullable<int> id_setor { get; set; }
    }
}

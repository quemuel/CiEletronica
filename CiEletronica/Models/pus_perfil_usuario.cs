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
    
    public partial class pus_perfil_usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pus_perfil_usuario()
        {
            this.use_usuario_setor = new HashSet<use_usuario_setor>();
        }
    
        public int pus_id_pus { get; set; }
        public string pus_nom_perfil { get; set; }
        public bool pus_flg_ativo { get; set; }
        public bool pus_flg_gestor { get; set; }
        public bool pus_flg_autorizado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<use_usuario_setor> use_usuario_setor { get; set; }
    }
}

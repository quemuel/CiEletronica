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
    
    public partial class usu_usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usu_usuario()
        {
            this.ild_informacoes_ldap = new HashSet<ild_informacoes_ldap>();
            this.use_usuario_setor = new HashSet<use_usuario_setor>();
        }
    
        public int usu_id_usu { get; set; }
        public string usu_uui_identificador { get; set; }
        public string usu_nom_usuario { get; set; }
        public string usu_nom_login { get; set; }
        public string usu_num_senha { get; set; }
        public bool usu_flg_ativo { get; set; }
        public int usu_id_gru { get; set; }
        public int usu_id_set { get; set; }
        public Nullable<System.DateTime> usu_dat_ultimo_acesso { get; set; }
        public System.DateTime usu_dat_cadastro { get; set; }
        public string usu_cod_agenda { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ild_informacoes_ldap> ild_informacoes_ldap { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<use_usuario_setor> use_usuario_setor { get; set; }
    }
}

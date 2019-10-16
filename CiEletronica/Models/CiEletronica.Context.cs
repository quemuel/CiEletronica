﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbContextCiEletronica : DbContext
    {
        public DbContextCiEletronica()
            : base("name=DbContextCiEletronica")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ase_aprovacao_setor> ase_aprovacao_setor { get; set; }
        public virtual DbSet<ass_assinatura> ass_assinatura { get; set; }
        public virtual DbSet<cas_controle_acesso> cas_controle_acesso { get; set; }
        public virtual DbSet<cnu_controle_numeros> cnu_controle_numeros { get; set; }
        public virtual DbSet<com_controle_menu> com_controle_menu { get; set; }
        public virtual DbSet<dme_destinatario_mensagem> dme_destinatario_mensagem { get; set; }
        public virtual DbSet<los_log_sistema> los_log_sistema { get; set; }
        public virtual DbSet<max_mensagem_anexo> max_mensagem_anexo { get; set; }
        public virtual DbSet<mde_mensagem_detalhes> mde_mensagem_detalhes { get; set; }
        public virtual DbSet<mea_mensagem_aprovada> mea_mensagem_aprovada { get; set; }
        public virtual DbSet<men_mensagem> men_mensagem { get; set; }
        public virtual DbSet<men_menu> men_menu { get; set; }
        public virtual DbSet<meq_mensagem_arquivada> meq_mensagem_arquivada { get; set; }
        public virtual DbSet<mra_mensagem_rascunho> mra_mensagem_rascunho { get; set; }
        public virtual DbSet<par_parametro> par_parametro { get; set; }
        public virtual DbSet<pem_perfil_menu> pem_perfil_menu { get; set; }
        public virtual DbSet<rem_remetente> rem_remetente { get; set; }
        public virtual DbSet<sme_status_mensagem> sme_status_mensagem { get; set; }
        public virtual DbSet<tde_tipo_destinatario> tde_tipo_destinatario { get; set; }
        public virtual DbSet<tme_tipo_mensagem> tme_tipo_mensagem { get; set; }
        public virtual DbSet<tnu_tipo_numeracao> tnu_tipo_numeracao { get; set; }
        public virtual DbSet<uac_usuario_acesso> uac_usuario_acesso { get; set; }
        public virtual DbSet<uau_usuario_autorizado> uau_usuario_autorizado { get; set; }
        public virtual DbSet<ume_usuario_menu> ume_usuario_menu { get; set; }
        public virtual DbSet<ard_arvore_destinatario> ard_arvore_destinatario { get; set; }
        public virtual DbSet<v_mah_mensagem_arquivada_historico> v_mah_mensagem_arquivada_historico { get; set; }
        public virtual DbSet<v_map_mensagem_pai_filha_aprovacao> v_map_mensagem_pai_filha_aprovacao { get; set; }
        public virtual DbSet<v_mau_mensagem_arquivamento_usuario> v_mau_mensagem_arquivamento_usuario { get; set; }
        public virtual DbSet<v_mce_mensagem_caixa_entrada> v_mce_mensagem_caixa_entrada { get; set; }
        public virtual DbSet<v_mfa_mensagem_pai_filha_arquivada> v_mfa_mensagem_pai_filha_arquivada { get; set; }
        public virtual DbSet<v_mfp_mensagem_pai_filha_pendencia> v_mfp_mensagem_pai_filha_pendencia { get; set; }
        public virtual DbSet<v_mfv_mensagem_pai_filha_valida> v_mfv_mensagem_pai_filha_valida { get; set; }
        public virtual DbSet<v_mnl_mensagem_nao_lida> v_mnl_mensagem_nao_lida { get; set; }
        public virtual DbSet<v_mns_mensagem_nao_lida_setor> v_mns_mensagem_nao_lida_setor { get; set; }
        public virtual DbSet<v_mpa_mensagem_pendente_aprovacao> v_mpa_mensagem_pendente_aprovacao { get; set; }
        public virtual DbSet<v_mpc_mensagem_pai_caixa_entrada> v_mpc_mensagem_pai_caixa_entrada { get; set; }
        public virtual DbSet<v_mpl_mensagem_pai_nao_lida> v_mpl_mensagem_pai_nao_lida { get; set; }
        public virtual DbSet<v_mpp_mensagem_pedente_aprovacao_pai> v_mpp_mensagem_pedente_aprovacao_pai { get; set; }
        public virtual DbSet<v_nlp_notificacao_nao_lida_pendente> v_nlp_notificacao_nao_lida_pendente { get; set; }
        public virtual DbSet<v_nls_notificacao_nao_lida_setor> v_nls_notificacao_nao_lida_setor { get; set; }
        public virtual DbSet<v_nnl_notificacao_nao_lida> v_nnl_notificacao_nao_lida { get; set; }
        public virtual DbSet<v_npa_notificacao_pendente_aprovacao> v_npa_notificacao_pendente_aprovacao { get; set; }
        public virtual DbSet<v_nps_notificacao_pendente_aprovacao_setor> v_nps_notificacao_pendente_aprovacao_setor { get; set; }
        public virtual DbSet<v_qef_quantitativo_efetivo_mensagem_filha> v_qef_quantitativo_efetivo_mensagem_filha { get; set; }
        public virtual DbSet<v_qfv_quantitativo_mensagem_filha_valida> v_qfv_quantitativo_mensagem_filha_valida { get; set; }
        public virtual DbSet<v_qmd_quantitativo_mensagem_destinatario> v_qmd_quantitativo_mensagem_destinatario { get; set; }
        public virtual DbSet<v_qmp_quantitativo_mensagem_nao_lida_pai> v_qmp_quantitativo_mensagem_nao_lida_pai { get; set; }
        public virtual DbSet<v_qpa_quantitativo_pendente_aprovacao_pai> v_qpa_quantitativo_pendente_aprovacao_pai { get; set; }
        public virtual DbSet<v_ush_usuario_autorizado_historico> v_ush_usuario_autorizado_historico { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiteGugu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Entrada
    {
        public int identrada { get; set; }
        public int idpessoa { get; set; }
        public int idcooperativa { get; set; }
        public int idproduto { get; set; }
        public int quantentrada { get; set; }
        public System.DateTime dataentrada { get; set; }
    
        public virtual Estoque Estoque { get; set; }
        public virtual ProdutorCooperativa ProdutorCooperativa { get; set; }
    }
}
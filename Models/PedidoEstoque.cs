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
    
    public partial class PedidoEstoque
    {
        public int idpedido { get; set; }
        public int idPessoa { get; set; }
        public int idproduto { get; set; }
        public int idcooperativa { get; set; }
        public int quantidade { get; set; }
        public string observproduto { get; set; }
    
        public virtual Cooperativa Cooperativa { get; set; }
        public virtual Estoque Estoque { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}

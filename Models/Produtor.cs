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
    
    public partial class Produtor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produtor()
        {
            this.ProdutorCooperativa = new HashSet<ProdutorCooperativa>();
        }
    
        public int idpessoa { get; set; }
        public long carteiraprod { get; set; }
    
        public virtual PessoaFisica PessoaFisica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdutorCooperativa> ProdutorCooperativa { get; set; }
    }
}
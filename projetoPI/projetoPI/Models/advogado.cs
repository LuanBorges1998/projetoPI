//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projetoPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class advogado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public advogado()
        {
            this.advogado1 = new HashSet<advogado>();
            this.processo = new HashSet<processo>();
        }
    
        public int id { get; set; }
        public string num_oab { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public Nullable<int> id_socio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<advogado> advogado1 { get; set; }
        public virtual advogado advogado2 { get; set; }
        public virtual usuario usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<processo> processo { get; set; }
    }
}
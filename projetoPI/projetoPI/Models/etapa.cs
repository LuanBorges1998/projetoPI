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
    using System.ComponentModel.DataAnnotations;

    public partial class etapa
    {
        public int id { get; set; }
        public int id_processo { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F2}")]
        public Nullable<double> valor_pago { get; set; }    
        public virtual processo processo { get; set; }
    }
}

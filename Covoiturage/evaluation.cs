//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Covoiturage
{
    using System;
    using System.Collections.Generic;
    
    public partial class evaluation
    {
        public int idEvaluation { get; set; }
        public Nullable<int> idUtilisateur1 { get; set; }
        public Nullable<int> idUtilisateur2 { get; set; }
        public Nullable<int> idTrajet { get; set; }
        public Nullable<int> rating { get; set; }
        public string plainte { get; set; }
        public Nullable<System.DateTime> dateEvaluation { get; set; }
    
        public virtual trajet trajet { get; set; }
        public virtual utilisateur utilisateur { get; set; }
        public virtual utilisateur utilisateur1 { get; set; }
    }
}

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
    
    public partial class reservation
    {
        public int idReservation { get; set; }
        public Nullable<System.DateTime> dateReservation { get; set; }
        public string message { get; set; }
        public Nullable<int> nbplaces { get; set; }
        public Nullable<bool> valide { get; set; }
        public Nullable<int> idTrajet { get; set; }
        public Nullable<int> idUtilisateur { get; set; }
    
        public virtual trajet trajet { get; set; }
        public virtual utilisateur utilisateur { get; set; }
    }
}
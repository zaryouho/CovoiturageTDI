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
    
    public partial class utilisateur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public utilisateur()
        {
            this.conversations = new HashSet<conversation>();
            this.conversations1 = new HashSet<conversation>();
            this.evaluations = new HashSet<evaluation>();
            this.evaluations1 = new HashSet<evaluation>();
            this.reservations = new HashSet<reservation>();
            this.voitures = new HashSet<voiture>();
        }
    
        public int idUtilisateur { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public Nullable<System.DateTime> dateN { get; set; }
        public string sexe { get; set; }
        public string mdp { get; set; }
        public string photo { get; set; }
        public string photoCIN1 { get; set; }
        public string photoCIN2 { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
        public Nullable<bool> valide { get; set; }
        public string hashCode { get; set; }
        public string presentation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<conversation> conversations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<conversation> conversations1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<evaluation> evaluations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<evaluation> evaluations1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservation> reservations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<voiture> voitures { get; set; }
    }
}

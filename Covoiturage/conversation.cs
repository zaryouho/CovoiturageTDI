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
    
    public partial class conversation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public conversation()
        {
            this.conversation1 = new HashSet<conversation>();
        }
    
        public int idConversation { get; set; }
        public Nullable<int> idUtilisateur1 { get; set; }
        public Nullable<int> idUtilisateur2 { get; set; }
        public string Message { get; set; }
        public Nullable<int> idConversationM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<conversation> conversation1 { get; set; }
        public virtual conversation conversation2 { get; set; }
        public virtual utilisateur utilisateur { get; set; }
        public virtual utilisateur utilisateur1 { get; set; }
    }
}

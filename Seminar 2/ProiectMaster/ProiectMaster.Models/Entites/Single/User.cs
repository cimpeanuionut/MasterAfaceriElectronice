using System;
using System.Collections.Generic;

#nullable disable

namespace ProiectMaster.Models.Entites
{
    public partial class User : IEntity<Guid>
    {
        public User()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool? IsActiv { get; set; }
        public int RoleId { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}

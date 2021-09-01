using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string MobileNo { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public virtual ICollection<TaskHistory> TaskHistories { get; set; }
    }
}

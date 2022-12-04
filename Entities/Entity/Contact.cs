using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entity
{
    public class Contact : IEntity
    {
        public int ContactId { get; set; }
        public string FirstLastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }

    }
}

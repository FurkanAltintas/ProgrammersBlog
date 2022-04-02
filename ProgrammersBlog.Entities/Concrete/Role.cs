using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Role : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
        // Bir rol birden fazla kullanıcıya sahip olabilir ama bir kullanıcı bir role sahip olabilir sadece
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensSkabelon.Database
{
    public class ClassRepoDb : IClassRepo
    {
        private readonly ClassDbContext _context;

        public ClassRepoDb(ClassDbContext dbContext)
        {
            _context = dbContext;
        }

        public Class1 Add(Class1 item)
        {
            item.Id = 0;
            _context.Items.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Class1? Delete(int id)
        {
            Class1? item = GetById(id);
            if (item == null)
            {
                return null;
            }
            _context.Items.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public List<Class1> GetAll()
        {
            return _context.Items.ToList();
        }
                   
        public Class1? GetById(int id)
        {
            return _context.Items.FirstOrDefault(x => x.Id == id);
        }
    }
}


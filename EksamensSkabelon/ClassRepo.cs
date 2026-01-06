using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EksamensSkabelon
{
    //for interface, højreklik, quick actions, extract interface
    public class ClassRepo : IClassRepo
    {
        //private fields behøver ikke gettere/settere da de kun bruges internt i klassen
        private List<Class1> _classList;
        //Counter til Id
        private int idCounter;

        public ClassRepo()
        {
            //instantiere listen med nogle predefinerede objekter
            _classList = new List<Class1>()
            {
                new Class1("X", "Y") { Id = 1 },
                new Class1("A", "B") { Id = 2 },
                new Class1("1", "2") { Id = 3 },
                new Class1("C", "D") { Id = 4 },
            };

            //sætter idCounter til det højeste ID i den predefinerede liste
            idCounter = _classList.Max(a => a.Id);
        }


        public List<Class1> GetAll()
        {
            return _classList;
        }

        public Class1? GetById(int id)
        {
            return _classList.FirstOrDefault(a => a.Id == id);
        }

        public Class1 Add(Class1 item)
        {
            idCounter++;
            item.Id = idCounter;
            _classList.Add(item);
            return item;
        }

        //? nullable return type
        public Class1? Delete(int id)
        {
            Class1? deletedItem = GetById(id);
            if (deletedItem != null)
            {
                _classList.Remove(deletedItem);
            }
            return deletedItem;
        }
    }
}

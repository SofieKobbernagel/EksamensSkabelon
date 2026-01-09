using System.Xml.Linq;

namespace EksamensSkabelon
{
    public class Class1
    {
        //hvis database bruges, skal properties hedde det samme som kolonnerne i databasen
        public int Id { get; set; }

        //i tilfælde af validering
        private string _prop1;
        public string Prop1
        {
            get { return _prop1; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Prop1 må ikke være tom");
                _prop1 = value; 
            }
        }

        //public gør at property kan tilgås udefra klassen
        //get; set; gør at property både kan læses og skrives til
        public string Prop2 { get; set; }

        //Constructor med parametre
        public Class1(string ExampleProp, string E2)
        {
            Prop1 = ExampleProp;
            Prop2 = E2;
        }

        //default constructor
        public Class1()
        {

        }
    }
}

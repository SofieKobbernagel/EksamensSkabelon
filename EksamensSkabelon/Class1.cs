using System.Xml.Linq;

namespace EksamensSkabelon
{
    public class Class1
    {
        //hvis database bruges, skal properties hedde det samme som kolonnerne i databasen
        public int Id { get; set; }
        public string Prop1 { get; set; }
        //public gør at property kan tilgås udefra klassen
        //get; set; gør at property både kan læses og skrives til
        public string Prop2 { get; set; }

        //Constructor med parametre
        public Class1(string ExampleName, string E2)
        {
            //i tilfælde af validering
            if (string.IsNullOrWhiteSpace(ExampleName))
                throw new ArgumentException("Name må ikke være tom");
            Prop1 = ExampleName;
            Prop2 = E2;
        }

        //default constructor
        public Class1()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Partijen;
using Domain.Vragen;

namespace DAL
{
    public class TestRepository
    {
        private List<TestVraag> vragen;

        public TestRepository()
        {
            vragen = new List<TestVraag>();
            TestAntwoord antwoord1 = new TestAntwoord("Ik zoek een creche en werk",
                new List<string>(new string[]
                    {"Je kan concentreren op zoektoch werk", "kinderen hebben contact met andere"}),
                new List<string>(new string[] { "kinderopvang kost veel geld", "kindere moeten lange dagen draaien" }));
            TestAntwoord antwoord2 = new TestAntwoord("Ik wacht to de kindere groter zijn",
                new List<string>(new string[] { "Je ziet je kindere meer", "Kinderen kunnen veilig groot worden" }),
                new List<string>(new string[] { "je hebt minder geld", "geen werk" }));

            TestVraag vraag1 =
                new TestVraag("Je krijgt een werkloosheidsuitkering en je jonge kinderen zijn thuis....", 1, antwoord1,
                    antwoord2, new Thema(), new Niveau(1));
            vragen.Add(vraag1);
        }

        public TestVraag GetVraagByIndex(int index)
        {
            return vragen[index];
        }
    }
}

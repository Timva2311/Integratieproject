using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Partijen;
using Domain.Vragen;
using Domain;
using Domain.Beslissingen;

namespace DAL
{
    public class TestRepository
    {
        private List<TestVraag> vragen;
        private static Gebruiker gebruiker = new Gebruiker(1);

        public TestRepository()
        {
            //gebruiker
            gebruiker.Eigenschappen.Add(new Eigenschap(1, "kinderen", Status.FALSE));

            //vraag 1
            Thema werk = new Thema();
            werk.Name = "Werk";
            vragen = new List<TestVraag>();
            Niveau niveau1 = new Niveau(1);
            List<Eigenschap> eigenschappen = new List<Eigenschap>();
            eigenschappen.Add(new Eigenschap(1, "kinderen", Status.TRUE));

            TestAntwoord antwoord1 = new TestAntwoord("Ik zoek een creche en werk",
                new List<string>(new string[]
                    {"Je kan concentreren op zoektoch werk", "kinderen hebben contact met andere"}),
                new List<string>(new string[] { "kinderopvang kost veel geld", "kindere moeten lange dagen draaien" }));
            Resultaat res1 = new Resultaat();
            res1.Kans = 1;
            res1.Text = "Je hebt gekozen voor werk zoeken en creche zoeken voor de kinderen.";
            antwoord1.SuccesResultaat = res1;

            TestAntwoord antwoord2 = new TestAntwoord("Ik wacht to de kindere groter zijn",
                new List<string>(new string[] { "Je ziet je kindere meer", "Kinderen kunnen veilig groot worden" }),
                new List<string>(new string[] { "je hebt minder geld", "geen werk" }));
            Resultaat res2 = new Resultaat();
            res2.Kans = 1;
            res2.Text = "Je hebt gekozen om te wachten tot de kinderen groter zijn.";
            antwoord2.SuccesResultaat = res2;

            TestVraag vraag1 =
                new TestVraag("Je krijgt een werkloosheidsuitkering en je jonge kinderen zijn thuis....", 1, antwoord1,
                    antwoord2, werk, niveau1);

            vraag1.Eigenschappen = eigenschappen;
            vragen.Add(vraag1);


            //vraag 2
            Resultaat r1 = new Resultaat();
            r1.Text = "Je hebt het contract aangenomen en je hebt een job. Het zijn lange dagen, maar je bent tevreden dat je ervaring opbouwt";
            r1.Kans = 0.7;
            r1.EigenschappenToUpdate.Add(new Eigenschap(2, "Job", Status.TRUE));

            Resultaat r2 = new Resultaat();
            r2.Text = "Je hebt het contract aangenomen, wanneer de subsidies stoppen wordt je onmiddellijk ontslagen. Je hebt geen job.";
            r2.Kans = 0.2;
            r2.EigenschappenToUpdate.Add(new Eigenschap(2, "Job", Status.FALSE));

            Resultaat r3 = new Resultaat();
            r3.Text = "Je hebt het contract aangenomen. Je koopt een wagen met je spaargeld, maar wordt opgelicht.Je geraakt niet op je werk en hebt hoge schulden";
            r3.Kans = 0.1;
            r3.EigenschappenToUpdate.Add(new Eigenschap(2, "Job", Status.UNKNOWN));

            List<Eigenschap> eigenschappen2 = new List<Eigenschap>();
            eigenschappen2.Add(new Eigenschap(1, "kinderen", Status.FALSE));

            TestAntwoord antwoord3 = new TestAntwoord("Ik neem het contract aan",
                new List<string>(new string[]
                    {"Je doet ervaring op","Je leert mensen kennen"}),
                new List<string>(new string[] { "Grote kosten maken: auto kopen, nieuwe kleren", "Je vreest voor je gezondheid" }));
            antwoord3.SuccesResultaat = r1;
            antwoord3.FaalResultaat = r2;
            antwoord3.EindResultaat = r3;

            TestAntwoord antwoord4 = new TestAntwoord("Ik wacht op een interessanter aanbod",
                new List<string>(new string[] { "Je beschikt over je eigen tijd", "Je moet geen extra investeringen doen" }),
                new List<string>(new string[] { "Werkloosheidsuitkering zakt verder na een tijdje", "eenzaamheid" }));

            Resultaat r8 = new Resultaat();
            r8.Text = "Je hebt gekozen om te wachten op een interessantere job, dus je hebt momenteel geen job.";
            r8.Kans = 1;
            r8.EigenschappenToUpdate.Add(new Eigenschap(2, "Job", Status.FALSE));
            antwoord4.SuccesResultaat = r8;

            TestVraag vraag2 =
                new TestVraag("Je hebt een stage gedaan via de VDAB in een restaurant in de keuken. Je krijgt een tijdelijk contract aangeboden aan het minimumloon. ", 2, antwoord3,
                    antwoord4, werk, niveau1);
            vraag2.Eigenschappen = eigenschappen2;
            vragen.Add(vraag2);

            //vraag 3
            Thema vrijeTijd = new Thema();
            vrijeTijd.Name = "Vrije tijd";
            Niveau niveau2 = new Niveau(2);
            List<Eigenschap> eigenschappen3 = new List<Eigenschap>();

            TestAntwoord antwoord5 = new TestAntwoord("Ik kies om 3 keer per week te sporten.",
                new List<string>(new string[]
                    {"Je voelt je gezonder","Je leert mensen kennen"}),
                new List<string>(new string[] { "Het is kostelijk", "het is soms laat in de avond" }));
            Resultaat res5 = new Resultaat();
            res5.Kans = 1;
            res5.Text = "Je hebt gekozen om 3 keer per week te sporten.";
            res5.EigenschappenToUpdate.Add(new Eigenschap(5, "Sport", Status.TRUE));
            antwoord5.SuccesResultaat = res5;

            TestAntwoord antwoord6 = new TestAntwoord("Ik blijf thuis.",
                new List<string>(new string[] { "Je beschikt over je eigen tijd", "Je hoeft geen geld uit te geven" }),
                new List<string>(new string[] { "Je voelt je lui", "Je hebt niet veel menselijk contact" }));
            Resultaat res6 = new Resultaat();
            res6.Kans = 1;
            res6.Text = "Je hebt gekozen om thuis te blijven.";
            res6.EigenschappenToUpdate.Add(new Eigenschap(5, "Sport", Status.FALSE));
            antwoord6.SuccesResultaat = res6;

            TestVraag vraag3 =
                new TestVraag("Je hebt een elke dag wat tijd voor jezelf. Je hebt de mogelijkheid om te sporten.", 3, antwoord5,
                    antwoord6, vrijeTijd, niveau2);

            vraag3.Eigenschappen = eigenschappen3;

            vragen.Add(vraag3);


            //vraag 5
            Thema woning = new Thema();
            woning.Name = "Woning";
            Niveau niveau3 = new Niveau(3);
            List<Eigenschap> eigenschappen5 = new List<Eigenschap>();
            eigenschappen5.Add(new Eigenschap(2, "Job", Status.FALSE));

            TestAntwoord antwoord9 = new TestAntwoord("Ik ga naar het OCMW",
                new List<string>(new string[]
                    {"Je krijgt een uitkering"}),
                new List<string>(new string[] { "Je bent officieel in armoede.","Het is vernederend." }));
            Resultaat res3 = new Resultaat();
            res3.Kans = 1;
            res3.Text = "Je hebt gekozen om naar het OCMW te gaan.";
            antwoord9.SuccesResultaat = res3;

            TestAntwoord antwoord10 = new TestAntwoord("Ik wil rotten in armoede.",
                new List<string>(new string[] { "Je hoeft er niets voor te doen." }),
                new List<string>(new string[] { "Rotten is niet leuk", "Je stinkt" }));
            Resultaat res4 = new Resultaat();
            res4.Kans = 1;
            res4.Text = "Je hebt gekozen om te rotten in armoede.";
            antwoord10.SuccesResultaat = res4;

            TestVraag vraag5 =
                new TestVraag("Je hebt geen werk en hebt dus de keuze om naar het OCMW te gaan of te rotten in uw armoede.", 5, antwoord9,
                    antwoord10, werk, niveau3);
            vraag5.Eigenschappen = eigenschappen5;
            vragen.Add(vraag5);

            //vraag 6.1
            
            Niveau niveau4 = new Niveau(4);
            List<Eigenschap> eigenschappen6 = new List<Eigenschap>();
            eigenschappen6.Add(new Eigenschap(4, "woning huren", Status.TRUE));

            TestAntwoord antwoord11 = new TestAntwoord("Ik zoek naar een woning op de privémarkt",
                new List<string>(new string[]
                    {}),
                new List<string>(new string[] {}));

            TestAntwoord antwoord12 = new TestAntwoord("Ik zoek een sociale woning",
                new List<string>(new string[] {}),
                new List<string>(new string[] {}));

            TestVraag vraag6 =
                new TestVraag("Je probeert een appartement op de privé markt te vinden of je zoekt een sociale woning.", 6, antwoord11,
                    antwoord12, woning, niveau4);
            vraag6.Eigenschappen = eigenschappen6;
            vragen.Add(vraag6);

            //vraag 6.2

            List<Eigenschap> eigenschappen7 = new List<Eigenschap>();
            eigenschappen7.Add(new Eigenschap(4, "woning huren", Status.TRUE));

            TestAntwoord antwoord13 = new TestAntwoord("Meld het probleem bij de bevoegde diensten.",
                new List<string>(new string[]
                    {}),
                new List<string>(new string[] { }));

            TestAntwoord antwoord14 = new TestAntwoord("Meld het niet aan de bevoegde diensten.",
                new List<string>(new string[] { }),
                new List<string>(new string[] { }));

            TestVraag vraag7 =
                new TestVraag("Je kan de slechte staat van je appartement melden bij de bevoegde diensten.Maar ben je wel zeker dat je dat wil doen.", 7, antwoord13,
                    antwoord14, woning, niveau4);
            vraag7.Eigenschappen = eigenschappen7;
            vragen.Add(vraag7);

            //vraag 4
            List<Eigenschap> eigenschappen4 = new List<Eigenschap>();
            eigenschappen4.Add(new Eigenschap(2, "Job", Status.TRUE));

            Resultaat r4 = new Resultaat();
            r4.Text = "Je hebt een woning gekocht.Zolang je werkt heb je een dakboven je hoofd. Het dak lekt, er is geen verwarming en er staat schimmelop de muren.";
            r4.Kans = 0.95;
            r4.EigenschappenToUpdate.Add(new Eigenschap(3, "woning kopen", Status.TRUE));

            Resultaat r5 = new Resultaat();
            r5.Text = "Je hebt een huis gekocht. Het blijkt onbewoonbaar en je staat dus op straat.";
            r5.Kans = 0.05;
            r5.EigenschappenToUpdate.Add(new Eigenschap(3, "woning kopen", Status.TRUE));

            Resultaat r6 = new Resultaat();
            r6.Text = "Je gaat op de huurmarkt, maar dat blijkt niet evident. Je moet nog een keuze maken.";
            r6.Kans = 0.5;
            r6.EigenschappenToUpdate.Add(new Eigenschap(4, "woning huren", Status.TRUE));
            r6.VolgendeVraag = vraag6;

            Resultaat r7 = new Resultaat();
            r7.Text = "Je hebt een huurhuis gevonden. Maar het blijkt wel in zeer slechte staat.";
            r7.Kans = 0.5;
            r7.EigenschappenToUpdate.Add(new Eigenschap(4, "woning huren", Status.TRUE));
            r7.VolgendeVraag = vraag7;  

            TestAntwoord antwoord7 = new TestAntwoord("Ik ga op zoek naar een woning om te kopen",
                new List<string>(new string[]
                    {"Maandelijkse afbetaling is lager dan huur","De woning wordt je eigendom"}),
                new List<string>(new string[] { "Woning is in zeer slechte staat", "Verantwoordelijk voor onderhoud" }));

            antwoord7.SuccesResultaat = r4;
            antwoord7.FaalResultaat = r5;

            TestAntwoord antwoord8 = new TestAntwoord("Ik ga op zoek naar een huurwoning.",
                new List<string>(new string[] { "Onderhoud is verantwoordelijkheid verhuurder", "Minder gelduitgave" }),
                new List<string>(new string[] { "Aanzienlijk duurder", "Moeilijk om iets te vinden" }));

            antwoord8.SuccesResultaat = r6;
            antwoord8.FaalResultaat = r7;

            TestVraag vraag4 =
                new TestVraag("Je hebt werk en hebt dus de keuze om een woning te kopen of iets te huren", 4, antwoord7,
                    antwoord8, woning, niveau3);
            vraag4.Eigenschappen = eigenschappen4;
            vragen.Add(vraag4);

            //vraag 8

            TestAntwoord antwoord15 = new TestAntwoord("Ik stem ja.",
                new List<string>(new string[]
                    {"Geen"}),
                new List<string>(new string[] { "Geen" }));

            TestAntwoord antwoord16 = new TestAntwoord("Ik stem nee.",
                new List<string>(new string[] { "Geen" }),
                new List<string>(new string[] { "Geen" }));

            TestVraag vraag8 =
                new TestVraag("Dit is de laatste vraag als test.", 8, antwoord15,
                    antwoord16, woning, niveau4);
            vragen.Add(vraag8);
        }

        public Gebruiker ResetUser()
        {
            return gebruiker = new Gebruiker(1);
        }

        public Gebruiker AddNewUserProp(Eigenschap item)
        {
            gebruiker.Eigenschappen.Add(item);
            return gebruiker;
        }

        public Gebruiker GetUser()
        {
            return gebruiker;
        }

        public TestVraag GetVraagByIndex(int niveau)
        {
            List<TestVraag> lijst = vragen.Where(t => t.Niveau.Id == niveau).ToList();

            foreach (var vraag in lijst)
            {
                if (vraag.Antwoord1.SuccesResultaat.VolgendeVraag != null)
                {
                    return vraag.Antwoord1.SuccesResultaat.VolgendeVraag;
                }
                if (vraag.Antwoord1.FaalResultaat.VolgendeVraag != null)
                {
                    return vraag.Antwoord1.FaalResultaat.VolgendeVraag;
                }
                if (!vraag.Eigenschappen.Except(GetUser().Eigenschappen).Any())
                {
                    return vraag;
                }
            }
            return null;
        }
    }
}

using Biblioteca_UniLib.Models;
using System.Linq;

namespace Biblioteca_UniLib.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;

        public DbInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Run()
        {
            _context.Database.EnsureCreated();

            // Look for any categories.
            if (_context.Category.Any())
            {
                return; // DB has been seeded
            }

            if (_context.courses.Any()) // Certifique-se de que está usando "Courses"
            {
                return; // DB has been seeded
            }


            var categories = new Category[]
           {                
                new Category{Name="Fantasia", Description="Fantasia",Author="Autor1"},
                new Category{Name="Finanças", Description="Finanças",Author = "Autor2"},
                new Category{Name="Comédia", Description="Comedia", Author = "Autor3"},
                new Category{Name="Romance", Description="Romance", Author = "Autor4"},
                new Category{Name="Ficção", Description="Ficção", Author = "Autor5"},
                new Category{Name="Arte", Description="Arte",Author = "Autor6"},
           };

            _context.Category.AddRange(categories);
            _context.SaveChanges();

            var courses = new Course[]
            {
                new Course
                {
                    Name="A Cegueira do Rio",
                    Description="O primeiro incidente militar numa aldeia do Norte de Moçambique marca, em agosto de 1914, o início da Primeira Guerra Mundial no continente africano.\r\n\r\nEsse inesperado episódio despoleta, para além disso, uma série de misteriosos eventos que culminam com o desaparecimento da escrita no mundo. Livros, relatórios, documentos, fotografias, mapas surgem deslavados e ninguém mais parece ser capaz de dominar a arte da escrita.\r\n\r\nOs habitantes dessa aldeia são chamados a restabelecer a ordem no mundo, ensinando aos europeus o ofício da escrita e as artes da navegação.",
                    CoverPhoto= "a_cegueira_do_rio.jpeg",
                    Author="Mia Couto",
                    Addrec=true,
                    Dest=false,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },
                new Course
                {
                    Name="A Cirurgiã",
                    Description="A vida de uma talentosa cirurgiã se transforma em um pesadelo quando ela se torna o principal alvo de um perigoso assassino. Entre segredos médicos e decisões de vida ou morte, ela precisará usar toda a sua inteligência para sobreviver e descobrir a verdade por trás das ameaças.",
                    CoverPhoto= "a-cirurgia.jpeg",
                    Author="Leslie Wolfe",
                    Addrec=true,
                    Dest=false,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },
                 new Course
                {
                    Name="A Criada",
                    Description="Uma jovem empregada entra em uma mansão luxuosa, mas logo descobre que os segredos da casa são mais obscuros do que ela jamais imaginou. Agora, ela precisa decidir entre proteger seus empregadores ou salvar a própria vida.",
                    CoverPhoto= "a-criada.jpeg",
                    Author="Freida McFadden",
                    Addrec=true,
                    Dest=false,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },
                 new Course
                {
                    Name="Ala D",
                    Description="Em um hospital sombrio, a misteriosa Ala D é conhecida por histórias assustadoras. " +
                    "Quando uma enfermeira começa a trabalhar ali, ela descobre que as lendas podem ser mais reais – e perigosas – do que imaginava.\r\n",
                    CoverPhoto= "ala-d.jpeg",
                    Author="Freida McFadden",
                    Addrec=true,
                    Dest=false,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },
                  new Course
                {
                    Name="Crime na Quinta das Lágrimas",
                    Description="Um assassinato na histórica Quinta das Lágrimas abala a cidade. " +
                    "Um investigador dedicado mergulha em um mistério cheio de intrigas e romance," +
                    " cruzando o passado e o presente.",
                    CoverPhoto= "crime-na-quinta-das-lagrimas.jpeg",
                    Author="Lourenço Seruya",
                    Addrec=true,
                    Dest=false,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },

                   new Course
                {
                    Name="Desejo Secreto",
                    Description="Quando um encontro inesperado revela sentimentos intensos e segredos ocultos," +
                    " dois amantes enfrentam uma batalha entre o desejo e as consequências de suas escolhas.",
                    CoverPhoto= "desejo-secreto-4.jpeg",
                    Author="Catarina Maura",
                    Addrec=true,
                    Dest=false,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },

                   new Course
                {
                    Name="Inês de Castro",
                    Description="A trágica história de Inês de Castro ganha vida nesta narrativa envolvente, " +
                    "explorando seu amor proibido com o príncipe Pedro e as intrigas da corte medieval portuguesa.",
                    CoverPhoto= "ines-de-castro-3.jpeg",
                    Author="Isabel Stilwell",
                    Addrec=true,
                    Dest=false,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },

                   new Course
                {
                    Name="O Escritório",
                    Description="Uma assistente dedicada descobre um segredo chocante sobre seu chefe. " +
                    "O que começa como uma simples desconfiança logo se transforma em uma luta por sua própria segurança.",
                    CoverPhoto= "o-escritorio-4.jpeg",
                    Author="Freida McFadden",
                    Addrec=true,
                    Dest=false,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },

                    new Course
                {
                    Name="O Mágico de Auschwitz",
                    Description="Inspirado em uma história real, " +
                    "este romance conta a jornada de um mágico que usa " +
                    "seus truques para sobreviver ao Holocausto e trazer " +
                    "esperança aos prisioneiros ao seu redor.",
                    CoverPhoto= "o-magico-de-auschwitz-1.jpeg",
                    Author="José Rodrigues dos Santos",
                    Addrec=false,
                    Dest=true,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },
                    new Course
                {
                    Name="O Peso da Culpa",
                    Description="Um psicólogo criminal atormentado enfrenta um novo caso " +
                    "que revive traumas do passado. Enquanto luta contra seus demônios internos," +
                    " ele precisa solucionar um crime que desafia a lógica.",
                    CoverPhoto= "o-peso-da-culpa-sebastian-bergman-8.jpeg",
                    Author="Sebastian Bergman",
                    Addrec=false,
                    Dest=true,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },
                      new Course
                {
                    Name="O Recluso",
                    Description="Um homem misterioso vive isolado do mundo, " +
                    "até que uma nova vizinha começa a questionar os motivos de sua reclusão. " +
                    "O que ela descobre pode mudar a vida de ambos para sempre.",
                    CoverPhoto= "o-recluso.jpeg",
                    Author="Freida McFadden",
                    Addrec=true,
                    Dest=false,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },
                    new Course
                {
                    Name="O Segredo da Criada",
                    Description="A empregada de uma família aparentemente perfeita " +
                    "descobre um segredo chocante que ameaça destruir todos ao seu redor." +
                    " Em um jogo de manipulações, ela precisa decidir em quem confiar.",
                    CoverPhoto= "o-segredo-da-criada.jpeg",
                    Author="Freida McFadden",
                    Addrec=true,
                    Dest=true,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },
                    new Course
                {
                    Name="O Segredo de Espinosa",
                    Description="O mistério por trás das ideias revolucionárias de " +
                    "Espinosa leva a uma investigação perigosa, cheia de conspirações e " +
                    "enigmas filosóficos.",
                    CoverPhoto= "o-segredo-de-espinosa.jpeg",
                    Author="José Rodrigues dos Santos",
                    Addrec=false,
                    Dest=true,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },
                    new Course
                {
                    Name="Perfeito Inimigo",
                    Description="Dois estranhos se encontram em circunstâncias " +
                    "inesperadas e iniciam um relacionamento explosivo, repleto de " +
                    "paixão e segredos que ameaçam destruí-los.",
                    CoverPhoto= "o-perfeito-inimigo.jpeg",
                    Author="T. L. Swan",
                    Addrec=false,
                    Dest=true,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },
                    new Course
                {
                    Name="Prazer Proibido",
                    Description="Um romance proibido surge entre dois mundos opostos. " +
                    "O desejo se torna irresistível, mas os segredos podem transformar a" +
                    " paixão em destruição.",
                    CoverPhoto= "prazer-proibido-2.jpeg",
                    Author="T. L. Swan",
                    Addrec=false,
                    Dest=true,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },
                    new Course
                {
                    Name="Primeira Classe",
                    Description="Uma viagem de primeira classe aproxima dois desconhecidos. " +
                    "Porém, o que parecia um encontro casual transforma-se em um amor inesperado " +
                    "e repleto de reviravoltas.",
                    CoverPhoto= "primeira-classe.jpeg",
                    Author="T. L. Swan",
                    Addrec=false,
                    Dest=true,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },
                    new Course
                {
                    Name="Uma Fortuna Perigosa",
                    Description="A ascensão e queda de uma família poderosa no mundo" +
                    " bancário é marcada por traições, ambições e um segredo que pode mudar tudo.",
                    CoverPhoto= "uma-fortuna-perigosa.jpeg",
                    Author="Ken Follett",
                    Addrec=false,
                    Dest=true,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },
                    new Course
                {
                    Name="Um Duque para Amar",
                    Description="Uma jovem decidida a conquistar seu próprio destino desafia as " +
                    "convenções ao se apaixonar por um duque misterioso e encantador.",
                    CoverPhoto= "um-duque-para-amar.jpeg",
                    Author="Sarah MacLean",
                    Addrec=false,
                    Dest=true,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },
                    new Course
                {
                    Name="Vaticanum",
                    Description="Segredos ocultos no coração do Vaticano colocam a Igreja em risco." +
                    " Um jornalista e um historiador unem forças para desvendar uma conspiração que pode abalar o mundo.",
                    CoverPhoto= "vaticanum-4.jpeg",
                    Author="José Rodrigues dos Santos",
                    Addrec=false,
                    Dest=true,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID

                },


            };

            _context.courses.AddRange(courses); // Certifique-se de que está usando "Courses"
            _context.SaveChanges();
        }
    }
}
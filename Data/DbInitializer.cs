using Biblioteca_UniLib.Models;
using Mono.TextTemplating;
using System.IO;
using System.Linq;
using System.Numerics;

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
                    Description = "O primeiro incidente militar numa aldeia do Norte de Moçambique marca, " +
                    "em agosto de 1914, o início da Primeira Guerra Mundial no continente africano.",                   
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
                    Description="A vida de uma talentosa cirurgiã se transforma em um pesadelo " +
                    "quando ela se torna o principal alvo de um perigoso assassino.",
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
                    Description="Uma jovem empregada entra em uma mansão luxuosa, " +
                    "mas logo descobre que os segredos da casa são mais obscuros do " +
                    "que ela jamais imaginou.",
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
                    "Quando uma enfermeira começa a trabalhar ali, ela descobre que as lendas podem ser mais reais – " +
                    "e perigosas – do que imaginava.\r\n",
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
                    CoverPhoto= "perfeito-inimigo.jpeg",
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
                    new Course
                    {
                        
                        Name="A Muralha de Gelo",
                        Description="George R. R. Martin Parte do universo de 'As Crônicas de Gelo e Fogo', " +
                        "este conto explora a Muralha, a gigantesca estrutura de gelo que separa os Sete Reinos das terras selvagens. ",
                        CoverPhoto= "a-muralha-de-gelo.jpg",
                        Author="George R.R. Martin",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Fantasia").ID

                    },
                    new Course {
                        Name="A Chama de Ferro",
                        Description="A sequência de 'Quarta Asa' continua a jornada de Violet Sorrengail " +
                        "na escola de domadores de dragões. " +
                        " Um romance épico cheio de magia, traição e coragem.",
                        CoverPhoto= "chama-de-ferro.jpg",
                        Author="Rebecca Yarros",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Fantasia").ID

                    },
                    new Course
                    {
                        Name="Como parar o tempo",
                        Description="Hazard parece um homem comum, mas possui uma condição rara: ele vive há séculos." +
                        " Enquanto tenta levar uma vida tranquila como professor em Londres, seu passado complexo e perigoso ameaça destruí-lo.",
                        CoverPhoto= "chama-de-ferro.jpg",
                        Author="Matt HaigTom",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Fantasia").ID

                    },
                    new Course
                    {
                        Name="Duna",
                        Description="No planeta desértico de Arrakis, Paul Atreides descobre seu destino" +
                        " como um messias para os Fremen e para o futuro do universo. Com batalhas políticas" +
                        " e ecológicas, 'Duna' é um clássico da ficção científica que explora poder, religião e sobrevivência.",
                        CoverPhoto= "duna-4.jpg",
                        Author="Frank Herbert",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Fantasia").ID

                    },
                    new Course
                    {
                        Name="Eragon",
                        Description="Eragon encontra um ovo de dragão que muda sua vida para sempre," +
                        " tornando-se um Cavaleiro de Dragão. Embarca em uma aventura cheia de magia," +
                        " batalhas e descobertas, com o destino de Alagaësia em suas mãos.",
                        CoverPhoto= "eragon-book-one.jpg",
                        Author="Christopher Paolini",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Fantasia").ID

                    },
                    new Course
                    {
                        Name="Espada de Vidro",
                        Description="Mare Barrow continua sua luta contra um sistema que discrimina os Vermelhos. " +
                        "Com seus poderes elétricos, ela lidera uma rebelião contra os governantes Prateados e enfrenta " +
                        "traições que testarão sua coragem e lealdade.",
                        CoverPhoto= "espada-de-vidro-2.jpg",
                        Author="Victoria Aveyard",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Fantasia").ID
                    },
                    new Course
                    {
                        Name="Gleam",
                        Description="Neste terceiro volume da série 'Plated Prisoner', Auren descobre sua força" +
                        " enquanto luta para se libertar das correntes da manipulação e do poder." +
                        " Com reviravoltas sombrias, é uma história de autodescoberta e resistência.",
                        CoverPhoto= "gleam-14.jpg",
                        Author="Raven Kennedy",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Fantasia").ID

                    },
                    new Course
                    {
                        Name="Harry Potter e o Prisioneiro de Azkaban",
                        Description="Com Sirius Black, um suposto aliado de Voldemort, fugindo da" +
                        " prisão de Azkaban, Harry enfrenta verdades sombrias sobre sua família. " +
                        "Este terceiro ano em Hogwarts é marcado por suspense, amizades e segredos revelados.",
                        CoverPhoto= "harry-potter-e-o-prisioneiro-de-azkaban-1.jpg",
                        Author="J.K. Rowling",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Fantasia").ID

                    },
                    new Course
                    {
                        Name="O Hobbit",
                        Description="Bilbo Bolseiro, um hobbit tranquilo, é levado a uma aventura para recuperar" +
                        " o tesouro dos anãos, guardado por Smaug, o dragão. Um conto de coragem, amizade e descobertas inesperadas.",
                        CoverPhoto= "o-hobbit-3.jpg",
                        Author="J.R.R. Tolkien",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Fantasia").ID

                    },
                    new Course
                    {
                        Name="Sangue e Fogo",
                        Description="Uma crônica da história da Casa Targaryen, desde sua ascensão" +
                        " em Valíria até sua conquista de Westeros. Cheio de intrigas, guerras e dragões," +
                        " é uma expansão fascinante do mundo de 'As Crônicas de Gelo e Fogo'.",
                        CoverPhoto= "sangue-e-fogo-a-historia-dos-reis-targaryen.jpg",
                        Author="George R. R. Martin",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Fantasia").ID

                    },
                    new Course
                    {
                        Name="Humanos",
                        Description="Uma análise bem-humorada sobre os erros, acertos e peculiaridades que moldaram a história da humanidade.",
                        CoverPhoto= "humanos.jpg",
                        Author="Tom Phillips",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Arte").ID

                    },
                    new Course
                    {
                        Name="Homo Deus",
                        Description="Harari investiga o futuro da humanidade, abordando o impacto da tecnologia, ciência e inteligência artificial.",
                        CoverPhoto= "homodeus.jpg",
                        Author="Yuval Noah Harari",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Arte").ID

                    },
                    new Course
                    {
                        Name="A Idade Média",
                        Description="Redescobre o período medieval, revelando avanços científicos e culturais que desafiam os estereótipos tradicionais.",
                        CoverPhoto= "idademedia.jpg",
                        Author="Seb Falk",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Arte").ID

                    },
                    new Course
                    {
                        Name="Os Portugueses",
                        Description="Uma celebração da identidade e das contribuições culturais e históricas de Portugal ao longo dos séculos.",
                        CoverPhoto= "ospts.jpg",
                        Author="Barry Hatton",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Arte").ID

                    },
                    new Course
                    {
                        Name="O Poder dos Mapas",
                        Description="Examina como os mapas moldaram nosso entendimento do mundo e seu impacto na geopolítica.",
                        CoverPhoto= "poderdosmapas.jpg",
                        Author="José Gomes Ferreira",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Arte").ID

                    },
                    new Course
                    {
                        Name="A Origem da Ciência",
                        Description="Desvenda como as bases da ciência moderna foram lançadas durante a Idade Média.",
                        CoverPhoto= "origemciencia.jpg",
                        Author="James Hannam",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Arte").ID

                    },
                    new Course
                    {
                        Name="Sangue na Neve",
                        Description="Um thriller histórico envolvente que narra mistérios e traições em tempos de guerra.",
                        CoverPhoto= "sanguenaneve.jpg",
                        Author="Robert Service",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Arte").ID

                    },
                    new Course
                    {
                        Name="Salazar",
                        Description="Analisa a influência de Salazar nas cidades portuguesas e as mudanças urbanas durante o regime.",
                        CoverPhoto= "salazar.jpg",
                        Author="Manuel S.Fonseca",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Arte").ID

                    },
                    new Course
                    {
                        Name="O Maior Poeta da China",
                        Description="Uma biografia cativante de Li Bai, considerado um dos maiores poetas da literatura chinesa.",
                        CoverPhoto= "omaiorpoetadachina.jpg",
                        Author=" Michael Wood",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Arte").ID

                    },
                    new Course
                    {
                        Name="A Arte da Guerra",
                        Description="Um clássico atemporal sobre estratégia e liderança, que apresenta ensinamentos" +
                        " aplicáveis tanto em batalhas quanto em desafios da vida moderna.",
                        CoverPhoto= "a-arte-da-guerra-56.jpg",
                        Author="Sun Tzu",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Arte").ID

                    },
                    new Course
                    {
                        Name="Pai Rico, Pai Pobre",
                        Description="Lições sobre finanças pessoais e investimentos ensinadas de maneira simples e prática.",
                        CoverPhoto= "pai-rico-pai-pobre.jpeg",
                        Author="Robert Kiyosaki",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID

                    },
                    new Course
                    {
                        Name="Ponha o Seu Dinheiro Para Trabalhar Para Si",
                        Description="Dicas para investir de forma inteligente e fazer o dinheiro render.",
                        CoverPhoto= "ponha-o-seu-dinheiro-a-trabalhar-para-si.jpeg",
                        Author="Bárbara Barroso",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID

                    },
                    new Course
                    {
                        Name="A Psicologia do Dinheiro",
                        Description="Histórias e lições sobre o impacto da psicologia nas decisões financeiras.",
                        CoverPhoto= "psicologiadinheiro.jpeg",
                        Author="Morgan Housel",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID

                    },
                    new Course
                    {
                        Name="Rich Dad's Cashflow Quadrant",
                        Description="Explica os quatro quadrantes financeiros e como alcançar liberdade financeira.",
                        CoverPhoto= "rich-dad-s-cashflow-quadrant-2.jpeg",
                        Author="Robert Kiyosaki",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID

                    },

                    new Course
                    {
                        Name="Segredos da Mente Milionária",
                        Description="Mais reflexões sobre a mentalidade necessária para construir riqueza.",
                        CoverPhoto= "segredos-da-mente-milionaria.jpeg",
                        Author="T. Harv Eker",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID
                    },
                    new Course
                    {
                        Name="Vender é Humano",
                        Description="Técnicas de vendas e persuasão do famoso 'Lobo de Wall Street'",
                        CoverPhoto= "vender.jpeg",
                        Author="Jordan Belfort",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID

                    },
                    new Course
{
                        Name="7 Segredos Para Investir Como Warren Buffett",
                        Description="Uma introdução aos princípios que fizeram de Warren Buffett um dos investidores mais bem-sucedidos do mundo.",
                        CoverPhoto= "7-segredos-para-investir-como-warren-buffett.jpeg",
                        Author="Mary Buffett",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID

                    },
                    new Course
                    {
                        Name="A Bíblia do Investimento em Criptomoeda",
                        Description="Um guia abrangente para compreender e investir em criptomoedas, desmistificando o mercado digital.",
                        CoverPhoto="a-biblia-do-investimento-em-criptomoeda.jpeg",
                        Author="Autor Desconhecido",
                        Addrec=false,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID

                    },

                  
                    new Course
                    {
                        Name="Hábitos Atômicos",
                        Description="Estratégias comprovadas para transformar pequenos hábitos em mudanças significativas na vida.",
                        CoverPhoto= "habitos-atomicos-1.jpeg",
                        Author="James Clear",
                        Addrec=false,
                        Dest=true,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID

                    },
                    new Course
                    {
                        Name="Os Segredos da Mente Milionária",
                        Description="Explora como mudar sua mentalidade para alcançar sucesso financeiro.",
                        CoverPhoto= "livro-Os-Segredos-da-Mente-Milionaria-Harv-Eker.jpeg",
                        Author="T. Harv Eker",
                        Addrec=false,
                        Dest=true,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID  

                    },
                    new Course
                    {
                        Name="Meditações",
                        Description="Reflexões atemporais do imperador romano sobre ética, virtude e o significado da vida.",
                        CoverPhoto= "meditacoes-8.jpeg",
                        Author="Marco Aurélio",
                        Addrec=false,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID

                    },
                    new Course
                    {
                        Name="Multiplique o Seu Dinheiro",
                        Description="Técnicas simples e práticas para gerenciar melhor suas finanças pessoais e aumentar seu patrimônio.",
                        CoverPhoto= "multiplique-o-seu-dinheiro.jpeg",
                        Author="Ariana Nunes",
                        Addrec=false,
                        Dest=true,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID

                    },
                    new Course
                    {
                        Name="O Caminho Simples para a Independência Financeira",
                        Description="Um guia para alcançar liberdade financeira por meio de investimentos inteligentes.",
                        CoverPhoto= "o-caminho-simples-para-a-independencia-financeira.jpeg",
                        Author="J. L. Collins",
                        Addrec=false,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID

                    },
                    new Course
                    {
                        Name="O Cisne Negro",
                        Description="Um estudo sobre a imprevisibilidade e o impacto dos eventos raros e inesperados.",
                        CoverPhoto= "o-cisne-negro.jpeg",
                        Author="Nassim Nicholas Taleb",
                        Addrec=false,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID

                    },
                    new Course
                    {
                        Name="O Homem Mais Rico da Babilônia",
                        Description="Lições de gestão financeira contadas em parábolas baseadas na antiga Babilônia.",
                        CoverPhoto= "o-homem-mais-rico-da-babilonia-10.jpeg",
                        Author="George S. Clason",
                        Addrec=false,
                        Dest=true,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID

                    },
                    new Course
                    {
                        Name="Os Líderes Comem por Último ",
                        Description="Aborda como líderes podem criar ambientes onde as pessoas prosperam e se sentem valorizadas.",
                        CoverPhoto= "os-lideres-comem-por-ultimo.jpeg",
                        Author="Simon Sinek",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Finanças").ID

                    },
                    new Course
                    {
                        Name="A Hipótese do Amor",
                        Description="Uma assistente dedicada descobre um segredo chocante sobre seu chefe. " +
                        "O que começa como uma simples desconfiança logo se transforma" +
                        "'em uma luta por sua própria segurança'.",
                        CoverPhoto= "a-hipotese-do-amor.jpg",
                        Author="Ali Hazelwood",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },
                    new Course
                    {
                        Name="Apartamento Partilha-se",
                        Description="Dois estranhos dividem um apartamento, mas nunca se encontram devido a seus horários opostos. " +
                        "À medida que começam a se comunicar por bilhetes, um vínculo inesperado surge, desafiando suas rotinas.",
                        CoverPhoto="apartamento-partilha-se-1.jpg",
                        Author="Beth O'Leary",
                        Addrec=false,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },

                    new Course
                    {
                        Name="A Sombra de Adeline",
                        Description="Adeline é sequestrada por um homem perigoso e precisa enfrentar seus próprios " +
                        "medos e segredos sombrios enquanto luta para sobreviver em um mundo cheio de suspense e terror psicológico.",
                        CoverPhoto= "a-sombra-de-adeline.jpg",
                        Author="H. D. Carlton",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },

                    new Course
                    {
                        Name="Atrás das Redes",
                        Description="Uma jovem navegando nas redes sociais descobre um amor inesperado que desafia as aparências perfeitas e os julgamentos superficiais da era digital.",
                        CoverPhoto= "atras-das-redes.jpg",
                        Author="Stephanie Archer",
                        Addrec=false,
                        Dest=true,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },
                    new Course
                    {
                        Name="Como Parar o Tempo",
                        Description="Tom Hazard tem uma condição única que o faz viver por séculos. Enquanto tenta levar uma vida normal, ele descobre que o maior risco de sua imortalidade é o amor.",
                        CoverPhoto= "como-parar-o-tempo.jpg",
                        Author="Matt Haig",
                        Addrec=false,
                        Dest=true,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },
                    new Course
                    {
                        Name="Corte de Espinhos e Rosas",
                        Description="Feyre é levada para o reino mágico dos feéricos após matar uma criatura misteriosa. Lá, ela descobre segredos sombrios que podem mudar o destino de todos.",
                        CoverPhoto= "corte-de-espinhos-e-rosas-acotar-1.jpg",
                        Author="Sarah J. Maas",
                        Addrec=false,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },
                    new Course
                    {
                        Name="Culpa Minha",
                        Description="Noah e Nick, que inicialmente se odeiam, precisam lidar com uma" +
                        " atração irresistível enquanto enfrentam diferenças e segredos que podem separá-los para sempre.",
                        CoverPhoto= "culpa-minha-culpados-1.jpg",
                        Author="Mercedes Ron",
                        Addrec=false,
                        Dest=true,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },
                    new Course
                    {
                        Name="Culpa Tua",
                        Description="Noah e Nick enfrentam os desafios de seu relacionamento enquanto lidam com traições e escolhas que podem mudar suas vidas.",
                        CoverPhoto= "culpa-tua-culpados-2.jpg",
                        Author="Mercedes Ron",
                        Addrec=false,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },
                    new Course
                    {
                        Name="Culpa Nossa",
                        Description="Na conclusão da trilogia, Noah e Nick precisam decidir até onde estão dispostos a ir para proteger seu amor, enfrentando seus maiores medos e inimigos.",
                        CoverPhoto= "culpa-nossa-culpados-3.jpg",
                        Author="Mercedes Ron",
                        Addrec=false,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },
                    new Course
                    {
                        Name="Heartstopper - Volume 1",
                        Description="Charlie e Nick, dois colegas de escola, formam uma amizade improvável que rapidamente evolui para algo mais, mostrando a beleza do primeiro amor.",
                        CoverPhoto= "heartstopper-volume-1-3.jpg",
                        Author=" Alice Oseman",
                        Addrec=false,
                        Dest=true,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },
                    new Course
                    {
                        Name="Icebreaker",
                        Description="Uma patinadora artística e um jogador de hóquei têm seus mundos virados de cabeça para baixo quando seus caminhos se cruzam em uma jornada inesperada de amor e autodescoberta.",
                        CoverPhoto= "icebreaker-20.jpg",
                        Author="Hannah Grace",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },
                    new Course
                    {
                        Name="Isto Acaba Aqui",
                        Description="Lily luta para escapar de um relacionamento tóxico e enfrenta decisões difíceis ao reencontrar seu primeiro amor. Uma história poderosa sobre escolhas e superação.",
                        CoverPhoto= "isto-acaba-aqui-1.jpg",
                        Author="Colleen Hoover",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },
                    new Course
                    {
                        Name="Mile High",
                        Description="Lily luta para escapar de um relacionamento tóxico e enfrenta decisões difíceis ao reencontrar seu primeiro amor. Uma história poderosa sobre escolhas e superação.",
                        CoverPhoto= "mile-high-35.jpg",
                        Author="Liz Tomforde",
                        Addrec=true,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },
                    new Course
                    {
                        Name="O Café Pumpkin Spice ",
                        Description="Uma pequena cafeteria se torna o cenário de um romance aconchegante e inesperado, enquanto os personagens aprendem a amar e a curar feridas do passado.",
                        CoverPhoto= "o-cafe-pumpkin-spice.jpg",
                        Author="Laurie Gilmore",
                        Addrec=false,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },
                    new Course
                    {
                        Name="Querida Tia",
                        Description="Uma história emocionante sobre reconciliação familiar, segredos guardados e o poder do amor que pode superar qualquer barreira.",
                        CoverPhoto= "querida-tia.jpg",
                        Author="Valérie Perrin",
                        Addrec=false,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },
                    new Course
                    {
                        Name="Só Nós Dois",
                        Description="Uma história de amor e superação, onde um casal enfrenta os altos e baixos da vida enquanto descobre o que realmente significa ser uma família.",
                        CoverPhoto= "so-nos-dois.jpg",
                        Author="Nicholas Sparks",
                        Addrec=false,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },
                    new Course
                    {
                        Name="Uma Boa História",
                        Description="Dois escritores com abordagens opostas se desafiam a criar histórias baseadas na visão um do outro, e a experiência os aproxima de formas inesperadas.",
                        CoverPhoto= "uma-boa-historia.jpg",
                        Author="Emily Henry",
                        Addrec=false,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },
                    new Course
                    {
                        Name="Verity",
                        Description="Uma autora fantasma descobre segredos sombrios enquanto trabalha nos manuscritos de Verity, uma escritora famosa. O que ela encontra pode mudar sua vida para sempre.",
                        CoverPhoto= "verity-18.jpg",
                        Author="Colleen Hoover",
                        Addrec=false,
                        Dest=false,
                        Quantidade=50,
                        State=true,
                        CategoryID=categories.Single(c => c.Name == "Romance").ID

                    },

                    new Course

                    {
                        Name = "A Bíblia dos Culpados",
                        Description = "Uma obra de humor negro que explora a culpa e ironiza diferentes situações com sátira afiada.",
                        CoverPhoto = "abiliadosculpados.jpg",
                        Author = "Confúcio Costa",
                        Addrec = true,
                        Dest = false,
                        Quantidade = 50,
                        State = true,
                        CategoryID = categories.Single(c => c.Name == "Comédia").ID
                    },

                    new Course
                    {
                        Name = "Manual do Bom Fascista",
                        Description = "Um guia satírico que desmonta os comportamentos autoritários e critica a mentalidade fascista.",
                        CoverPhoto = "manualdobomfascista.jpg",
                        Author = "Rui Zink",
                        Addrec = true,
                        Dest = false,
                        Quantidade = 50,
                        State = true,
                        CategoryID = categories.Single(c => c.Name == "Comédia").ID
                    },

                    new Course
                    {
                        Name = "Mixórdia de Temáticas",
                        Description = "Uma coleção de textos humorísticos baseados nas populares crónicas da Rádio Comercial.",
                        CoverPhoto = "mixordiadetematicas.jpg",
                        Author = "Ricardo Araújo Pereira",
                        Addrec = true,
                        Dest = false,
                        Quantidade = 50,
                        State = true,
                        CategoryID = categories.Single(c => c.Name == "Comédia").ID
                    },

                    new Course
                    {
                        Name = "Novíssimas Crónicas da Boca do Inferno",
                        Description = "Crónicas satíricas que exploram o absurdo da sociedade contemporânea.",
                        CoverPhoto = "novissimascronicasdabocadoinferno.jpg",
                        Author = "Ricardo Araújo Pereira",
                        Addrec = true,
                        Dest = false,
                        Quantidade = 50,
                        State = true,
                        CategoryID = categories.Single(c => c.Name == "Comédia").ID
                    },

                    new Course
                    {
                        Name = "O Piropo Nacional",
                        Description = "Uma antologia de humor com contribuições de diversos autores sobre a cultura portuguesa.",
                        CoverPhoto = "opiroponacional.jpg",
                        Author = "Autores Variados",
                        Addrec = true,
                        Dest = false,
                        Quantidade = 50,
                        State = true,
                        CategoryID = categories.Single(c => c.Name == "Comédia").ID
                    },

                    new Course
                    {
                        Name = "O Meu Coração Só Tem Uma Cor",
                        Description = "Um livro humorístico sobre a paixão clubística e o fanatismo desportivo.",
                        CoverPhoto = "omeucoracaosotemumacor.jpg",
                        Author = "Joana Marques",
                        Addrec = true,
                        Dest = false,
                        Quantidade = 50,
                        State = true,
                        CategoryID = categories.Single(c => c.Name == "Comédia").ID
                    },

                    new Course
                    {
                        Name = "O Lixo na Minha Cabeça",
                        Description = "Histórias cómicas e situações absurdas vistas pelo olhar de uma criança.",
                        CoverPhoto = "olixonaminhacabeca.jpg",
                        Author = "Hugo van der Ding",
                        Addrec = true,
                        Dest = false,
                        Quantidade = 50,
                        State = true,
                        CategoryID = categories.Single(c => c.Name == "Comédia").ID
                    },

                    new Course
                    {
                        Name = "Os Benefícios de Dar Peidos",
                        Description = "Uma abordagem humorística e filosófica sobre os tabus do corpo humano.",
                        CoverPhoto = "osbeneficiosdedarpeidos.jpg",
                        Author = "Jonathan Swift",
                        Addrec = true,
                        Dest = false,
                        Quantidade = 50,
                        State = true,
                        CategoryID = categories.Single(c => c.Name == "Comédia").ID
                    },

                    new Course
                    {
                        Name = "O Diário de um Banana",
                        Description = "O hilariante diário de um pré-adolescente tentando sobreviver ao ensino básico.",
                        CoverPhoto = "diariodeumbanana.jpg",
                        Author = "Jeff Kinney",
                        Addrec = true,
                        Dest = false,
                        Quantidade = 50,
                        State = true,
                        CategoryID = categories.Single(c => c.Name == "Comédia").ID
                    },

                    new Course
                    {
                        Name = "O Estranhão",
                        Description = "Uma divertida história sobre as peculiaridades de uma criança única.",
                        CoverPhoto = "estranhao.jpg",
                        Author = "Álvaro Magalhães",
                        Addrec = true,
                        Dest = false,
                        Quantidade = 50,
                        State = true,
                        CategoryID = categories.Single(c => c.Name == "Comédia").ID
                    },




                    };

            _context.courses.AddRange(courses); // Certifique-se de que está usando "Courses"
            _context.SaveChanges();
        }
    }
}
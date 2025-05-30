using System;
namespace FilmListe
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Films> filmListe = new List<Films>
            {
            };                                      
            bool start = true;

        begining:
            while (start)  //ana döngü
            {
                Console.WriteLine("eklemek istediğiniz film adını ve imdb puanını giriniz");
                Console.WriteLine("film adı");
                string inputName = Console.ReadLine();
                Console.WriteLine("imdb puanı");
                bool Isvalid = double.TryParse(Console.ReadLine(), out double inputRate);  // geçerli olup olmadığını kontrol etme değişken method içinde tanımlandı
                while (!Isvalid)
                {
                    Console.WriteLine("lütfen geçerli bir imdb puanı giriniz");
                    Isvalid = double.TryParse(Console.ReadLine(), out inputRate);
                }
                filmListe.Add(new Films { Name = inputName, Rate = inputRate});
                


            again:
                Console.WriteLine("yeni bir film eklemek istermisiniz ? -evet -hayır ");
                string answer = Console.ReadLine().ToLower();
               
                if (answer != "evet" && answer != "hayır")
                {
                    Console.WriteLine("lütfen belirtilen değer dışında bir değer girmeyin");
                    goto again; // geçerli bir cevap girilene kadar tekrar sorar
                }
                else if (answer == "evet")
                {
                    goto begining; //evet ise tekrar başa döner
                }
                else

                { start = false;
                    break;
                }
                
               
            } 

        bool allFilms = false;
            foreach (var film in filmListe)  //tüm filmleri listeleme
            {
                 if (!allFilms) // tüm filmleri listelemeden önce sadece bir kez yazdırmak için allFilms değişkeni kullanıldı
                {
                    Console.WriteLine("TÜM FİLMLER"); 
                    allFilms = true;
                }

                Console.WriteLine($"Film Adı: {film.Name}, IMDB Puanı: {film.Rate}");
            }
            Console.WriteLine();
            bool midRate = false;    
            foreach (var film in filmListe)  //puanı 4 ile 9 arasında olan filmleri listeleme
            {
              
                if (film.Rate >=4 && film.Rate <=9)
                {
                    if (!midRate)
                    {
                        Console.WriteLine("IMDB puanı 4 ile 9 arasında ki filmler"); //sadece bir kez yazdırmak için midRate değişkeni kullanıldı
                        midRate = true;
                    }

                    Console.WriteLine($"Film: {film.Name} - IMDB: {film.Rate}");
                }
            
            }
            Console.WriteLine();
            bool a = false;  // a harfi ile başlayan filmleri listeleme
            foreach (var film in filmListe) //a harfi ile başlayan filmleri listeleme
            {
                if (film.Name.ToLower().StartsWith("a"))
                {
                    if (!a) // a harfi ile başlayan filmleri listelemeden önce sadece bir kez yazdırmak için a değişkeni kullanıldı
                    {
                        Console.WriteLine("A harfi ile başlayan filmler"); 
                        a = true;
                    }
                    Console.WriteLine($"Film: {film.Name} - IMDB: {film.Rate}");
                }
            }



        }
    }
}
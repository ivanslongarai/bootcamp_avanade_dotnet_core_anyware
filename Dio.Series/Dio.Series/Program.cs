using Dio.Series.Classes;
using Dio.Series.Enums;
using System;

namespace Dio.Series
{
    class Program
    {
        static SerieRepository serieRepository = new SerieRepository();
        static MovieRepository movieRepository = new MovieRepository();

        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption != "X")
            {
                switch (userOption)
                {
                    case "0": { ListSeries(); break; }
                    case "1": { InsertOrUpdateSerie('i'); break; }
                    case "2": { InsertOrUpdateSerie('u'); break; }
                    case "3": { DeleteSerie(); break; }
                    case "4": { ViewSerie(); break; }
                    case "5": { ListMovies(); break; }
                    case "6": { InsertOrUpdateMovie('i'); break; }
                    case "7": { InsertOrUpdateMovie('u'); break; }
                    case "8": { DeleteMovie(); break; }
                    case "9": { ViewMovie(); break; }
                    case "C": { Console.Clear(); break; }
                    default : throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }
        }

        private static void DeleteSerie()
        {
            Console.Write("Digite o id da série: ");
            int serieId = int.Parse(Console.ReadLine());
            serieRepository.Delete(serieId);
        }

        private static void ViewSerie()
        {
            Console.Write("Digite o id da série: ");
            var serieId = int.Parse(Console.ReadLine());
            Console.WriteLine(serieRepository.GetById(serieId));
        }

        private static void InsertOrUpdateSerie(char type)
        {

            var varId = 0;

            if (type == 'i')
            {
                Console.WriteLine("Inserir nova série");
                varId = serieRepository.GetNextId();
            }
            else
            if (type == 'u')
            {
                Console.WriteLine("Atualizar série");
                Console.Write("Digite o id da série: ");
                varId = int.Parse(Console.ReadLine());
            }

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int inputGender = int.Parse(Console.ReadLine());

            while ((inputGender < 1) || (inputGender > 12))
            {
                Console.Write("Digite o genêro entre as opções acima: ");
                inputGender = int.Parse(Console.ReadLine());
            }

            Console.Write("Digite o título da série: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string inputDescription = Console.ReadLine();

            Serie objSerie = new Serie(
                id: varId,
                gender: (Gender)inputGender,
                title: inputTitle,
                description: inputDescription,
                year: inputYear
             );

            if (type == 'i')
            {
                serieRepository.Insert(objSerie);
            }
            else
            if (type == 'u')
            {
                serieRepository.Update(varId, objSerie);
            }
        }

        private static void ListSeries()
        {
            Console.WriteLine("Listar séries");
            var list = serieRepository.List();
            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach (var serie in list)
            {
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.getId(), serie.getTitle(), serie.isDeleted() ? "Excluído" : "Ativo");
            }
        }

        // Starting with Movies here

        private static void DeleteMovie()
        {
            Console.Write("Digite o id da filme: ");
            int movieId = int.Parse(Console.ReadLine());
            movieRepository.Delete(movieId);
        }

        private static void ViewMovie()
        {
            Console.Write("Digite o id da filme: ");
            var movieId = int.Parse(Console.ReadLine());
            Console.WriteLine(movieRepository.GetById(movieId));
        }

        private static void InsertOrUpdateMovie(char type)
        {

            var varId = 0;

            if (type == 'i')
            {
                Console.WriteLine("Inserir novo filme");
                varId = movieRepository.GetNextId();
            }
            else
            if (type == 'u')
            {
                Console.WriteLine("Atualizar filme");
                Console.Write("Digite o id do filme: ");
                varId = int.Parse(Console.ReadLine());
            }

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int inputGender = int.Parse(Console.ReadLine());

            while ((inputGender < 1) || (inputGender > 12)) {
                Console.Write("Digite o genêro entre as opções acima: ");
                inputGender = int.Parse(Console.ReadLine());
            } 

            Console.Write("Digite o título do filme: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Digite o ano de lançamento do filme: ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do filme: ");
            string inputDescription = Console.ReadLine();

            Console.Write("Digite a duração do filme em minutos: ");
            int inputTimeDurationMinutes = int.Parse(Console.ReadLine());

            Movie objFilme = new Movie(
                id: varId,
                gender: (Gender)inputGender,
                title: inputTitle,
                description: inputDescription,
                year: inputYear,
                timeDurationMinutes: inputTimeDurationMinutes

             );

            if (type == 'i')
            {
                movieRepository.Insert(objFilme);
            }
            else
            if (type == 'u')
            {
                movieRepository.Update(varId, objFilme);
            }
        }

        private static void ListMovies()
        {
            Console.WriteLine("Listar filmes");
            var list = movieRepository.List();
            if (list.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado");
                return;
            }
            foreach (var movie in list)
            {
                Console.WriteLine("#ID {0}: - {1} - {2}", movie.getId(), movie.getTitle(), movie.isDeleted() ? "Excluído" : "Ativo");
            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries ao seu dispor!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("0 - Listar Séries");
            Console.WriteLine("1 - Inserir nova série");
            Console.WriteLine("2 - Atualizar série");
            Console.WriteLine("3 - Excluir série");
            Console.WriteLine("4 - Visualizar série");
            Console.WriteLine("5 - Listar filmes");
            Console.WriteLine("6 - Inserir novo filme");
            Console.WriteLine("7 - Atualizar filme");
            Console.WriteLine("8 - Excluir filme");
            Console.WriteLine("9 - Visualizar filme");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string sOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return sOption;
        }
    }
}

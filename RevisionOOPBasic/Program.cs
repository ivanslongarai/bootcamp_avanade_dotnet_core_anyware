using System;

namespace RevisionOOPBasic
{
    class Program
    {
        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string sOption = Console.ReadLine();
            return sOption;
        }

        static void Main(string[] args)
        {
            string sUserOption = GetUserOption();
            Student[] students = new Student[5];
            var indexStudent = 0;

            while (sUserOption.ToUpper() != "X")
            {
                switch (sUserOption)
                {
                    case "1":
                        {

                            if (!string.IsNullOrEmpty(students[4].Name))
                            {
                                Console.WriteLine("Os 5 alunos já foram informados");
                                break;
                            }
                            else
                            {

                                Console.WriteLine("Informe o nome do aluno:");
                                Student student = new Student();
                                student.Name = Console.ReadLine();
                                Console.WriteLine("Informe a nota do aluno:");
                                if (decimal.TryParse(Console.ReadLine(), out decimal grade))
                                {
                                    student.Grade = grade;
                                }
                                else
                                {
                                    throw new ArgumentException("Valor inválido para a nota do aluno");
                                }
                                students[indexStudent] = student;
                                Console.WriteLine($"Adicionado aluno, nome: {students[indexStudent].Name}, nota {students[indexStudent].Grade}");
                                indexStudent++;
                                break;
                            }
                            
                        }
                    case "2":
                        {
                            foreach (var studentFor in students)
                            {
                                if (!string.IsNullOrEmpty(studentFor.Name))
                                    Console.WriteLine($"Aluno: {studentFor.Name} Nota: {studentFor.Grade} ");
                            }
                            break;
                        }
                    case "3":
                        {
                            decimal dTotalGrades = 0;
                            int iTotalStudents = 0;
                            foreach (var studentFor in students)
                            {
                                if (!string.IsNullOrEmpty(studentFor.Name))
                                {
                                    iTotalStudents++;
                                    dTotalGrades += studentFor.Grade;
                                }
                            }
                            var generalAverage = dTotalGrades / iTotalStudents;

                            Concept generalConcept;
                            if (generalAverage < 2)
                            {
                                generalConcept = Concept.E;
                            }
                            else
                            if (generalAverage < 4)
                            {
                                generalConcept = Concept.D;
                            }
                            else
                            if (generalAverage < 6)
                            {
                                generalConcept = Concept.C;
                            }
                            else
                            if (generalAverage < 8)
                            {
                                generalConcept = Concept.B;
                            }
                            else
                            {
                                generalConcept = Concept.A;
                            }

                            Console.WriteLine($"Média Geral: {generalAverage}, Conceito Geral: {generalConcept} ");
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                sUserOption = GetUserOption();
            }

            Console.WriteLine();
            Console.WriteLine("Application finished...");
            Console.WriteLine();

        }
    }
}

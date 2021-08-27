using Dio.Series.Enums;
using System;

namespace Dio.Series.Classes
{
    public class Movie : EntityBase
    {
        private Gender Gender { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private int TimeDurationMinutes { get; set; }
        private bool Deleted { get; set; }

        public Movie(int id, Gender gender, string title, string description, int year, int timeDurationMinutes)
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
            this.TimeDurationMinutes = timeDurationMinutes;
        }

        public override string ToString()
        {
            string result = "";
            result += "Gênero: " + this.Gender + Environment.NewLine;
            result += "Título: " + this.Title + Environment.NewLine;
            result += "Descrição: " + this.Description + Environment.NewLine;
            result += "Ano lançamento: " + this.Year + Environment.NewLine;
            result += "Tempo de duração em minutos: " + this.TimeDurationMinutes + Environment.NewLine;
            result += "Excluído: " + (this.Deleted ? "Sim" :"Não");
            return result;
        }

        public string getTitle()
        {
            return this.Title;
        }

        public int getId()
        {
            return this.Id;
        }

        public void setDeleted()
        {
            this.Deleted = true;
        }

        public bool isDeleted()
        {
            return this.Deleted == true;
        }

    }
}

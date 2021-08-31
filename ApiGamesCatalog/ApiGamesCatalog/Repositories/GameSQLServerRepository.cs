﻿using ApiGamesCatalog.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ApiGamesCatalog.Repositories
{
    public class GameSQLServerRepository : IGameRepository
    {
        private readonly SqlConnection sqlConnection;

        public GameSQLServerRepository(IConfiguration configuration)
        {
            //var justForDebbuging = configuration.GetConnectionString("Default");
            sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public async Task<List<Game>> Get(int page, int amount)
        {
            var games = new List<Game>();

            var command = $"select * from Games order by id offset {((page - 1) * amount)} rows fetch next {amount} rows only";

            await sqlConnection.OpenAsync();

            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                games.Add(new Game 
                {
                    Id = (Guid)(sqlDataReader["Id"]),
                    Name = (string)(sqlDataReader["Name"]),
                    Producer = (string)(sqlDataReader["Producer"]),
                    Price = (decimal)(sqlDataReader["Price"])
                });
            }

            await sqlConnection.CloseAsync();

            return games;

        }

        public async Task<Game> Get(Guid id)
        {
            Game game = null;

            var command = $"select * from Games where id = '{id}'";

            await sqlConnection.OpenAsync();

            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                game = new Game
                {
                    Id = (Guid)(sqlDataReader["Id"]),
                    Name = (string)(sqlDataReader["Name"]),
                    Producer = (string)(sqlDataReader["Producer"]),
                    Price = (decimal)(sqlDataReader["Price"])
                };
            }

            await sqlConnection.CloseAsync();

            return game;


        }

        public async Task<List<Game>> Get(string name, string producer)
        {
            var games = new List<Game>();

            var command = $"select * from Games where Name = '{name}' and Producer = '{producer}'";

            await sqlConnection.OpenAsync();

            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                games.Add(new Game
                {
                    Id = (Guid)(sqlDataReader["Id"]),
                    Name = (string)(sqlDataReader["Name"]),
                    Producer = (string)(sqlDataReader["Producer"]),
                    Price = (decimal)(sqlDataReader["Price"])
                });
            }

            await sqlConnection.CloseAsync();

            return games;

        }

        public async Task InsertGame(Game game)
        {
            var command = 
               $"insert into Games (Id, Name, Producer, Price) values ('{game.Id}', '{game.Name}', '" +
               $"{game.Producer}', '{game.Price.ToString().Replace(",", ".")}')";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();

        }

        public async Task UpdateGame(Game game)
        {
            var command =
              $"update Games set Name = '{game.Name}', Producer = '{game.Producer}', " +
              $"Price = '{game.Price.ToString().Replace(",", ".")}' where Id = '{game.Id}'";
             
            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task DeleteGame(Guid id)
        {
            var command = $"delete from Games where id = {id}";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public void Dispose()
        {
            sqlConnection?.Close();
            sqlConnection?.Dispose();
        }
    }
}

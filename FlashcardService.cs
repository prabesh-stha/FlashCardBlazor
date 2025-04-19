using System.Data;
using Dapper;
using FlashCardBlazor.Data;
using Microsoft.Data.SqlClient;

namespace FlashCardBlazor
{
    public class FlashcardService
    {
        private readonly IConfiguration _configuration;

        public FlashcardService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection()
        {
            return new SqlConnection(_configuration.GetConnectionString("Connection"));
        }

        public async Task AddFlashcard(FlashcardModel flashcard)
        {
            using var connection = Connection();
            var parameters = new DynamicParameters();
            parameters.Add("@Question", flashcard.Question);
            parameters.Add("@Answer", flashcard.Answer);
            await connection.ExecuteAsync("AddFlashcard", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<FlashcardModel>> GetAllFlashCard()
        {
            using var connection = Connection();
            var result = await connection.QueryAsync<FlashcardModel>("GetAllFlashcard", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<FlashcardModel?> GetFlashCardById(int Id)
        {
            using var connection = Connection();
            var parameter = new DynamicParameters();
            parameter.Add("@Id", Id);
            var result = await connection.QueryFirstOrDefaultAsync<FlashcardModel>("GetFlashcard", parameter, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task EditFlashcard(FlashcardModel flashcard)
        {
            using var connection = Connection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", flashcard.Id);
            parameters.Add("@Question", flashcard.Question);
            parameters.Add("@Answer", flashcard.Answer);

            await connection.ExecuteAsync("UpdateFlashcard", parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task DeleteFlashcard(int Id)
        {
            using var connection = Connection();
            var parameter = new DynamicParameters();
            parameter.Add("@Id", Id);
            await connection.ExecuteAsync("DeleteFlashcard", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}

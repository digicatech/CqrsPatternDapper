using Dapper;
using DomainLayer;
using MediatR;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ApplicationLayer.Queries.Categories
{
    public class GetAllCategoriesQuery: IRequest<IList<Category>>
    {

       
        public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IList<Category>>
        {
            private readonly IConfiguration _configuration;
            public GetAllCategoriesQueryHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task<IList<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                var sql = "SELECT * FROM demo.category";
                using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<Category>(sql);
                    return result.ToList();
                }

            }
        }
    }
}

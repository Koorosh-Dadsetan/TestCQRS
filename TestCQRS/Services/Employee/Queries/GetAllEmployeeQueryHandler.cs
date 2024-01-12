using MediatR;
using Microsoft.EntityFrameworkCore;
using TestCQRS.Data.Context;
using TestCQRS.DTO.Queries;

namespace TestCQRS.Services.Employee.Queries
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<Data.Models.Employee>>
    {
        private readonly TestDbContext _context;
        public GetAllEmployeeQueryHandler(TestDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Data.Models.Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var personList = await _context.Employees.AsNoTracking().ToListAsync(cancellationToken);
            return personList.AsReadOnly();
        }
    }
}

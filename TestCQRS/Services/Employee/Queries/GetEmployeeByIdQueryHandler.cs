using MediatR;
using Microsoft.EntityFrameworkCore;
using TestCQRS.Data.Context;
using TestCQRS.DTO.Queries;

namespace TestCQRS.Services.Employee.Queries
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Data.Models.Employee>
    {
        private readonly TestDbContext _context;
        public GetEmployeeByIdQueryHandler(TestDbContext context)
        {
            _context = context;
        }
        public async Task<Data.Models.Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = _context.Employees.AsNoTracking().Where(a => a.Id == request.Id).FirstOrDefault();
            return employee;
        }
    }
}

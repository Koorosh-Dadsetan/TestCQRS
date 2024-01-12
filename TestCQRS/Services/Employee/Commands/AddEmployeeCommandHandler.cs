using MediatR;
using TestCQRS.Data.Context;
using TestCQRS.DTO.Commands;

namespace TestCQRS.Services.Employee.Commands
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, int>
    {
        private readonly TestDbContext _context;
        public AddEmployeeCommandHandler(TestDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            Data.Models.Employee employee = new()
            {
                FullName = request.FullName,
                Mobile = request.Mobile,
                Age = request.Age,
                Address = request.Address
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }
    }
}

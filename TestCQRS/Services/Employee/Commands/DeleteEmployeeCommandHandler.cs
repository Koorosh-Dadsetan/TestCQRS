using MediatR;
using TestCQRS.Data.Context;
using TestCQRS.DTO.Commands;

namespace TestCQRS.Services.Employee.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly TestDbContext _context;
        public DeleteEmployeeCommandHandler(TestDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _context.Employees.Where(c => c.Id == request.Id).FirstOrDefault();
            if (employee == null) return default;
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }
    }
}

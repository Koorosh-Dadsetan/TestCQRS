using MediatR;
using TestCQRS.Data.Context;
using TestCQRS.DTO.Commands;

namespace TestCQRS.Services.Employee.Commands
{
    public class EditEmployeeCommandHandler : IRequestHandler<EditEmployeeCommand, int>
    {
        private readonly TestDbContext _context;
        public EditEmployeeCommandHandler(TestDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _context.Employees.Where(a => a.Id == request.Id).FirstOrDefault();
            if (employee == null)
            {
                return default;
            }
            else
            {
                employee.FullName = request.FullName;
                employee.Mobile = request.Mobile;
                employee.Age = request.Age;
                employee.Address = request.Address;
                await _context.SaveChangesAsync();
                return employee.Id;
            }
        }
    }
}

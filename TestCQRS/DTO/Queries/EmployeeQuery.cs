using MediatR;
using TestCQRS.Data.Models;

namespace TestCQRS.DTO.Queries
{
    public class GetAllEmployeeQuery : IRequest<IEnumerable<Employee>>
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;
    }

    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;
    }
}

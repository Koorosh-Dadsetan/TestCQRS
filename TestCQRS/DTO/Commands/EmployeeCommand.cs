using MediatR;

namespace TestCQRS.DTO.Commands
{
    public class AddEmployeeCommand : IRequest<int>
    {
        public string FullName { get; set; } = null!;

        public string? Mobile { get; set; }

        public int? Age { get; set; }

        public string? Address { get; set; }
    }

    public class EditEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public string? Mobile { get; set; }

        public int? Age { get; set; }

        public string? Address { get; set; }
    }

    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

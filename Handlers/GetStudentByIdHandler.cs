using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Queries;
using CQRSAndMediatRDemo.Repositories.Interfaces;
using MediatR;


#pragma warning disable CS8603 // Possible null reference return.
namespace CQRSAndMediatRDemo.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDetails> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudentByIdAsync(query.Id);
        }
    }
}

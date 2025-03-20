using AutoMapper;
using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Features.InternshipApplication.Requests.Commands;
using EmployeeMS.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.InternshipApplication.Handlers.Commands
{
    public class DeleteInternshipApplicationCommandHandler : IRequestHandler<DeleteInternshipApplicationCommand>
    {
        private readonly IInternshipApplicationRepository _internshipApplicationRepository;
        private readonly IMapper _mapper;

        public DeleteInternshipApplicationCommandHandler(IInternshipApplicationRepository internshipApplicationRepository, IMapper mapper)
        {
            _internshipApplicationRepository = internshipApplicationRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteInternshipApplicationCommand request, CancellationToken cancellationToken)
        {
            var internshipApp = await _internshipApplicationRepository.GetByIdAsync(request.Id);

            if (internshipApp == null)
                throw new Exception();

            await _internshipApplicationRepository.DeleteAsync(internshipApp);

            return Unit.Value;
        }
    }
}

using AutoMapper;
using ClinicManager.Domain.Interfaces;
using MediatR;

namespace ClinicManager.Application.Patients.Commands.UpdatePatient
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, Unit>
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePatientHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePatientCommand cmd, CancellationToken ct)
        {
            var patient = await _repository.GetByIdAsync(cmd.Id);
            if (patient is null)
                throw new Exception($"Patient with id {cmd.Id} not found.");

            _mapper.Map(cmd, patient);

            await _repository.UpdateAsync(patient, ct);

            return Unit.Value;
        }
    }
}

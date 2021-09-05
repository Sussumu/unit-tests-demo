using Demo.Domain.DTOs;
using Demo.Domain.Interfaces;
using System;

namespace Demo.Domain.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IClinicRepository _clinicRepository;

        public AppointmentService(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository ?? throw new ArgumentNullException(nameof(clinicRepository));
        }

        public bool Schedule(ScheduleRequest request)
        {
            if (request.Cpf.Length != 11)
                return false;

            if (_clinicRepository.IsOpenAt(request.Date) is false)
                return false;

            return _clinicRepository.Schedule(request.Cpf, request.Date);
        }
    }
}

using Demo.Domain.DTOs;
using Demo.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Demo.Domain.Services
{
    public class AppointmentService : IAppointmentService
    {
        public IClinicRepository ClinicRepository { get; }
        public ILogger<AppointmentService> Logger;

        public AppointmentService(
            IClinicRepository clinicRepository,
            ILogger<AppointmentService> logger)
        {
            ClinicRepository = clinicRepository
                ?? throw new ArgumentNullException(nameof(clinicRepository));
            Logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool Schedule(ScheduleRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Cpf)
                || request.Cpf.Length != 11)
                return false;

            if (ClinicRepository.IsOpenAt(request.Date) is false)
                return false;

            return ClinicRepository.Schedule(request.Cpf, request.Date);
        }
    }
}

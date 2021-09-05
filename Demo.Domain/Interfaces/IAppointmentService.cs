using Demo.Domain.DTOs;

namespace Demo.Domain.Interfaces
{
    public interface IAppointmentService
    {
        bool Schedule(ScheduleRequest request);
    }
}

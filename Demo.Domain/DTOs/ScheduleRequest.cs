using System;

namespace Demo.Domain.DTOs
{
    public class ScheduleRequest
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}

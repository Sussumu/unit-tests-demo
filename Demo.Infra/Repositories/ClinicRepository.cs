using Demo.Domain.Interfaces;
using System;

namespace Demo.Infra.Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        public bool IsOpenAt(DateTime date)
        {
            return date.Hour > 8
                && date.Hour < 18;
        }

        public bool Schedule(string cpf, DateTime date)
        {
            return true;
        }
    }
}

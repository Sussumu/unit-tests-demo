using System;

namespace Demo.Domain.Interfaces
{
    public interface IClinicRepository
    {
        bool Schedule(string cpf, DateTime date);
        bool IsOpenAt(DateTime date);
    }
}

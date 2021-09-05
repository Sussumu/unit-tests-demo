using AutoFixture;
using Demo.Domain.DTOs;
using System;

namespace Demo.Api.UnitTests.Customizations
{
    public class ScheduleRequestCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<ScheduleRequest>(composer =>
                composer.With(x => x.Cpf, GenerateCpf()));
        }

        private static string GenerateCpf()
        {
            var sum = 0;
            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var rnd = new Random();
            var seed = rnd.Next(100000000, 999999999).ToString();

            for (var i = 0; i < 9; i++)
                sum += int.Parse(seed[i].ToString()) * multiplier1[i];

            var remainder = sum % 11;
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            seed += remainder;
            sum = 0;

            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            for (var i = 0; i < 10; i++)
                sum += int.Parse(seed[i].ToString()) * multiplier2[i];

            remainder = sum % 11;

            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;

            seed += remainder;
            return seed;
        }
    }
}

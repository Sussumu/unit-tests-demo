using Demo.Api.UnitTests.Attributes;
using Demo.Domain.DTOs;
using Demo.Domain.Services;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using Xunit;

namespace Demo.Api.UnitTests
{
    public class AppointmentServiceTests
    {
        [Theory]
        [InlineAutoNSubstituteData(null)]
        [InlineAutoNSubstituteData("")]
        [InlineAutoNSubstituteData(" ")]
        public void Schedule_WhenCpfIsIncorrect_ReturnFalse(
            string modifiedCpf,
            AppointmentService sut,
            ScheduleRequest request)
        {
            request.Cpf = modifiedCpf;

            var result = sut.Schedule(request);

            result.Should().BeFalse();
        }

        [Theory]
        [AutoNSubstituteData]
        public void Schedule_WhenDateIsInvalid_ReturnFalse(
            AppointmentService sut,
            ScheduleRequest request)
        {
            sut.ClinicRepository.IsOpenAt(Arg.Any<DateTime>()).Returns(false);

            var result = sut.Schedule(request);

            result.Should().BeFalse();
            sut.ClinicRepository.Received(1).IsOpenAt(request.Date);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Schedule_WhenScheduleFails_ReturnFalse(
            AppointmentService sut,
            ScheduleRequest request)
        {
            sut.ClinicRepository.IsOpenAt(Arg.Any<DateTime>()).Returns(true);
            sut.ClinicRepository
                .Schedule(Arg.Any<string>(), Arg.Any<DateTime>())
                .Returns(false);

            var result = sut.Schedule(request);

            result.Should().BeFalse();
            sut.ClinicRepository.Received(1).IsOpenAt(request.Date);
            sut.ClinicRepository.Received(1).Schedule(request.Cpf, request.Date);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Schedule_WhenScheduleThrowsException_ReturnFalse(
            AppointmentService sut,
            ScheduleRequest request,
            Exception ex)
        {
            sut.ClinicRepository.IsOpenAt(Arg.Any<DateTime>()).Returns(true);
            sut.ClinicRepository
                .Schedule(Arg.Any<string>(), Arg.Any<DateTime>())
                .Throws(ex);

            Action act = () => sut.Schedule(request);
            act.Should().Throw<Exception>().WithMessage(ex.Message);

            sut.ClinicRepository.Received(1).IsOpenAt(request.Date);
            sut.ClinicRepository.Received(1).Schedule(request.Cpf, request.Date);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Schedule_WhenScheduleSucceeds_ReturnTrue(
            AppointmentService sut,
            ScheduleRequest request)
        {
            sut.ClinicRepository.IsOpenAt(Arg.Any<DateTime>()).Returns(true);
            sut.ClinicRepository
                .Schedule(Arg.Any<string>(), Arg.Any<DateTime>())
                .Returns(true);

            var result = sut.Schedule(request);

            result.Should().BeTrue();
            sut.ClinicRepository.Received(1).IsOpenAt(request.Date);
            sut.ClinicRepository.Received(1).Schedule(request.Cpf, request.Date);
        }
    }
}

using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Queries
{
    public class CreateleaveTypeCommandTests
    {
        private Mock<ILeaveTypeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<CreateLeaveTypeCommandHandler>> _mockAppLogger;

        public CreateleaveTypeCommandTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            });


            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<CreateLeaveTypeCommandHandler>>();
        }

        [Fact]
        public async Task Handle_ValidLeaveType()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            await handler.Handle(new CreateLeaveTypeCommand()
            {
                Name = "Test1",
                DefaultDays = 1
            }, CancellationToken.None);

            var leaveTypes = await _mockRepo.Object.GetAsync();
            leaveTypes.Count.ShouldBe(MockLeaveTypeRepository.MockLeaveTypeRows + 1);
        }
    }
}

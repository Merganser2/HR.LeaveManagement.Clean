using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public class MockLeaveTypeRepository
    {
        public static int MockLeaveTypeRows {get; set;}

        public static Mock<ILeaveTypeRepository> GetMockLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType { Id = 1, Name = "Test AdHoc", DefaultDays=2 },
                new LeaveType { Id = 1, Name = "Test Sick", DefaultDays=6 },
                new LeaveType { Id = 1, Name = "Test Vacation", DefaultDays=15 },
                new LeaveType { Id = 1, Name = "Test LOA", DefaultDays=180 },
                new LeaveType { Id = 1, Name = "Bogus", DefaultDays=1 }
            };

            MockLeaveTypeRows = leaveTypes.Count;

            var mockRepo = new Mock<ILeaveTypeRepository>();

            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(leaveTypes);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveType>()))
                .Returns((LeaveType leaveType) =>
                {
                    leaveTypes.Add(leaveType);
                    return Task.CompletedTask;
                });

            mockRepo.Setup(r => r.IsLeaveTypeUnique(It.IsAny<string>()))
                .ReturnsAsync((string name) => {
                    return !leaveTypes.Any(q => q.Name == name);
                });

            return mockRepo;
        }
    }
}

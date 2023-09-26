using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<DeleteLeaveTypeCommandHandler> _logger;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, 
                                            IAppLogger<DeleteLeaveTypeCommandHandler> logger)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Retrieve domain entity object
            var leaveTypeToRemove = await _leaveTypeRepository.GetByIdAsync(request.Id);

            // Verify that record exists
            if (leaveTypeToRemove == null)
            {
                // String interpolation not best practice for logging; provide parameters like so
                _logger.LogWarning("Attempt to delete null record of {0}, Id {1}", nameof(LeaveType), request.Id);

                throw new NotFoundException(nameof(leaveTypeToRemove), request.Id);
            }

            // Remove from database
            await _leaveTypeRepository.DeleteAsync(leaveTypeToRemove);

            // Return record Id ???? (thought it was nothing?)
            return Unit.Value;
        }
    }
}

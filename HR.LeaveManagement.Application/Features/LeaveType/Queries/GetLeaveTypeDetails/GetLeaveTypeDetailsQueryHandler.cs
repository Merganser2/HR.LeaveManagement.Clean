using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        // Query database
        var leaveTypeDetails = await _leaveTypeRepository.GetByIdAsync(request.Id);

        // verify that record exists
        if (leaveTypeDetails == null)
            throw new NotFoundException(nameof(LeaveType), request.Id);

        // convert data object to DTO object
        var leaveTypeDetailsDto = _mapper.Map<LeaveTypeDetailsDto>(leaveTypeDetails);

        return leaveTypeDetailsDto;
    }
}

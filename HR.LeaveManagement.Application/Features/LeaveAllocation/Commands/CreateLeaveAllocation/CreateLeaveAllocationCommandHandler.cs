﻿using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationCommandHandler(IMapper mapper,
            ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            this._leaveAllocationRepository = leaveAllocationRepository;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Leave Allocation Request", validationResult);

            // Get Leave type for allocations
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

            // Get Employees
            // TODO: Complete after getting Employee info set up
            var employees = new List<string>();

            // Get Period
            var period = DateTime.Now.Year;

            //Assign Allocations IF an allocation doesn't already exist for period and leave type
            var allocations = new List<Domain.LeaveAllocation>();
            // TODO: Complete after getting Employee info set up
            foreach (var emp in employees)
            {
                var allocationExists = true; // await _leaveAllocationRepository.AllocationExists(emp.Id, request.LeaveTypeId, period);

                if (allocationExists == false)
                {
                    allocations.Add(new Domain.LeaveAllocation
                    {
                        EmployeeId = "TODO", // emp.Id,
                        LeaveTypeId = leaveType.Id,
                        NumberOfDays = leaveType.DefaultDays,
                        Period = period,
                    });
                }
            }

            if (allocations.Any())
            {
                await _leaveAllocationRepository.AddAllocations(allocations);
            }

            //var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request); // Get Domain object from request?
            //await _leaveAllocationRepository.CreateAsync(leaveAllocation);

            return Unit.Value;
        }
    }
}
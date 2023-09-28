using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)

    {
        RuleFor(p => p.Id)
           .NotNull()
           .MustAsync(LeaveTypeMustExist);

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

        RuleFor(p => p.DefaultDays)
            .LessThan(181).WithMessage("{PropertyName} cannot exceed 180") 
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero (0)"); 
        
        this._leaveTypeRepository = leaveTypeRepository;

    }

    private async Task<bool> LeaveTypeMustExist(int id, CancellationToken arg2)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
        return leaveType != null;
    }
}


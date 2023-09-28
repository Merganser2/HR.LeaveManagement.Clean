using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            return await _context.LeaveRequests.Include(l => l.LeaveType)
                                               .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            return await _context.LeaveRequests.Include(l => l.LeaveType)
                                               .ToListAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
        {
            return await _context.LeaveRequests.Where(q => q.RequestingEmployeeId == userId)
                                               .Include(l => l.LeaveType)                                         
                                               .ToListAsync();
        }
    }

}

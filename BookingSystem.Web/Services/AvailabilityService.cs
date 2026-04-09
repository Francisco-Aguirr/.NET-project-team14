using BookingSystem.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Web.Services
{
    public class AvailabilityService
    {
        private static readonly TimeSpan SlotStep = TimeSpan.FromMinutes(30);
        private readonly ApplicationDbContext _dbContext;

        public AvailabilityService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AvailabilitySlot>> GetAvailableSlotsAsync(int serviceId, DateTime date)
        {
            var selectedDate = date.Date;

            var service = await _dbContext.BusinessServices
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == serviceId && s.IsActive);

            if (service == null)
            {
                return new List<AvailabilitySlot>();
            }

            var employees = await _dbContext.Employees
                .AsNoTracking()
                .Where(e => e.BusinessId == service.BusinessId)
                .ToListAsync();

            if (employees.Count == 0)
            {
                return new List<AvailabilitySlot>();
            }

            var employeeIds = employees.Select(e => e.Id).ToList();
            var dayOfWeek = selectedDate.DayOfWeek;
            var serviceDuration = TimeSpan.FromMinutes(service.DurationMinutes);

            var schedules = await _dbContext.WorkSchedules
                .AsNoTracking()
                .Where(ws => employeeIds.Contains(ws.EmployeeId) && ws.DayOfWeek == dayOfWeek)
                .ToListAsync();

            if (schedules.Count == 0)
            {
                return new List<AvailabilitySlot>();
            }

            var dayStart = selectedDate;
            var dayEnd = selectedDate.AddDays(1);

            var appointments = await _dbContext.Set<Appointment>()
                .AsNoTracking()
                .Where(a => employeeIds.Contains(a.EmployeeId)
                            && !a.IsCancelled
                            && a.AppointmentStart < dayEnd
                            && a.AppointmentEnd > dayStart)
                .ToListAsync();

            var availability = new List<AvailabilitySlot>();

            foreach (var schedule in schedules)
            {
                var scheduleStart = selectedDate.Add(schedule.StartTime);
                var scheduleEnd = selectedDate.Add(schedule.EndTime);

                for (var candidateStart = scheduleStart;
                    candidateStart + serviceDuration <= scheduleEnd;
                    candidateStart += SlotStep)
                {
                    var candidateEnd = candidateStart + serviceDuration;

                    var hasOverlap = appointments.Any(a => a.EmployeeId == schedule.EmployeeId
                                                        && candidateStart < a.AppointmentEnd
                                                        && candidateEnd > a.AppointmentStart);

                    if (!hasOverlap)
                    {
                        availability.Add(new AvailabilitySlot(candidateStart, candidateEnd, schedule.EmployeeId));
                    }
                }
            }

            return availability
                .GroupBy(slot => slot.Start)
                .Select(group => group.OrderBy(s => s.EmployeeId).First())
                .OrderBy(slot => slot.Start)
                .ToList();
        }
    }

    public record AvailabilitySlot(DateTime Start, DateTime End, int EmployeeId);
}

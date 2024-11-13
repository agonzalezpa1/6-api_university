using ApiUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiUniversity.Controllers;

[ApiController]
[Route("api/enrollment")]
public class EnrollmentController : ControllerBase
{
    private readonly ApiUniversityContext _context;

    public EnrollmentController(ApiUniversityContext context)
    {
        _context = context;
    }

    // GET: api/course
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DetailedEnrollmentDTO>>> GetEnrollments()
    {
        // Get courses and related lists
        var enrollments = _context.Enrollments.Include(x => x.Course).Include(x => x.Student).Select(x => new DetailedEnrollmentDTO(x));
        // _context.Entity1.Include(x => x.Entity2).Include(x => x.Entity3)

        return await enrollments.ToListAsync();
    }

    // GET: api/enrollment/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DetailedEnrollmentDTO>> GetEnrollment(int id)
    {
        // Find course and related list
        // SingleAsync() throws an exception if no course is found (which is possible, depending on id)
        // SingleOrDefaultAsync() is a safer choice here
        var enrollment = await _context.Enrollments.Include(x => x.Course).Include(x => x.Student).SingleOrDefaultAsync(e => e.Id == id);

        if (enrollment == null)
        {
            return NotFound();
        }

        return new DetailedEnrollmentDTO(enrollment);
    }

    // POST: api/course
    [HttpPost] 
    public async Task<ActionResult<DetailedEnrollmentDTO>> PostEnrollment(EnrollmentDTO enrollmentDTO)
    {
        Enrollment enrollment = new(enrollmentDTO);

        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        enrollment.Course = await _context.Courses.FirstAsync(c => c.Id == enrollmentDTO.CourseId);
        enrollment.Student = await _context.Students.FirstAsync(s => s.Id == enrollmentDTO.StudentId);

        return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.Id }, new DetailedEnrollmentDTO(enrollment));
    }
}
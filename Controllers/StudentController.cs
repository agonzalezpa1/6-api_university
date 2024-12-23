using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ApiUniversity.Models;

[ApiController]
[Route("api/student")]
public class StudentController : ControllerBase
{
    private readonly ApiUniversityContext _context;

    public StudentController(ApiUniversityContext context)
    {
        _context = context;
    }

    // GET: api/student
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
    {
        // Get Students and related lists
        var students = _context.Students.Select(x => new StudentDTO(x));
        return await students.ToListAsync();
    }

    // GET: api/student/2
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        // Find student and related list
        // SingleAsync() throws an exception if no student is found (which is possible, depending on id)
        // SingleOrDefaultAsync() is a safer choice here
        var student = await _context.Students.SingleOrDefaultAsync(s => s.Id == id);

        if (student == null)
            return NotFound();

        return student;
    }

    // POST: api/student
    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(StudentDTO studentDTO)
    {
        Student student = new(studentDTO);
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStudent), new { id = studentDTO.Id }, studentDTO);
    }

    // PUT: api/student/2
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStudent(int id, StudentDTO studentDTO)
    {
        if (id != studentDTO.Id)
            return BadRequest();

        Student student = new(studentDTO);

        _context.Entry(student).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Students.Any(s => s.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/student/2
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudentItem(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
            return NotFound();

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
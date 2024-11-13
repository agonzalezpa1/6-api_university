namespace ApiUniversity.Models;
public class Enrollment
{
    public int Id {get; set;}
    public Grade Grade {get; set;}
    public Student? Student {get; set;}
    public Course? Course {get; set;}
    public int StudentId {get; set;}
    public int CourseId {get; set;}

    public Enrollment() {}

    public Enrollment(DetailedEnrollmentDTO enrollmentDTO)
    {
        Id = enrollmentDTO.Id;
        Grade = enrollmentDTO.Grade;
        if (enrollmentDTO.StudentDTO != null)
        {
            Student = new Student(enrollmentDTO.StudentDTO);
        }
        if (enrollmentDTO.CourseDTO != null)
        {
            Course = new Course(enrollmentDTO.CourseDTO);
        }
    }

    public Enrollment(EnrollmentDTO enrollment)
    {
        StudentId = enrollment.StudentId;
        CourseId = enrollment.CourseId;
    }
}
namespace ApiUniversity.Models;

// Data Transfer Object class, used to bypass navigation properties validation during API calls
public class DetailedEnrollmentDTO
{
    public int Id {get; set;}
    public Grade Grade {get; set;}
    public StudentDTO? StudentDTO { get; set; }
    public CourseDTO? CourseDTO { get; set; }
    public DetailedEnrollmentDTO() { }

    public DetailedEnrollmentDTO(Enrollment enrollment)
    {
        Id = enrollment.Id;
        Grade = enrollment.Grade;
        if (enrollment.Student != null)
        {
            StudentDTO = new(enrollment.Student);
        }
        if (enrollment.Course != null)
        {
            CourseDTO = new(enrollment.Course);
        }
    }
}
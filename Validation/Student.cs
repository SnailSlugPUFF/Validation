using System.ComponentModel.DataAnnotations;

namespace Validation
{
    public class Student
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        [Range(1, 4)]
        public int StudyYear { get; set; }
        public Student(string name, int studyyear)
        {
            Name = name;
            StudyYear = studyyear;
        }
    }
}
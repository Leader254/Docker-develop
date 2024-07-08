using Xunit;
using myWebApp.Models;

namespace myWebApp.Tests
{
    public class StudentTests
    {
        [Fact]
        public void Student_Constructor_Should_Set_Properties()
        {
            // Arrange
            int id = 1;
            string lastName = "Whale";
            string firstMidName = "Moby";
            DateTime enrollmentDate = new DateTime(2013, 3, 15);

            // Act
            Student student = new Student
            {
                ID = id,
                LastName = lastName,
                FirstMidName = firstMidName,
                EnrollmentDate = enrollmentDate
            };

            // Assert
            Assert.Equal(id, student.ID);
            Assert.Equal(lastName, student.LastName);
            Assert.Equal(firstMidName, student.FirstMidName);
            Assert.Equal(enrollmentDate, student.EnrollmentDate);
        }

        [Fact]
        public void Student_EnrollmentDate_Should_Not_Be_Default()
        {
            // Arrange
            DateTime defaultDateTime = default;

            // Act
            Student student = new Student
            {
                EnrollmentDate = new DateTime(2022, 1, 1)
            };

            // Assert
            Assert.NotEqual(defaultDateTime, student.EnrollmentDate);
        }
        [Fact]
        public void Student_ID_Should_Be_Positive()
        {
            // Arrange
            int id = 5;

            // Act
            Student student = new Student
            {
                ID = id
            };

            // Assert
            Assert.True(student.ID > 0);
        }
        [Fact]
        public void Students_Should_Be_Sorted_By_EnrollmentDate()
        {
            // Arrange
            var students = new List<Student>
            {
                new Student { ID = 1, LastName = "Smith", FirstMidName = "John", EnrollmentDate = new DateTime(2021, 5, 1) },
                new Student { ID = 2, LastName = "Doe", FirstMidName = "Jane", EnrollmentDate = new DateTime(2019, 9, 15) },
                new Student { ID = 3, LastName = "Brown", FirstMidName = "Charlie", EnrollmentDate = new DateTime(2020, 1, 20) }
            };

            // Act
            var sortedStudents = students.OrderBy(s => s.EnrollmentDate).ToList();

            // Assert
            Assert.Equal(2, sortedStudents[0].ID);
            Assert.Equal(3, sortedStudents[1].ID);
            Assert.Equal(1, sortedStudents[2].ID);
        }
    }
}

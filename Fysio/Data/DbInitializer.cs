using System;
using System.Linq;
using Fysio.Models;

namespace Fysio.Data
{
    public static class DbInitializer
    {
        public static void Initialize(FysioContext context)
        {
 context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{ Name="Carson",Email="test@test.com",StudentNumber= Guid.NewGuid().ToString(), Date = DateTime.Parse("2002-09-01").ToString()},
            new Student{ Name="Jan",Email="test@test.com",StudentNumber= Guid.NewGuid().ToString(), Date = DateTime.Parse("2002-09-01").ToString()},
            new Student{ Name="Bart",Email="test@test.com",StudentNumber= Guid.NewGuid().ToString(), Date = DateTime.Parse("2002-09-01").ToString()},
            new Student{ Name="Kees",Email="test@test.com",StudentNumber= Guid.NewGuid().ToString(), Date = DateTime.Parse("2002-09-01").ToString()},
            new Student{ Name="Tom",Email="test@test.com",StudentNumber= Guid.NewGuid().ToString(), Date = DateTime.Parse("2002-09-01").ToString()},
            new Student{ Name="Arnold",Email="test@test.com",StudentNumber= Guid.NewGuid().ToString(), Date = DateTime.Parse("2002-09-01").ToString()},
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var teachers = new Teacher[]
            {
                new Teacher{ Name="Carson",Email="test@test.com", Phonenumber="0612121212", Staffnumber = Guid.NewGuid().ToString(), BIG = 12345678901, Date = DateTime.Parse("2002-09-01").ToString()},
                new Teacher{ Name="Carson2",Email="test@test.com", Phonenumber="0612121212", Staffnumber = Guid.NewGuid().ToString(), BIG = 12345678901, Date = DateTime.Parse("2002-09-01").ToString()},
                new Teacher{ Name="Carson3",Email="test@test.com", Phonenumber="0612121212", Staffnumber = Guid.NewGuid().ToString(), BIG = 12345678901, Date = DateTime.Parse("2002-09-01").ToString()},
                new Teacher{ Name="Carson4",Email="test@test.com", Phonenumber="0612121212", Staffnumber = Guid.NewGuid().ToString(), BIG = 12345678901, Date = DateTime.Parse("2002-09-01").ToString()},
                new Teacher{ Name="Carson5",Email="test@test.com", Phonenumber="0612121212", Staffnumber = Guid.NewGuid().ToString(), BIG = 12345678901, Date = DateTime.Parse("2002-09-01").ToString()},
                new Teacher{ Name="Carson6",Email="test@test.com", Phonenumber="0612121212", Staffnumber = Guid.NewGuid().ToString(), BIG = 12345678901, Date = DateTime.Parse("2002-09-01").ToString()},
            };
            foreach (Teacher c in teachers)
            {
                context.Teachers.Add(c);
            }
            context.SaveChanges();

            // var enrollments = new Enrollment[]
            // {
            // new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            // new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            // new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            // new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            // new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            // new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            // new Enrollment{StudentID=3,CourseID=1050},
            // new Enrollment{StudentID=4,CourseID=1050},
            // new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            // new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            // new Enrollment{StudentID=6,CourseID=1045},
            // new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            // };
            // foreach (Enrollment e in enrollments)
            // {
            //     context.Enrollments.Add(e);
            // }
            // context.SaveChanges();
        }
    }
}
using EFCoreSession03.Enums;
using EFCoreSession03.Models;
using System.Net.Http.Headers;

namespace EFCoreSession03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDBContext())
            {
                if (!context.Students.Any())
                {
                    var students = new List<Student>
                    {
                        new Student
                        {
                            FullName = "Mona Ahmed",
                            Email = "mona@gmail.com",
                            DateOfBirth = new DateTime(2003, 5, 10)
                        },
                        new Student
                        {
                            FullName = "Ali Hassan",
                            Email = "ali@gmail.com",
                            DateOfBirth = new DateTime(2002, 8, 15)
                        },
                        new Student
                        {
                            FullName = "Nour Mohamed",
                            Email = "nour@gmail.com",
                            DateOfBirth = new DateTime(2004, 2, 20)
                        },
                        new Student
                        {
                            FullName = "Omar Ali",
                            Email = "omar.student@gmail.com",
                            DateOfBirth = new DateTime(2003, 11, 5)
                        },
                        new Student
                        {
                            FullName = "Salma Mahmoud",
                            Email = "salma@gmail.com",
                            DateOfBirth = new DateTime(2002, 7, 25)
                        }
                    };
                    context.Students.AddRange(students);
                    context.SaveChanges();
                    Console.WriteLine("Students added successfully");
                    foreach (var student in context.Students)
                    {
                        Console.WriteLine($"Id: {student.Id}, FullName: {student.FullName}, Email: {student.Email}, DateOfBirth: {student.DateOfBirth.ToShortDateString()}");
                    }
                }

                if (!context.Enrollments.Any())
                {
                    var students = context.Students.OrderBy(s => s.Id).ToList();
                    if (students.Count < 5)
                    {
                        Console.WriteLine("Not enough students to create enrollments.");
                    }
                    else
                    {
                        var enrollments = new List<Enrollment>
                        {
                            new Enrollment
                            {
                                StudentId = students[0].Id,
                                CourseId = 1,
                                EnrollmentDate = new DateTime(2025, 1, 10),
                                Progress = 100,
                                Status = EnrollmentStatus.Completed,
                                FinalGarde = 95
                            },

                            new Enrollment
                            {
                                StudentId = students[1].Id,
                                CourseId = 1,
                                EnrollmentDate = new DateTime(2025, 2, 1),
                                Progress = 100,
                                Status = EnrollmentStatus.Completed,
                                FinalGarde = 88
                            },

                            new Enrollment
                            {
                                StudentId = students[1].Id,
                                CourseId = 3,
                                EnrollmentDate = new DateTime(2025, 2, 5),
                                Progress = 20,
                                Status = EnrollmentStatus.Dropped,
                                FinalGarde = null
                            },

                            new Enrollment
                            {
                                StudentId = students[2].Id,
                                CourseId = 2,
                                EnrollmentDate = new DateTime(2025, 3, 1),
                                Progress = 60,
                                Status = EnrollmentStatus.Active,
                                FinalGarde = null
                            },

                            new Enrollment
                            {
                                StudentId = students[2].Id,
                                CourseId = 5,
                                EnrollmentDate = new DateTime(2025, 3, 5),
                                Progress = 100,
                                Status = EnrollmentStatus.Completed,
                                FinalGarde = 92
                            },

                            new Enrollment
                            {
                                StudentId = students[3].Id,
                                CourseId = 3,
                                EnrollmentDate = new DateTime(2025, 4, 1),
                                Progress = 10,
                                Status = EnrollmentStatus.Dropped,
                                FinalGarde = null
                            },

                            new Enrollment
                            {
                                StudentId = students[4].Id,
                                CourseId = 5,
                                EnrollmentDate = new DateTime(2025, 4, 10),
                                Progress = 75,
                                Status = EnrollmentStatus.Active,
                                FinalGarde = null
                            }

                        };
                        context.Enrollments.AddRange(enrollments);
                        context.SaveChanges();
                        Console.WriteLine("Enrollments added successfully.");
                    }

                }
            }
            #region Create
            //AddInstructor();

            //AddCourse(1, 4);

            //AddSeveralStudents();

            //EnrollStudent(1, 1);
            #endregion

            #region Read 
            //FindCourse(1, "ASP.NET Core Web API");

            //FilterCourses(400, 1200);

            //PrintSubCategories(1);

            //PrintCourseRoster(1);
            #endregion 

        }

        #region Create 
        static void AddInstructor()
        {
            using (var context = new AppDBContext())
            {
                var instructor = new Instructor
                {
                    FullName = "Mostafa Adel",
                    Email = "mostafa@gmail.com",
                    Bio = "Backend Developer",
                    JoinAt = DateTime.Now
                };
                context.Instructors.Add(instructor);
                context.SaveChanges();
                Console.WriteLine($"Instructor Added Successfully ID:{instructor.Id}");
            }

        }
        static void AddCourse(int instructorId, int categoryId)
        {
            using (var context = new AppDBContext())
            {
                var instructor = context.Instructors.Find(instructorId);
                var category = context.Categories.Find(categoryId);
                if (instructor == null)
                {
                    Console.WriteLine("Instructor not found.");
                    return;
                }
                if (category == null)
                {
                    Console.WriteLine("Category not found.");
                    return;
                }
                var course = new Course
                {
                    Title = "Entity Framework Core",
                    Description = "Learn EF Core with C#",
                    Price = 800,
                    Level = CourseLevel.Intermediate,
                    IsPublished = false,
                    PublishededAt = null,
                    InstructorId = instructorId,
                    CategoryId = categoryId
                };
                context.Courses.Add(course);
                context.SaveChanges();
                Console.WriteLine($"Course Added Successfully ID:{course.Id}");

            }
        }
        static void AddSeveralStudents()
        {
            using (var context = new AppDBContext())
            {
                var students = new List<Student>
                {

                    new Student
                    {
                        FullName = "Hana Ahmed",
                        Email = "hana@gmail.com",
                        DateOfBirth = new DateTime(2003, 4, 10)
                    },
                    new Student
                    {
                        FullName = "Youssef Ali",
                        Email = "youssef@gmail.com",
                        DateOfBirth = new DateTime(2002, 8, 15)
                    },
                    new Student
                    {
                        FullName = "Malak Mohamed",
                        Email = "malak@gmail.com",
                        DateOfBirth = new DateTime(2004, 1, 20)
                    }

                };
                context.Students.AddRange(students);
                context.SaveChanges();
                foreach (var student in students)
                {
                    Console.WriteLine($"Student added :{student.FullName}, ID: {student.Id}");
                }
            }
        }
        static void EnrollStudent(int studentId, int courseId)
        {
            using (var context = new AppDBContext())
            {
                var student = context.Students.Find(studentId);
                if (student == null)
                {
                    Console.WriteLine("Student not found.");
                    return;
                }

                var course = context.Courses.Find(courseId);
                if (course == null)
                {
                    Console.WriteLine("Course not found.");
                    return;
                }

                if (!course.IsPublished)
                {
                    Console.WriteLine("Course is not published.");
                    return;
                }
                var existingEnrollment = context.Enrollments.
                    Find(studentId, courseId);
                if (existingEnrollment != null)
                {
                    Console.WriteLine("Student Already enrolled in this course");
                    return;
                }

                var enrollment = new Enrollment
                {
                    StudentId = studentId,
                    CourseId = courseId,
                    EnrollmentDate = DateTime.Now,
                    Progress = 0,
                    Status = EnrollmentStatus.Active,
                    FinalGarde = null
                };
                context.Enrollments.Add(enrollment);
                context.SaveChanges();
                Console.WriteLine($"Student {student.FullName} enrolled in course {course.Title} successfully.");
            }
        }
        #endregion
        #region Read

        static void FindCourse(int courseId, string title)
        {
            using (var context = new AppDBContext())
            {
                var courseById = context.Courses.Find(courseId);

                if (courseById != null)
                {
                    Console.WriteLine($"Found by ID: {courseById.Title}");
                }
                else
                {
                    Console.WriteLine("Course not found by ID");
                }

                var courseByTitle = context.Courses.FirstOrDefault(c => c.Title == title);

                if (courseByTitle != null)
                {
                    Console.WriteLine($"Found by Title: {courseByTitle.Title}");
                }
                else
                {
                    Console.WriteLine("Course not found by Title");
                }
            }
        }
        static void FilterCourses(decimal minPrice , decimal maxPrice)
        {
            using (var context = new AppDBContext())
            {
                var courses = context.Courses
                                   .Where(c => c.Price >= minPrice && c.Price <= maxPrice)
                                   .OrderByDescending(c => c.Price)
                                   .ToList();
                foreach (var course in courses)
                {
                    Console.WriteLine($"Course: {course.Title}, {course.Level},Price: {course.Price}");
                }
            }
        }
        static void PrintSubCategories(int categoryId)
        {
            using (var context = new AppDBContext())
            {
                var subCategories = context.Categories
                                            .Where(c => c.ParentCategoryId == categoryId)
                                            .ToList();
                Console.WriteLine("Sub Categories: ");
                foreach (var category in subCategories)
                {
                    Console.WriteLine($"Category: {category.Name}");
                }
                var topCategories = context.Categories
                                            .Where(c => c.ParentCategoryId == null)
                                            .ToList();
                Console.WriteLine("Top Level Categories: ");
                foreach (var category in topCategories)
                {
                    Console.WriteLine($"Category: {category.Name}");
                }
            }
        }
        static void PrintCourseRoster(int courseId)
        {
            using (var context = new AppDBContext())
            {
                var course = context.Courses.Find(courseId);
                if (course == null)
                {
                    Console.WriteLine("Course not found.");
                    return;
                }
                var studentIds =context.Enrollments
                                        .Where(c => c.CourseId == courseId)
                                        .Select(c => c.StudentId)
                                        .ToList();
                Console.WriteLine($"Number of enrolled Students: {studentIds.Count}");
                var students = context.Students
                                    .Where(s => studentIds.Contains(s.Id))
                                    .ToList();
                foreach (var student in students)
                {
                    Console.WriteLine(student.FullName);
                }
            }
        }
        #endregion
        #region Update
        static void UpdateCoursePrice(int courseId , decimal newPrice)
        {
            using (var context = new AppDBContext())
            {
                var course = context.Courses.Find(courseId);
                if (course == null)
                {
                    Console.WriteLine("Course not Found");
                    return;
                }
                course.Price = newPrice;
                context.SaveChanges();
                Console.WriteLine("Course Price Updated successfully");
            }
        }
        static void UpdateEnrollmentProgress(int studentId , int courseId , decimal newProgress)
        {
            using (var context = new AppDBContext())
            {
                var enrollment = context.Enrollments.Find(studentId , courseId);
                if(enrollment == null)
                {
                    Console.WriteLine("Enrollment not found");
                    return;
                }
                if(newProgress < 0 || newProgress > 100)
                {
                    Console.WriteLine("progress must be between 0 and 100");
                    return;

                }
                enrollment.Progress = newProgress;
                if(newProgress == 100)
                {
                    enrollment.Status = EnrollmentStatus.Completed;
                }

                context.SaveChanges();
                Console.WriteLine("Enrollment progress Updated Successfully");
            }
        }
        static void UpdateStudentEmail (int studentId , string newEmail)
        {
            using (var context = new AppDBContext())
            {
                var student = context.Students.Find(studentId);
                if(student == null)
                {
                    Console.WriteLine("Student not found");
                    return;

                }
                student.Email = newEmail;
                context.SaveChanges();
                Console.WriteLine("Student Email Upadeted Successfully");
            }
        }

        #endregion


    }

}


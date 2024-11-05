using Microsoft.EntityFrameworkCore;
using DB1_AcmeInstituteofLooning.AcmeData;
using DB1_AcmeInstituteofLooning.AcmeModels;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;

namespace DB1_AcmeInstituteofLooning.Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu welcome = new Menu();
            welcome.WelMenu();
            Menu option = new Menu();
            option.OptMenu();
        }
    }

    public class Menu
    {
        public void WelMenu()
        {
            Console.WriteLine("\n-------------------------------------------------------------------------------------\n");
            Console.WriteLine("\nWELCOME TO THE ACME ISTITUTION OF LOONING!\n");
        }
        public void OptMenu()
        {
            do
            {
                Console.WriteLine("\n-------------------------------------------------------------------------------------\n");
                Console.WriteLine("\nChoose an option by entering the right number:\n\n1.Teachers\n2.Administration\n3.Principal\n4.View Students\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("\n-------------------------------------------------------------------------------------");
                        Console.WriteLine("These are the prominent teachers of Acmes Institution of Looning: ");
                        Console.WriteLine("-------------------------------------------------------------------------------------\n");
                        GetPeople teacher = new GetPeople();
                        teacher.GetTeachers();
                        Console.WriteLine("\n-------------------------------------------------------------------------------------");
                        Console.WriteLine("End");
                        Console.WriteLine("-------------------------------------------------------------------------------------\n");
                        break;

                    case "2":
                        Console.WriteLine("\n-------------------------------------------------------------------------------------");
                        Console.WriteLine("These are the prominent admission administrators of Acmes Institution of Looning: ");
                        Console.WriteLine("-------------------------------------------------------------------------------------\n");
                        GetPeople admin = new GetPeople();
                        admin.GetAdmins();
                        Console.WriteLine("\n-------------------------------------------------------------------------------------");
                        Console.WriteLine("End");
                        Console.WriteLine("-------------------------------------------------------------------------------------\n");
                        break;

                    case "3":
                        Console.WriteLine("\n-------------------------------------------------------------------------------------");
                        Console.WriteLine("This is the glorious head master of Acmes Institution of Looning: ");
                        Console.WriteLine("-------------------------------------------------------------------------------------\n");
                        GetPeople principal = new GetPeople();
                        principal.GetPrincipal();
                        Console.WriteLine("\n-------------------------------------------------------------------------------------");
                        Console.WriteLine("End");
                        Console.WriteLine("-------------------------------------------------------------------------------------\n");
                        break;
                    case "4":
                        Console.WriteLine("\n-----------------------------------------------------------------------------------------------------");
                        Console.WriteLine("To view the excellent Students of Acmes Institution of Looning - ");
                        Menu students = new Menu();
                        students.StuMenu();
                        break;
                    case "5":
                        Console.WriteLine("\n-------------------------------------------------------------------------------------");
                        Console.WriteLine("To view the change teacher course- ");
                        // Byt lärare från 4001 till 4004
                        GetPeople.UpdateTeacherForCourses(4001, 4004);
                        Console.WriteLine("End");
                        Console.WriteLine("-------------------------------------------------------------------------------------\n");
                        break;
                    default:
                        Console.WriteLine("\n-------------------------------------------------------------------------------------");
                        Console.WriteLine("Oh, I'm sorry - where you looking for someone else?\n");
                        Menu def = new Menu();
                        def.OptMenu();
                        break;
                }
            }
            while (true);
        }
        public void StuMenu()
        {
            do
            {
                Console.WriteLine("Choose a sorting option by entering either of these numbers:\n\nEnter [1]\nTo sort by Last name in afabethical order.\n\nEnter [2]\nTo sort by Last name in reversed alfabethical order. \n\nEnter [3]\nTo sort by First name in afabethical order.\n\nEnter [4]\nTo sort by First name in reversed alfabethical order.\n\nEnter [5]\nTo view classlist.");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("\n-------------------------------------------------------------------------------------");
                        Console.WriteLine("Acme Students by Last Name (afabethical):");
                        Console.WriteLine("-------------------------------------------------------------------------------------\n");
                        GetPeople students = new GetPeople();
                        students.GetSLNameAB();
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("End");
                        Console.WriteLine("-------------------------------------------------------------------------------------\n");
                        break;

                    case "2":
                        Console.WriteLine("\n-------------------------------------------------------------------------------------");
                        Console.WriteLine("Acme Students by Last Name (reversed alfabethical):\n");
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        GetPeople students1 = new GetPeople();
                        students1.GetSLNameBA();
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("End");
                        Console.WriteLine("-------------------------------------------------------------------------------------\n");
                        break;

                    case "3":
                        Console.WriteLine("\n-------------------------------------------------------------------------------------");
                        Console.WriteLine("Acme Students by First Name (alfabethical):\n");
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        GetPeople students2 = new GetPeople();
                        students2.GetSFNameAB();
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("End");
                        Console.WriteLine("-------------------------------------------------------------------------------------\n");
                        break;
                    case "4":
                        Console.WriteLine("\n-------------------------------------------------------------------------------------");
                        Console.WriteLine("Acme Students by First Name (reversed alfabethical):");
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        GetPeople students3 = new GetPeople();
                        students3.GetSFNameBA();
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("End");
                        Console.WriteLine("-------------------------------------------------------------------------------------\n");
                        break;
                    case "5":
                        Console.WriteLine("\n-------------------------------------------------------------------------------------");
                        Console.WriteLine("To view the class looning groups - ");
                        ClassInfo classes = new ClassInfo();
                        classes.GetClasses();
                        break;
                    default:
                        Console.WriteLine("\n-------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Oh, I'm sorry - where you looking for someone else?");
                        Menu def = new Menu();
                        def.OptMenu();
                        break;
                }
            }
            while (true);
        }
    }
    public class GetPeople
    {
        string teachers { get; set; }
        string admins { get; set; }
        string principal { get; set; }
        string students { get; set; }

        public string GetTeachers()
        {
            using (var acmecontext = new AcmeContext())
            {
                var AcmesTeachers = acmecontext.AcmePeople.Where(staff => staff.Concern == "Teacher");
                foreach (var acmeTeacher in AcmesTeachers)
                {
                    Console.WriteLine(acmeTeacher.Fname + " " + acmeTeacher.Lname);
                }
            }

            return teachers;
        }
        public static void UpdateTeacherForCourses(int oldTeacherId, int newTeacherId)
        {
            using (var context = new AcmeContext())
            {
                // Hämta kurser med FkAteacherId 4001
                var coursesToUpdate = context.AcmeCourses
                    .Where(c => c.FkAteacherId == oldTeacherId)
                    .ToList();

                if (coursesToUpdate.Any())
                {
                    foreach (var course in coursesToUpdate)
                    {
                        // Uppdatera FkAteacherId till 4004
                        course.FkAteacherId = newTeacherId;
                    }

                    // Spara ändringarna i databasen
                    context.SaveChanges();
                    Console.WriteLine($"Alla kurser har nu FkAteacherId {newTeacherId} istället för {oldTeacherId}.");
                }
                else
                {
                    Console.WriteLine($"Inga kurser hittades med FkAteacherId {oldTeacherId}.");
                }
            }
        }

        public string GetAdmins()
        {
            using (var acmecontext = new AcmeContext())
            {
                var AcmesAdmins = acmecontext.AcmePeople.Where(staff => staff.Concern == "AdmissionAdmin");
                foreach (var acmeAdmin in AcmesAdmins)
                {
                    Console.WriteLine(acmeAdmin.Fname + " " + acmeAdmin.Lname);
                }
            }
            return admins;
        }
        public string GetPrincipal()
        {
            using (var acmecontext = new AcmeContext())
            {
                var AcmesPrincipal = acmecontext.AcmePeople.Where(staff => staff.Concern == "Principal");
                foreach (var acmePrincipal in AcmesPrincipal)
                {
                    Console.WriteLine(acmePrincipal.Fname + " " + acmePrincipal.Lname);
                }
            }
            return principal;
        }
        public string GetSLNameAB()
        {
            using (var acmecontext = new AcmeContext())
            {
                var AcmesStudents = acmecontext.AcmePeople
                    .Where(stu => stu.Concern == "Student")
                    .OrderBy(stu => stu.Lname).ToList();
                foreach (var acmeStudent in AcmesStudents)
                {
                    Console.WriteLine(acmeStudent.Lname + " " + acmeStudent.Fname);
                }
            }
            return students;
        }
        public string GetSLNameBA()
        {
            using (var acmecontext = new AcmeContext())
            {
                var AcmesStudents = acmecontext.AcmePeople
                    .Where(stu => stu.Concern == "Student")
                    .OrderByDescending(stu => stu.Lname).ToList();
                foreach (var acmeStudent in AcmesStudents)
                {
                    Console.WriteLine(acmeStudent.Lname + " " + acmeStudent.Fname);
                }
            }
            return students;
        }
        public string GetSFNameAB()
        {
            using (var acmecontext = new AcmeContext())
            {
                var AcmesStudents = acmecontext.AcmePeople
                    .Where(stu => stu.Concern == "Student")
                    .OrderBy(stu => stu.Fname).ToList();
                foreach (var acmeStudent in AcmesStudents)
                {
                    Console.WriteLine(acmeStudent.Fname + " " + acmeStudent.Lname);
                }
            }
            return students;
        }
        public string GetSFNameBA()
        {
            using (var acmecontext = new AcmeContext())
            {
                var AcmesStudents = acmecontext.AcmePeople
                    .Where(stu => stu.Concern == "Student")
                    .OrderByDescending(stu => stu.Fname).ToList();
                foreach (var acmeStudent in AcmesStudents)
                {
                    Console.WriteLine(acmeStudent.Fname + " " + acmeStudent.Lname);
                }
            }
            return students;
        }
    }
    public class ClassInfo
    {
        public string stuClasses { get; set; }
        public string GetClasses() 
        {
            using (var acmecontext = new AcmeContext())
            {
                var AcmesClasses = from ac in acmecontext.AcmeClasses
                                   orderby ac.YearGroup
                                   select ac;
                foreach (var acmeClass in AcmesClasses)
                {
                    Console.WriteLine("\nClass Name: " + acmeClass.ClassName + "\nStarting Year: " + acmeClass.YearGroup + "\n");
                }

                Console.WriteLine("-------------------------------------------------------------------------------------");
            }
            return stuClasses;
        }
    }
}
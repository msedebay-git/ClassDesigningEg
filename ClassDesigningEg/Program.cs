using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

// design a class for Country, State aand City - 1 to M
// Customer and product - M:M


Employer E = new Employer()
{
    Eid = 1,
    Name = "Peter",
    Salary = 7000,
    AddressNvg=new Address() { Aid = 1200, DNo = "23-56", City="Columbia"}
};
//Console.WriteLine($"Eid:{E.Eid} Name:{E.Name} Salary:{E.Salary} DNo:{E.AddressNvg.DNo} City:{E.AddressNvg.City}");
Console.WriteLine($"Eid:{E.Eid}");
Console.WriteLine($"Name:{E.Name}");
Console.WriteLine($"Salary:{E.Salary}");
Console.WriteLine($"DNo:{E.AddressNvg.DNo}");
Console.WriteLine($"City:{E.AddressNvg.City}");
[Table("Address")]

//1 to 1 Relationship
public class Address
{
    [Key]
    public int Aid { get; set; }
    public string? DNo { get; set; }
    public string? City { get; set; }
}

// One to Many relationship. One department to many employees
[Table("Department")]
public class Department
{
    [Key]
    public int Did { get; set; }
    public string? Description { get; set; }
    public string? DName { get; set; }
    public List<Employer> Employers { get; set; }  // 1 to Many Relationship
}


[Table("Employer")]
public class Employer
{
    [Key]
    public int Eid { get; set; }
    public string? Name { get; set; }
    public double Salary { get; set; }
    public Address AddressNvg { get; set; } //Navigation Property  // 1 to 1 Relationship

    [ForeignKey("AddressNvg")]
    public int Aid { get; set; }
    public Department DepartmentNvg { get; set; }

    [ForeignKey("DepartmentNvg")]
    public int Did { get; set; }    
}

// Many-To-Many Relationship. Whenever you have M:M relationships, you have a new class.
//both of the class will have a list of class

[Table("Student")]      // 1st class 
public class Student
{
    [Key]
    public int Sid { get; set; }
    public string? Name { get; set; }
    public List<StudentCourse> StudentCourses { get; set; }
}

[Table("Course")]       //2nd class
public class Course
{
    [Key]
    public int Cid { get; set; }
    public string? CName { get; set; }
    public List<StudentCourse> StudentCourses { get; set; }
}

[Table("StudentCourse")]   // new class, Association from 1st and 2nd classes.
public class StudentCourse
{
    [Key]
    public int SCId { get; set; }
    public Student StudentNvg { get; set; }
    [ForeignKey("StudentNvg")]
    public int Sid { get; set; }
    public Course CourseNvg { get; set; }
    [ForeignKey("CourseNvg")]
    public int Cid { get; set; }
}


public class OrgDbContext:DbContext
{
    public DbSet<Student> Students { get; set; } 

    public DbSet<Course> Courses { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Employer> Employers { get
            ; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=DESKTOP-DF2H2V7\\SQLEXPRESS2019;Database=ClassDesignDb;Trusted_Connection=True;");
    }
}




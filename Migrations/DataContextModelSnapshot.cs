﻿// <auto-generated />
using System;
using FirstProjectWithMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FirstProjectWithMVC.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend.Models.Class", b =>
                {
                    b.Property<int>("ClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassID"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StageID")
                        .HasColumnType("int");

                    b.HasKey("ClassID");

                    b.HasIndex("StageID");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Backend.Models.Division", b =>
                {
                    b.Property<int>("DivisionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DivisionID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.Property<string>("DivisionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DivisionID");

                    b.HasIndex("ClassID");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("Backend.Models.Guardian", b =>
                {
                    b.Property<int>("GuardianID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuardianID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Job")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeGuardian")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("GuardianID");

                    b.ToTable("Guardians");
                });

            modelBuilder.Entity("Backend.Models.Manager", b =>
                {
                    b.Property<int>("ManagerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManagerID"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ManagerID");

                    b.HasIndex("SchoolID")
                        .IsUnique();

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Backend.Models.Salary", b =>
                {
                    b.Property<int>("SalaryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalaryID"));

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalaryAmount")
                        .HasColumnType("int");

                    b.Property<DateOnly>("SalaryHireDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("SalaryMonth")
                        .HasColumnType("date");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("SalaryID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Salarys");
                });

            modelBuilder.Entity("Backend.Models.School", b =>
                {
                    b.Property<int>("SchoolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SchoolID"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolGoal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolMission")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolNameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolPhone")
                        .HasColumnType("int");

                    b.Property<string>("SchoolType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolVison")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("School_Crea_Date")
                        .HasColumnType("date");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("fax")
                        .HasColumnType("int");

                    b.Property<string>("zone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolID");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("Backend.Models.Stage", b =>
                {
                    b.Property<int>("StageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StageID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearID")
                        .HasColumnType("int");

                    b.HasKey("StageID");

                    b.HasIndex("YearID");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("Backend.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<int>("DivisionID")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GuardianID")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("StudentID");

                    b.HasIndex("ClassID");

                    b.HasIndex("DivisionID");

                    b.HasIndex("GuardianID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Backend.Models.StudentClass", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.HasKey("StudentID", "ClassID");

                    b.HasIndex("ClassID");

                    b.ToTable("StudentClass");
                });

            modelBuilder.Entity("Backend.Models.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectID"));

                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectID");

                    b.HasIndex("ClassID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Backend.Models.SubjectStudent", b =>
                {
                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.HasKey("SubjectID", "StudentID");

                    b.HasIndex("StudentID");

                    b.ToTable("SubjectStudents");
                });

            modelBuilder.Entity("Backend.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherID"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("HireDate")
                        .HasColumnType("date");

                    b.Property<int>("ManagerID")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("TeacherID");

                    b.HasIndex("ManagerID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Backend.Models.TeacherStudent", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("StudentID", "TeacherID");

                    b.HasIndex("TeacherID");

                    b.ToTable("TeacherStudents");
                });

            modelBuilder.Entity("Backend.Models.TeacherSubjectStudent", b =>
                {
                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("TeacherID", "StudentID", "SubjectID");

                    b.HasIndex("StudentID");

                    b.HasIndex("SubjectID");

                    b.ToTable("TeacherSubjectStudent");
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.Models.Year", b =>
                {
                    b.Property<int>("YearID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("YearID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("HireDate")
                        .HasColumnType("date");

                    b.Property<int>("SchoolID")
                        .HasColumnType("int");

                    b.Property<DateOnly>("YearDateEnd")
                        .HasColumnType("date");

                    b.Property<DateOnly>("YearDateStart")
                        .HasColumnType("date");

                    b.HasKey("YearID");

                    b.HasIndex("SchoolID");

                    b.ToTable("Years");
                });

            modelBuilder.Entity("Backend.Models.Class", b =>
                {
                    b.HasOne("Backend.Models.Stage", "Stage")
                        .WithMany("Classes")
                        .HasForeignKey("StageID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("Backend.Models.Division", b =>
                {
                    b.HasOne("Backend.Models.Class", "Class")
                        .WithMany("Divisions")
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("Backend.Models.Guardian", b =>
                {
                    b.OwnsOne("Backend.Models.Name", "FullName", b1 =>
                        {
                            b1.Property<int>("GuardianID")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SecondName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ThirdName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("GuardianID");

                            b1.ToTable("Guardians");

                            b1.WithOwner()
                                .HasForeignKey("GuardianID");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.Manager", b =>
                {
                    b.HasOne("Backend.Models.School", "School")
                        .WithOne("Manager")
                        .HasForeignKey("Backend.Models.Manager", "SchoolID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Backend.Models.Name", "FullName", b1 =>
                        {
                            b1.Property<int>("ManagerID")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SecondName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ThirdName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ManagerID");

                            b1.ToTable("Managers");

                            b1.WithOwner()
                                .HasForeignKey("ManagerID");
                        });

                    b.Navigation("FullName")
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("Backend.Models.Salary", b =>
                {
                    b.HasOne("Backend.Models.Teacher", "Teacher")
                        .WithMany("Salaries")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Backend.Models.Stage", b =>
                {
                    b.HasOne("Backend.Models.Year", "Year")
                        .WithMany("Stages")
                        .HasForeignKey("YearID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Year");
                });

            modelBuilder.Entity("Backend.Models.Student", b =>
                {
                    b.HasOne("Backend.Models.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Backend.Models.Division", "Division")
                        .WithMany("Students")
                        .HasForeignKey("DivisionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Backend.Models.Guardian", "Guardian")
                        .WithMany("Students")
                        .HasForeignKey("GuardianID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Backend.Models.Name", "FullName", b1 =>
                        {
                            b1.Property<int>("StudentID")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SecondName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ThirdName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("StudentID");

                            b1.ToTable("Students");

                            b1.WithOwner()
                                .HasForeignKey("StudentID");
                        });

                    b.Navigation("Class");

                    b.Navigation("Division");

                    b.Navigation("FullName")
                        .IsRequired();

                    b.Navigation("Guardian");
                });

            modelBuilder.Entity("Backend.Models.StudentClass", b =>
                {
                    b.HasOne("Backend.Models.Class", "Class")
                        .WithMany("StudentClass")
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Backend.Models.Student", "Student")
                        .WithMany("StudentClass")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Backend.Models.Subject", b =>
                {
                    b.HasOne("Backend.Models.Class", "Class")
                        .WithMany("Subjects")
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("Backend.Models.SubjectStudent", b =>
                {
                    b.HasOne("Backend.Models.Student", "Student")
                        .WithMany("SubjectStudents")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Backend.Models.Subject", "Subject")
                        .WithMany("SubjectStudents")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Backend.Models.Teacher", b =>
                {
                    b.HasOne("Backend.Models.Manager", "Manager")
                        .WithMany("Teachers")
                        .HasForeignKey("ManagerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Backend.Models.Name", "FullName", b1 =>
                        {
                            b1.Property<int>("TeacherID")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SecondName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ThirdName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TeacherID");

                            b1.ToTable("Teachers");

                            b1.WithOwner()
                                .HasForeignKey("TeacherID");
                        });

                    b.Navigation("FullName")
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Backend.Models.TeacherStudent", b =>
                {
                    b.HasOne("Backend.Models.Student", "Student")
                        .WithMany("TeacherStudents")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Backend.Models.Teacher", "Teacher")
                        .WithMany("TeacherStudents")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Backend.Models.TeacherSubjectStudent", b =>
                {
                    b.HasOne("Backend.Models.Student", "Student")
                        .WithMany("TeacherSubjectStudents")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Backend.Models.Subject", "Subject")
                        .WithMany("TeacherSubjectStudents")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Backend.Models.Teacher", "Teacher")
                        .WithMany("TeacherSubjectStudents")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Backend.Models.Year", b =>
                {
                    b.HasOne("Backend.Models.School", "School")
                        .WithMany("Years")
                        .HasForeignKey("SchoolID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("Backend.Models.Class", b =>
                {
                    b.Navigation("Divisions");

                    b.Navigation("StudentClass");

                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("Backend.Models.Division", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Backend.Models.Guardian", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Backend.Models.Manager", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Backend.Models.School", b =>
                {
                    b.Navigation("Manager");

                    b.Navigation("Years");
                });

            modelBuilder.Entity("Backend.Models.Stage", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("Backend.Models.Student", b =>
                {
                    b.Navigation("StudentClass");

                    b.Navigation("SubjectStudents");

                    b.Navigation("TeacherStudents");

                    b.Navigation("TeacherSubjectStudents");
                });

            modelBuilder.Entity("Backend.Models.Subject", b =>
                {
                    b.Navigation("SubjectStudents");

                    b.Navigation("TeacherSubjectStudents");
                });

            modelBuilder.Entity("Backend.Models.Teacher", b =>
                {
                    b.Navigation("Salaries");

                    b.Navigation("TeacherStudents");

                    b.Navigation("TeacherSubjectStudents");
                });

            modelBuilder.Entity("Backend.Models.Year", b =>
                {
                    b.Navigation("Stages");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Models;

public partial class SchoolManagementContext : DbContext
{
    public SchoolManagementContext()
    {
    }

    public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<About> Abouts { get; set; }

    public virtual DbSet<AboutBanner> AboutBanners { get; set; }

    public virtual DbSet<AboutService> AboutServices { get; set; }

    public virtual DbSet<AdminLogin> AdminLogins { get; set; }

    public virtual DbSet<ApprovedforExamination> ApprovedforExaminations { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Checkresult> Checkresults { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Contactu> Contactus { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<DashboardAnalytic> DashboardAnalytics { get; set; }

    public virtual DbSet<Deal> Deals { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Feesinfo> Feesinfos { get; set; }

    public virtual DbSet<Frui> Fruis { get; set; }

    public virtual DbSet<GeneralNews> GeneralNews { get; set; }

    public virtual DbSet<IndexHome> IndexHomes { get; set; }

    public virtual DbSet<Leave> Leaves { get; set; }

    public virtual DbSet<LeaveStatus> LeaveStatuses { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<MarksEntry> MarksEntries { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<OurTeam> OurTeams { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductBrand> ProductBrands { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductColor> ProductColors { get; set; }

    public virtual DbSet<ProductEntry> ProductEntries { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductModel> ProductModels { get; set; }

    public virtual DbSet<ProductSerise> ProductSerises { get; set; }

    public virtual DbSet<ProductSize> ProductSizes { get; set; }

    public virtual DbSet<ProductTitle> ProductTitles { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<ResultEntry> ResultEntries { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleCreation> RoleCreations { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }

    public virtual DbSet<StudentDetail> StudentDetails { get; set; }

    public virtual DbSet<StudentRegistration> StudentRegistrations { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectTakenByTeacher> SubjectTakenByTeachers { get; set; }

    public virtual DbSet<TeacherDetail> TeacherDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-M09BAAL;Database=schoolManagement;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<About>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__about__3214EC0756947009");

            entity.ToTable("about");

            entity.Property(e => e.AboutTitle)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.ServiceImage)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ServiceTitle)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ShopAddress)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.WeekdayHr)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.WeekendHr)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("weekendHr");
        });

        modelBuilder.Entity<AboutBanner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__aboutBan__3214EC07BA60BD2C");

            entity.ToTable("aboutBanner");

            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MainTitle)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.SubTitle)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.SubTitleDiscount)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubTitleValue)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(900)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<AboutService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__aboutSer__3214EC07A2B87E12");

            entity.ToTable("aboutService");

            entity.Property(e => e.Details)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Isdeleted).HasColumnName("ISdeleted");
            entity.Property(e => e.Logo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AdminLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminLog__3214EC27C61DAA8D");

            entity.ToTable("AdminLogin");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<ApprovedforExamination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Approved__3214EC2730519A5D");

            entity.ToTable("ApprovedforExamination");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExamHallNumber)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationId).HasColumnName("RegistrationID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.SubjectTakenId).HasColumnName("SubjectTakenID");
            entity.Property(e => e.TeacherDetailsId).HasColumnName("TeacherDetailsID");

            entity.HasOne(d => d.Registration).WithMany(p => p.ApprovedforExaminations)
                .HasForeignKey(d => d.RegistrationId)
                .HasConstraintName("FK__Approvedf__Regis__30F848ED");

            entity.HasOne(d => d.Role).WithMany(p => p.ApprovedforExaminations)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Approvedf__RoleI__46E78A0C");

            entity.HasOne(d => d.Subject).WithMany(p => p.ApprovedforExaminations)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Approvedf__Subje__282DF8C2");

            entity.HasOne(d => d.SubjectTaken).WithMany(p => p.ApprovedforExaminations)
                .HasForeignKey(d => d.SubjectTakenId)
                .HasConstraintName("FK__Approvedf__Subje__32E0915F");

            entity.HasOne(d => d.TeacherDetails).WithMany(p => p.ApprovedforExaminations)
                .HasForeignKey(d => d.TeacherDetailsId)
                .HasConstraintName("FK__Approvedf__Teach__31EC6D26");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cart__3214EC077CB98085");

            entity.ToTable("cart");

            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Price)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Quantity)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Total)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Checkresult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__checkres__3214EC076C381AA1");

            entity.ToTable("checkresult");

            entity.Property(e => e.MarkId).HasColumnName("markID");
            entity.Property(e => e.ResultId).HasColumnName("ResultID");
            entity.Property(e => e.StudentDetailId).HasColumnName("StudentDetailID");

            entity.HasOne(d => d.Mark).WithMany(p => p.Checkresults)
                .HasForeignKey(d => d.MarkId)
                .HasConstraintName("FK__checkresu__markI__40F9A68C");

            entity.HasOne(d => d.Result).WithMany(p => p.Checkresults)
                .HasForeignKey(d => d.ResultId)
                .HasConstraintName("FK__checkresu__Resul__41EDCAC5");

            entity.HasOne(d => d.StudentDetail).WithMany(p => p.Checkresults)
                .HasForeignKey(d => d.StudentDetailId)
                .HasConstraintName("FK__checkresu__Stude__42E1EEFE");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__City__3214EC275481DE71");

            entity.ToTable("City");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FullName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StateId).HasColumnName("StateID");

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__City__StateID__52593CB8");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Colorid).HasName("PK__color__70A94BA5B5AC1946");

            entity.ToTable("color");

            entity.Property(e => e.Colorid).HasColumnName("colorid");
            entity.Property(e => e.ColorName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colorName");
        });

        modelBuilder.Entity<Contactu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contactu__3214EC070073B27B");

            entity.ToTable("contactus");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Message)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Subject)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3214EC27D13D595B");

            entity.ToTable("Country");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ShortName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<DashboardAnalytic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Dashboar__3214EC27239CD002");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClassesTotal)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Events)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.StudentsTotal)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TeachersTotal)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Deal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Deal__3214EC07E4611D13");

            entity.ToTable("Deal");

            entity.Property(e => e.Details)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Percentage)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("percentage");
            entity.Property(e => e.Subtitle)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exams__3214EC27B4DC8670");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExamDuration)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ExamTiming)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SubjectName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Feesinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feesinfo__3214EC2704508375");

            entity.ToTable("Feesinfo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DueFees)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaidFess)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationId).HasColumnName("RegistrationID");
            entity.Property(e => e.StudentDetailId).HasColumnName("StudentDetailID");
            entity.Property(e => e.StudentRegistrationId).HasColumnName("StudentRegistrationID");
            entity.Property(e => e.TotalFees)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Registration).WithMany(p => p.Feesinfos)
                .HasForeignKey(d => d.RegistrationId)
                .HasConstraintName("FK__Feesinfo__Regist__38996AB5");

            entity.HasOne(d => d.StudentDetail).WithMany(p => p.Feesinfos)
                .HasForeignKey(d => d.StudentDetailId)
                .HasConstraintName("FK__Feesinfo__Studen__2B0A656D");

            entity.HasOne(d => d.StudentRegistration).WithMany(p => p.Feesinfos)
                .HasForeignKey(d => d.StudentRegistrationId)
                .HasConstraintName("FK__Feesinfo__Studen__208CD6FA");
        });

        modelBuilder.Entity<Frui>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__frui__3214EC07AC4FAF8A");

            entity.ToTable("frui");

            entity.Property(e => e.Details)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Year)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GeneralNews>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__generalN__3214EC07436AF568");

            entity.ToTable("generalNews");

            entity.Property(e => e.Author)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Date)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Details)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("details");
            entity.Property(e => e.HealLine)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Logo)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IndexHome>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__indexHom__3214EC07155C8B84");

            entity.ToTable("indexHome");

            entity.Property(e => e.Details)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("details");
            entity.Property(e => e.Logo)
                .HasMaxLength(900)
                .IsUnicode(false)
                .HasColumnName("logo");
            entity.Property(e => e.SubTitle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("subTitle");
        });

        modelBuilder.Entity<Leave>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Leave__3214EC27DD0ECC38");

            entity.ToTable("Leave");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Approved)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("approved");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Reason)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("reason");
            entity.Property(e => e.StudentDetailId).HasColumnName("StudentDetailID");
            entity.Property(e => e.Usn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USN");

            entity.HasOne(d => d.StudentDetail).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.StudentDetailId)
                .HasConstraintName("FK__Leave__StudentDe__4F47C5E3");
        });

        modelBuilder.Entity<LeaveStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeaveSta__3214EC0794705637");

            entity.ToTable("LeaveStatus");

            entity.Property(e => e.Isdeleted).HasColumnName("ISdeleted");
            entity.Property(e => e.LeaveId).HasColumnName("LeaveID");

            entity.HasOne(d => d.Leave).WithMany(p => p.LeaveStatuses)
                .HasForeignKey(d => d.LeaveId)
                .HasConstraintName("FK__LeaveStat__Leave__540C7B00");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__login__3214EC2787A064B5");

            entity.ToTable("login");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<MarksEntry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MarksEnt__3214EC27294BB9CD");

            entity.ToTable("MarksEntry");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExamId).HasColumnName("ExamID");
            entity.Property(e => e.Marks)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PassingMarks)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("passingMarks");
            entity.Property(e => e.RegistrationId).HasColumnName("RegistrationID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.StudentDetailId).HasColumnName("StudentDetailID");
            entity.Property(e => e.StudentRegistrationId).HasColumnName("StudentRegistrationID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.TotalMakes)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Exam).WithMany(p => p.MarksEntries)
                .HasForeignKey(d => d.ExamId)
                .HasConstraintName("FK__MarksEntr__ExamI__3E52440B");

            entity.HasOne(d => d.Registration).WithMany(p => p.MarksEntries)
                .HasForeignKey(d => d.RegistrationId)
                .HasConstraintName("FK__MarksEntr__Regis__3D5E1FD2");

            entity.HasOne(d => d.Role).WithMany(p => p.MarksEntries)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__MarksEntr__RoleI__4AB81AF0");

            entity.HasOne(d => d.StudentDetail).WithMany(p => p.MarksEntries)
                .HasForeignKey(d => d.StudentDetailId)
                .HasConstraintName("FK__MarksEntr__Stude__29221CFB");

            entity.HasOne(d => d.StudentRegistration).WithMany(p => p.MarksEntries)
                .HasForeignKey(d => d.StudentRegistrationId)
                .HasConstraintName("FK__MarksEntr__Stude__1DB06A4F");

            entity.HasOne(d => d.Subject).WithMany(p => p.MarksEntries)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__MarksEntr__Subje__25518C17");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__News__3214EC075BBD9D13");

            entity.Property(e => e.Details)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OurTeam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ourTeam__3214EC07D9BCEF10");

            entity.ToTable("ourTeam");

            entity.Property(e => e.ShopOwnerSlidshow)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SlidShowLogo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("slidShowLogo");
            entity.Property(e => e.SlidshowWithName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("slidshowWithName");
            entity.Property(e => e.TeamMamberName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("teamMamberName");
            entity.Property(e => e.TeamMamberProfile)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("teamMamberProfile");
            entity.Property(e => e.TeamMemberLogo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("teamMemberLogo");
            entity.Property(e => e.TeamTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("teamTitle");
            entity.Property(e => e.TeanDetails)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("teanDetails");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product__3214EC07C130C0F5");

            entity.ToTable("product");

            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.ProdecuName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("prodecuName");
            entity.Property(e => e.ProductCart)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("productCart");
            entity.Property(e => e.ProductDetails)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("productDetails");
            entity.Property(e => e.ProductPrice)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("productPrice");
        });

        modelBuilder.Entity<ProductBrand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__ProductB__DAD4F05E2D221B0B");

            entity.ToTable("ProductBrand");

            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.ProductBrands)
                .HasForeignKey(d => d.ProductCategoryId)
                .HasConstraintName("FK__ProductBr__Produ__1332DBDC");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.ProductBrands)
                .HasForeignKey(d => d.SubCategoryId)
                .HasConstraintName("FK__ProductBr__SubCa__14270015");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductC__3214EC2783F519B7");

            entity.ToTable("ProductCategory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductColor>(entity =>
        {
            entity.HasKey(e => e.Productcolorid).HasName("PK__ProductC__1AFE8354CD6E1E87");

            entity.ToTable("ProductColor");

            entity.Property(e => e.Colorid).HasColumnName("colorid");
            entity.Property(e => e.ProductEntryid).HasColumnName("productEntryid");

            entity.HasOne(d => d.Color).WithMany(p => p.ProductColors)
                .HasForeignKey(d => d.Colorid)
                .HasConstraintName("FK__ProductCo__color__70DDC3D8");

            entity.HasOne(d => d.ProductEntry).WithMany(p => p.ProductColors)
                .HasForeignKey(d => d.ProductEntryid)
                .HasConstraintName("FK__ProductCo__produ__6FE99F9F");
        });

        modelBuilder.Entity<ProductEntry>(entity =>
        {
            entity.HasKey(e => e.ProductEntryid).HasName("PK__ProductE__6033052C7C533001");

            entity.ToTable("ProductEntry");

            entity.Property(e => e.ProductEntryid).HasColumnName("productEntryid");
            entity.Property(e => e.ActualPrice).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.CurrentPrice).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Descriptions).IsUnicode(false);
            entity.Property(e => e.Discount)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

            entity.HasOne(d => d.Brand).WithMany(p => p.ProductEntries)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__ProductEn__Brand__6754599E");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.ProductEntries)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__ProductEntry__ID__66603565");

            entity.HasOne(d => d.Model).WithMany(p => p.ProductEntries)
                .HasForeignKey(d => d.Modelid)
                .HasConstraintName("FK__ProductEn__Model__68487DD7");

            entity.HasOne(d => d.Serise).WithMany(p => p.ProductEntries)
                .HasForeignKey(d => d.Seriseid)
                .HasConstraintName("FK__ProductEn__Seris__693CA210");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.ProductEntries)
                .HasForeignKey(d => d.SubCategoryId)
                .HasConstraintName("FK__ProductEn__SubCa__123EB7A3");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.ProductImageid).HasName("PK__ProductI__AD7F0DA0919DD7D0");

            entity.ToTable("ProductImage");

            entity.Property(e => e.ProductImageid).HasColumnName("productImageid");
            entity.Property(e => e.ImageName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ProductEntryid).HasColumnName("productEntryid");

            entity.HasOne(d => d.ProductEntry).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductEntryid)
                .HasConstraintName("FK__ProductIm__produ__73BA3083");
        });

        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.HasKey(e => e.Modelid).HasName("PK__ProductM__E8D4A54480A3C84E");

            entity.ToTable("ProductModel");

            entity.Property(e => e.ModelName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

            entity.HasOne(d => d.Brand).WithMany(p => p.ProductModels)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__ProductMo__Brand__5CD6CB2B");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.ProductModels)
                .HasForeignKey(d => d.SubCategoryId)
                .HasConstraintName("FK__ProductMo__SubCa__10566F31");
        });

        modelBuilder.Entity<ProductSerise>(entity =>
        {
            entity.HasKey(e => e.Seriseid).HasName("PK__ProductS__01AE896249CC2801");

            entity.ToTable("ProductSerise");

            entity.Property(e => e.BrandId).HasColumnName("brandID");
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.SeriseNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

            entity.HasOne(d => d.Brand).WithMany(p => p.ProductSerises)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__ProductSe__brand__160F4887");

            entity.HasOne(d => d.Model).WithMany(p => p.ProductSerises)
                .HasForeignKey(d => d.Modelid)
                .HasConstraintName("FK__ProductSe__Model__5FB337D6");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.ProductSerises)
                .HasForeignKey(d => d.ProductCategoryId)
                .HasConstraintName("FK__ProductSe__Produ__151B244E");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.ProductSerises)
                .HasForeignKey(d => d.SubCategoryId)
                .HasConstraintName("FK__ProductSe__SubCa__114A936A");
        });

        modelBuilder.Entity<ProductSize>(entity =>
        {
            entity.HasKey(e => e.ProductSizeid).HasName("PK__ProductS__9DAEF96953B104D4");

            entity.ToTable("ProductSize");

            entity.Property(e => e.ProductEntryid).HasColumnName("productEntryid");
            entity.Property(e => e.Sizeid).HasColumnName("sizeid");

            entity.HasOne(d => d.ProductEntry).WithMany(p => p.ProductSizes)
                .HasForeignKey(d => d.ProductEntryid)
                .HasConstraintName("FK__ProductSi__produ__6C190EBB");

            entity.HasOne(d => d.Size).WithMany(p => p.ProductSizes)
                .HasForeignKey(d => d.Sizeid)
                .HasConstraintName("FK__ProductSi__sizei__6D0D32F4");
        });

        modelBuilder.Entity<ProductTitle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__productT__3214EC07181CD5FC");

            entity.ToTable("productTitle");

            entity.Property(e => e.ProductDetails)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("productDetails");
            entity.Property(e => e.ProductMainTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("productMainTitle");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Registra__3214EC275A0D60BD");

            entity.ToTable("Registration");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Registrat__RoleI__267ABA7A");
        });

        modelBuilder.Entity<ResultEntry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ResultEn__3214EC27BA2F7740");

            entity.ToTable("ResultEntry");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExamId).HasColumnName("ExamID");
            entity.Property(e => e.MarksEntryId).HasColumnName("MarksEntryID");
            entity.Property(e => e.PassingMarks)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("passingMarks");
            entity.Property(e => e.RegistrationId).HasColumnName("RegistrationID");
            entity.Property(e => e.Result)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.StudentDetailId).HasColumnName("StudentDetailID");
            entity.Property(e => e.StudentRegistrationId).HasColumnName("StudentRegistrationID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.TotalMakes)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Exam).WithMany(p => p.ResultEntries)
                .HasForeignKey(d => d.ExamId)
                .HasConstraintName("FK__ResultEnt__ExamI__4222D4EF");

            entity.HasOne(d => d.MarksEntry).WithMany(p => p.ResultEntries)
                .HasForeignKey(d => d.MarksEntryId)
                .HasConstraintName("FK__ResultEnt__Marks__4316F928");

            entity.HasOne(d => d.Registration).WithMany(p => p.ResultEntries)
                .HasForeignKey(d => d.RegistrationId)
                .HasConstraintName("FK__ResultEnt__Regis__412EB0B6");

            entity.HasOne(d => d.Role).WithMany(p => p.ResultEntries)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__ResultEnt__RoleI__49C3F6B7");

            entity.HasOne(d => d.StudentDetail).WithMany(p => p.ResultEntries)
                .HasForeignKey(d => d.StudentDetailId)
                .HasConstraintName("FK__ResultEnt__Stude__2A164134");

            entity.HasOne(d => d.StudentRegistration).WithMany(p => p.ResultEntries)
                .HasForeignKey(d => d.StudentRegistrationId)
                .HasConstraintName("FK__ResultEnt__Stude__1EA48E88");

            entity.HasOne(d => d.Subject).WithMany(p => p.ResultEntries)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__ResultEnt__Subje__245D67DE");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A2D41A418");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Isdeleted).HasColumnName("ISdeleted");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RoleCreation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoleCrea__3214EC278B9CA8DD");

            entity.ToTable("RoleCreation");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.Sizeid).HasName("PK__size__55B2E17F15219217");

            entity.ToTable("size");

            entity.Property(e => e.Sizeid).HasColumnName("sizeid");
            entity.Property(e => e.SizeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__State__3214EC2735E690A8");

            entity.ToTable("State");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ShortName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__State__CountryID__4F7CD00D");
        });

        modelBuilder.Entity<StudentAttendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__studentA__3214EC27E7B86B4D");

            entity.ToTable("studentAttendance");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Attendance)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.Date)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StudentDetailId).HasColumnName("StudentDetailID");

            entity.HasOne(d => d.StudentDetail).WithMany(p => p.StudentAttendances)
                .HasForeignKey(d => d.StudentDetailId)
                .HasConstraintName("FK__studentAt__Stude__2FCF1A8A");
        });

        modelBuilder.Entity<StudentDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentD__3214EC27A0F30F56");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Attendance)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Class)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MarksId).HasColumnName("MarksID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.Usn)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Marks).WithMany(p => p.StudentDetails)
                .HasForeignKey(d => d.MarksId)
                .HasConstraintName("FK__StudentDe__Marks__43D61337");

            entity.HasOne(d => d.ResultEntry).WithMany(p => p.StudentDetails)
                .HasForeignKey(d => d.ResultEntryid)
                .HasConstraintName("FK__StudentDe__Resul__3E1D39E1");

            entity.HasOne(d => d.Role).WithMany(p => p.StudentDetails)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__StudentDe__RoleI__48CFD27E");

            entity.HasOne(d => d.Subject).WithMany(p => p.StudentDetails)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__StudentDe__Subje__3D2915A8");
        });

        modelBuilder.Entity<StudentRegistration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentR__3214EC27100A9BF9");

            entity.ToTable("StudentRegistration");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AadharCard)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.StudentUsn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("StudentUSN");

            entity.HasOne(d => d.Role).WithMany(p => p.StudentRegistrations)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__StudentRe__RoleI__1CBC4616");
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubCateg__3213E83F75FC0DBA");

            entity.ToTable("SubCategory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Icon)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.ProductCategoryId)
                .HasConstraintName("FK__SubCatego__Produ__0F624AF8");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__subject__3214EC27707DCC46");

            entity.ToTable("subject");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SubjectTakenByTeacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubjectT__3214EC27166D3638");

            entity.ToTable("SubjectTakenByTeacher");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RegistrationId).HasColumnName("RegistrationID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TeacherDetailsId).HasColumnName("TeacherDetailsID");
            entity.Property(e => e.Time)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Registration).WithMany(p => p.SubjectTakenByTeachers)
                .HasForeignKey(d => d.RegistrationId)
                .HasConstraintName("FK__SubjectTa__Regis__2E1BDC42");

            entity.HasOne(d => d.Role).WithMany(p => p.SubjectTakenByTeachers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__SubjectTa__RoleI__47DBAE45");

            entity.HasOne(d => d.Subject).WithMany(p => p.SubjectTakenByTeachers)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__SubjectTa__Subje__2645B050");

            entity.HasOne(d => d.TeacherDetails).WithMany(p => p.SubjectTakenByTeachers)
                .HasForeignKey(d => d.TeacherDetailsId)
                .HasConstraintName("FK__SubjectTa__Teach__2739D489");
        });

        modelBuilder.Entity<TeacherDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeacherD__3214EC277DC4AA27");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Attendance)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Geander)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.JoiningDate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Qulification)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationId).HasColumnName("RegistrationID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.TotalLeaves)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Registration).WithMany(p => p.TeacherDetails)
                .HasForeignKey(d => d.RegistrationId)
                .HasConstraintName("FK__TeacherDe__Regis__2B3F6F97");

            entity.HasOne(d => d.Role).WithMany(p => p.TeacherDetails)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__TeacherDe__RoleI__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

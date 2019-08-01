using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarServiceAPP.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public override string Email { get => base.Email; set => base.Email = value; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile Number is Mandatory")]
        [RegularExpression(@"^(?:(?:\+|0{0,2})91(\s*[\ -]\s*)?|[0]?)?[789]\d{9}|(\d[ -]?){10}\d$", ErrorMessage = "Enter valid Mobile Number")]
        [Display(Name = "Mobile")]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Mandatory")]
        [RegularExpression(@"([A-Z][a-z]*)([\\s\\\'-][A-Z][a-z]*)*", ErrorMessage = "Enter valid First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Mandatory")]
        [RegularExpression(@"([A-Z][a-z]*)([\\s\\\'-][A-Z][a-z]*)*", ErrorMessage = "Enter valid Last Name")]
        [Display(Name = "Last Name")]
        public string LastName  { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City is Mandatory")]
        [RegularExpression(@"^([a-zA-Z\u0080-\u024F]+(?:. |-| |'))*[a-zA-Z\u0080-\u024F]*$", ErrorMessage = "Enter valid City Name")]
        public string City { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public DbSet<Car> Cars { get; set; }

		public DbSet<Service> Services { get; set; }

        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarStyle> CarStyles { get; set; }

        public DbSet<ServiceType> ServiceTypes { get; set; }

        //public DbSet<ApplicationUser> Users { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
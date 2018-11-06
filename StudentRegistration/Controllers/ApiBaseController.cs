using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data;

namespace StudentRegistration.Controllers
{
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        public static StudentRegistrationContext InitializeDb()
        {   
            var optionsBuilder = new DbContextOptionsBuilder<StudentRegistrationContext>();
            return new StudentRegistrationContext(optionsBuilder.Options);
        }
    }
}
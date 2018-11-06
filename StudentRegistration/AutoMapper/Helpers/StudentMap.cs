using AutoMapper;
using StudentRegistration.Models;
using StudentRegistration.ViewModels;

namespace StudentRegistration.AutoMapper.Helpers
{
    public class StudentMap
    {
        private readonly IMapper _mapper;

        public StudentMap(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Student Map(StudentViewModel env)
        {
            var student = _mapper.Map<StudentViewModel, Student>(env);

            return student;
        }
    }
}
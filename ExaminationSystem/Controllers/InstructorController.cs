﻿using ExaminationSystem.Services.Instructors;
using ExaminationSystem.Services.InstructorStudents;
using ExaminationSystem.ViewModels.Courses;
using ExaminationSystem.ViewModels.Instructors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        IInstructorService _instructorService;
        IInstructorCourseService _instructorCourseService;
        public InstructorController(IInstructorService instructorService , IInstructorCourseService instructorCourseService)
        {
            _instructorService = instructorService;
            _instructorCourseService = instructorCourseService;
        }

        [HttpPost]
        public IActionResult Create(InstructorCreateViewModel viewModel)
        {
            _instructorService.Add(viewModel);

            return Ok();
        }

        [HttpGet]
        public IEnumerable<InstructorViewModel> Get()
        {
            return _instructorService.GetAll();
        }


        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var instructor = _instructorService.GetByID(id);
            if (instructor is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(instructor);
            }
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _instructorService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int id, InstructorEditViewModel viewModel)
        {
            _instructorService.Update(id, viewModel);
            return Ok();
        }

        [HttpGet("Courses")]
        public IEnumerable<CourseViewModel> GetCourses(int instructorID)
        {
            return _instructorCourseService.GetCourses(instructorID);
        }

    }
}

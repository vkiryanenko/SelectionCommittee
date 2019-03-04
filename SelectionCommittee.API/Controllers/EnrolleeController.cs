﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.API.Models.Enrollees;
using SelectionCommittee.BLL.Enrollees;
using SelectionCommittee.BLL.Enrollees.Services;
using SelectionCommittee.DAL.EF;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.API.Controllers
{
    [Route("api/[controller]")]
    public class EnrolleeController : Controller
    {
        private readonly IEnrolleeService _enrolleeService;
        private readonly IMapper _mapper;

        private ApplicationDbContext _context;

        public EnrolleeController(ApplicationDbContext context, IEnrolleeService enrolleeService, IMapper mapper)
        {
            _enrolleeService = enrolleeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var enrolleeDto = await _enrolleeService.GetAllAsync();
            var enrolleeModel = _mapper.Map<IEnumerable<EnrolleeModel>>(enrolleeDto);
            return Ok(enrolleeModel);
        }

        [HttpGet("{id}", Name = "GetEnrollee")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var enrolleeDto = await _enrolleeService.GetAsync(id);
            var enrolleeModel = _mapper.Map<EnrolleeModel>(enrolleeDto);
            return Ok(enrolleeModel);
        }
    }
}
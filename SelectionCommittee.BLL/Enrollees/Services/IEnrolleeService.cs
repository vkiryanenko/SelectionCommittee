﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SelectionCommittee.BLL.Assessments;

namespace SelectionCommittee.BLL.Enrollees.Services
{
    public interface IEnrolleeService
    {
        Task<IEnumerable<EnrolleDto>> GetAllAsync();

        Task<EnrolleDto> GetAsync(int id);

        Task<int> AddAsync(EnrolleCreateDto enrolleCreateDto);

        Task<int> AddFacultyEnrolleeAsync(FacultyEnrolleeCreateDto facultyEnrolleeCreateDto);

        Task<int> UpdateAsync(EnrolleeUpdateDto enrolleeUpdateDto);

        Task<int> UpdateStatusAsync(EnrolleeUpdateStatusDto enrolleeUpdateStatusDto);

        Task<int> DeleteAsync(int id);
    }
}
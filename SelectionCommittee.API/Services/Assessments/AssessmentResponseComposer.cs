﻿using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.API.Models.Assessments;
using SelectionCommittee.BLL.Assessments;

namespace SelectionCommittee.API.Services.Assessments
{
    public class AssessmentResponseComposer : IAssessmentResponseComposer
    {
        private readonly IMapper _mapper;

        public AssessmentResponseComposer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ActionResult ComposeForGetAll(IEnumerable<AssessmentDto> assessmentDtos)
        {
            var assessmentModels = _mapper.Map<IEnumerable<AssessmentModel>>(assessmentDtos);
            return new OkObjectResult(assessmentModels);
        }

        public ActionResult ComposeForGet(AssessmentDto assessmentDto)
        {
            if (assessmentDto == null)
                return new NotFoundResult();

            var assessmentModel = _mapper.Map<AssessmentModel>(assessmentDto);
            return new OkObjectResult(assessmentModel);
        }

        public ActionResult ComposeForCreate(int statusCode, AssessmentCreateDto assessmentCreateDto)
        {
            switch (statusCode)
            {
                case -1:
                    return new BadRequestObjectResult("Invalid assessment name.");
                case -2:
                    return new BadRequestObjectResult("Invalid assessment grade type.");
                case -3:
                    return new BadRequestObjectResult("Invalid assessment grade.");
                default:
                    return new CreatedAtRouteResult("Get assessment", new { Id = statusCode }, assessmentCreateDto);
            }
        }

        public ActionResult ComposeForUpdate(int statusCode)
        {
            switch (statusCode)
            {
                case -1:
                    return new BadRequestObjectResult("Invalid assessment name.");
                case -2:
                    return new BadRequestObjectResult("Invalid assessment grade type.");
                case -3:
                    return new BadRequestObjectResult("Invalid assessment grade.");
                default:
                    return new OkResult();
            }
        }

        public ActionResult ComposeForDelete(int statusCode)
        {
            switch (statusCode)
            {
                case -4:
                    return new NotFoundResult();
                default:
                    return new NoContentResult();
            }
        }
    }
}
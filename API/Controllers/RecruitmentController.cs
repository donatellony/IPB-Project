using System;
using System.Collections.Generic;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecruitmentController : ControllerBase
    {
        private static readonly List<Invitation> TestInvitations = new();

        [HttpGet]
        public ActionResult<string[]> GetSchools()
        {
            return Ok(Enum.GetNames<SchoolType>());
        }

        [HttpPost("{school}/{name}")]
        public ActionResult<string> CreateInvitation(SchoolType school, string name)
        {
            var invitation = new Invitation {School = school, Name = name};
            TestInvitations.Add(invitation);
            return Ok();
        }

        [HttpGet("{name}")]
        public ActionResult<string> GetInvitation(string name)
        {
            return Ok(TestInvitations.Find(e => e.Name.Equals(name))?.GetInvitationText());
        }
    }
}
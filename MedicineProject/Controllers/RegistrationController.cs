using MedicineProject.Context;
using MedicineProject.DTOs;
using MedicineProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace MedicineProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ApplicationContext context;

        public RegistrationController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [Route("RegistrationPatient")]
        public async Task<ActionResult<PatientDTO>> RegistrationAsPatient(PatientDTO dto)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(dto.Email));
            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i]);
            }
            dto.Email = sb.ToString();

            hash = SHA256.HashData(Encoding.UTF8.GetBytes(dto.Password));
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i]);
            }
            dto.Password = sb.ToString();
            sb.Clear();

            Patient patient = new Patient(dto);
            context.Patient.Add(patient);
            await context.SaveChangesAsync();
            dto.Id = patient.Id;

            return Ok(dto);
        }
    }
}

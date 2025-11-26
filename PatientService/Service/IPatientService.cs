using PatientService.DTOs;

namespace PatientService.Service
{
    public interface IPatientService
    {
        Task<PatientResponseDto> CreatePatient(PatientCreateDto dto);
        Task<PatientResponseDto> GetPatient(int id);
        Task<IEnumerable<PatientResponseDto>> GetAllPatients();
        Task<PatientResponseDto> UpdatePatient(int id, PatientUpdateDto dto);
        Task<PatientResponseDto> GetByEmail(string email);
        Task DeletePatient(int id);
        Task<AuthResponseDto> AuthValidate(string Email, string PassHash);
        Task<string> UploadProfileImage(int id, IFormFile imageProfile);
    }
}

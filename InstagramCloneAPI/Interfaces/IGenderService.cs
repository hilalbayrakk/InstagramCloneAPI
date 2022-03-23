using InstagramCloneAPI.Model;

namespace InstagramCloneAPI.Interfaces
{
    public interface IGenderService
    {
        
        Task<Gender> AddGender(Gender gender);
        Task<Gender> UpdateGender(Gender gender, int genderId);
        Task DeleteGender(Gender gender);
        Task<List<Gender>> GetAllGender();
        Task<Gender>GetGenderById(int genderId);
        Task<List<Gender>>GetGenderByName(string genderName);
        Task<List<Gender>>GetGenderByUserId(int userId);
    }
}
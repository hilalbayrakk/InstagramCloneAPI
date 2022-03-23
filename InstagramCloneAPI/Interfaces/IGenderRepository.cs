using InstagramCloneAPI.Model;

namespace InstagramCloneAPI.Interfaces
{
    public interface IGenderRepository
    {

        Task<Gender> AddGender(Gender gender);
        Task<Gender> UpdateGender(Gender gender);
        Task DeleteGender(Gender gender);
        Task<List<Gender>> GetAllGender();
        Task<Gender>GetGenderById(int genderId);
        Task<List<Gender>>GetGenderByName(string genderName);
        Task<List<Gender>>GetGenderByUserId(int userId);
    }
}
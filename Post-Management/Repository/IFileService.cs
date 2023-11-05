namespace AspnetIdentityRoleBasedTutorial.Services
{
    public interface IFileService
    {
        Tuple<int, byte[], string> SaveImage(IFormFile imageFile);
        public bool DeleteImage(string imageFileName);
    }
}

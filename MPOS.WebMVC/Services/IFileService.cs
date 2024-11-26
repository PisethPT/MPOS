namespace MPOS.WebMVC.Controllers
{
	public interface IFileService
	{
		Tuple<string> GetFile(IFormFile path);
	}
}

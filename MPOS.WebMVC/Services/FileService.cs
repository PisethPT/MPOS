
namespace MPOS.WebMVC.Controllers
{
	public class FileService : IFileService
	{
		private readonly IWebHostEnvironment environment;

		public FileService(IWebHostEnvironment environment)
		{
			this.environment = environment;
		}
		public Tuple<string> GetFile(IFormFile path)
		{
			if (path.Length > 0)
			{
				try
				{
					var contentPath = environment.WebRootPath + "\\Images\\";
					var fileName = Guid.NewGuid().ToString() +"_"+ path.FileName;
					if (!Directory.Exists(contentPath))
					{
						Directory.CreateDirectory(contentPath);
					}
					using (FileStream fileStream = File.Create(contentPath + fileName))
					{
						path.CopyTo(fileStream);
						fileStream.Flush();
						return new Tuple<string>(fileName);
					}
				}
				catch (Exception ex)
				{
					return new Tuple<string>(ex.Message);
				}
			}
			else
				return new Tuple<string>("Upload Fielded.");
		}
	}
}

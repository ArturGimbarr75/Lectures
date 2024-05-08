using _044_Les_Files_V2.Models;
using _044_Les_Files_V2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace _044_Les_Files_V2.Controllers;
[ApiController]
[Route("[controller]")]
public class ImagesController : ControllerBase
{
	private readonly ApplicationDbContext _context;
	private readonly IWebHostEnvironment _environment;

	public ImagesController(ApplicationDbContext context, IWebHostEnvironment environment)
	{
		_context = context;
		_environment = environment;
	}

	[HttpPost("upload")]
	public async Task<IActionResult> Upload(IFormFile file)
	{
		if (file.Length == 0)
			return BadRequest("Empty file");

		using var memoryStream = new MemoryStream();
		await file.CopyToAsync(memoryStream);
		var imageData = memoryStream.ToArray();

		var image = new Models.Image { Filename = file.FileName, Data = imageData };
		_context.Images.Add(image);
		await _context.SaveChangesAsync();

		memoryStream.Seek(0, SeekOrigin.Begin);
		var thumbnailData = CreateThumbnail(memoryStream);
		var thumbnail = new Thumbnail { ImageId = image.Id, Data = thumbnailData };
		_context.Thumbnails.Add(thumbnail);
		await _context.SaveChangesAsync();

		return Ok(new { ImageId = image.Id, ThumbnailId = thumbnail.Id });
	}

	private byte[] CreateThumbnail(Stream imageStream)
	{
		var image = SixLabors.ImageSharp.Image.Load(imageStream);
		image.Mutate(x => x.Resize(150, 150));
		using var resultStream = new MemoryStream();
		image.SaveAsJpeg(resultStream);
		return resultStream.ToArray();
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetImage(int id)
	{
		var image = await _context.Images.FindAsync(id);
		if (image == null)
			return NotFound();

		return File(image.Data, "image/jpeg");
	}

	[HttpGet("thumbnail/{id}")]
	public async Task<IActionResult> GetThumbnail(int id)
	{
		var thumbnail = await _context.Thumbnails.FirstOrDefaultAsync(t => t.ImageId == id);
		if (thumbnail == null)
			return NotFound();

		return File(thumbnail.Data, "image/jpeg");
	}
}

using Microsoft.AspNetCore.Mvc;
using NoteExam.DTO;
using NoteExam.Models;
using NoteExam.Persistence.Repositories;
using NoteExam.Service.AuthServices;

namespace NoteExam.Service.NoteServices;

public class NoteService : INoteService
{
	private readonly INoteRepository _noteRepository;
	private readonly ICategoryRepository _categoryRepository;
	private readonly IUserRepository _userRepository;
	private readonly ITokenService _tokenService;

	public NoteService( INoteRepository noteRepository, ITokenService tokenService,
						IUserRepository userRepository, ICategoryRepository categoryRepository)
	{
		_noteRepository = noteRepository;
		_tokenService = tokenService;
		_userRepository = userRepository;
		_categoryRepository = categoryRepository;
	}

	public async Task<ActionResult<Note>> AddNoteAsync(string jwt, NoteDto note)
	{
		if (string.IsNullOrWhiteSpace(jwt))
		{
			return new BadRequestObjectResult("JWT is required");
		}

		if (note is null)
		{
			return new BadRequestObjectResult("Note is required");
		}

		if (!_tokenService.IsTokenValid(jwt))
		{
			return new UnauthorizedObjectResult("Invalid JWT");
		}

		var (userId, expirationDate) = _tokenService.GetTokenIdAndExpirationDate(jwt);

		if (userId is null || expirationDate is null)
		{
			return new UnauthorizedObjectResult("Invalid refresh token");
		}

		if (expirationDate < DateTime.UtcNow)
		{
			return new UnauthorizedObjectResult("Refresh token expired");
		}

		User? existingUser = await _userRepository.GetUserByIdAsync(userId.Value);

		if (existingUser is null)
		{
			return new NotFoundObjectResult("User not found");
		}

		if (note.CategoryId is not null)
		{
			if (await _categoryRepository.GetCategoryByIdAsync(note.CategoryId.Value) is null)
				return new NotFoundObjectResult("Category not found");

			if (!await _categoryRepository.IsUserOwnsCategoryAsync(userId.Value, note.CategoryId.Value))
				return new UnauthorizedObjectResult("User does not own the category");
		}

		Note newNote = new()
		{
			CategoryId = note.CategoryId,
			UserId = userId.Value,
			User = existingUser,
			Title = note.Title,
			Content = note.Content,
			CreatedAt = DateTime.UtcNow,
			UpdatedAt = DateTime.UtcNow
		};

		Note? addedNote = await _noteRepository.AddNoteAsync(newNote);

		if (addedNote is null)
		{
			return new StatusCodeResult(500);
		}

		return addedNote;
	}

	public async Task<ActionResult> DeleteNoteAsync(string jwt, Guid noteId)
	{
		if (string.IsNullOrWhiteSpace(jwt))
		{
			return new BadRequestObjectResult("JWT is required");
		}

		if (!_tokenService.IsTokenValid(jwt))
		{
			return new UnauthorizedObjectResult("Invalid JWT");
		}

		var (userId, expirationDate) = _tokenService.GetTokenIdAndExpirationDate(jwt);

		if (userId is null || expirationDate is null)
		{
			return new UnauthorizedObjectResult("Invalid refresh token");
		}

		if (expirationDate < DateTime.UtcNow)
		{
			return new UnauthorizedObjectResult("Refresh token expired");
		}

		User? existingUser = await _userRepository.GetUserByIdAsync(userId.Value);

		if (existingUser is null)
		{
			return new NotFoundObjectResult("User not found");
		}

		if (!await _noteRepository.IsUserOwnsNoteAsync(userId.Value, noteId))
		{
			return new UnauthorizedObjectResult("User does not own the note");
		}

		if (!await _noteRepository.DeleteNoteAsync(noteId))
		{
			return new StatusCodeResult(500);
		}

		return new OkResult();
	}

	public async Task<ActionResult<Note>> GetNoteByIdAsync(string jwt, Guid noteId)
	{
		if (string.IsNullOrWhiteSpace(jwt))
		{
			return new BadRequestObjectResult("JWT is required");
		}

		if (!_tokenService.IsTokenValid(jwt))
		{
			return new UnauthorizedObjectResult("Invalid JWT");
		}

		var (userId, expirationDate) = _tokenService.GetTokenIdAndExpirationDate(jwt);

		if (userId is null || expirationDate is null)
		{
			return new UnauthorizedObjectResult("Invalid refresh token");
		}

		if (expirationDate < DateTime.UtcNow)
		{
			return new UnauthorizedObjectResult("Refresh token expired");
		}

		User? existingUser = await _userRepository.GetUserByIdAsync(userId.Value);

		if (existingUser is null)
		{
			return new NotFoundObjectResult("User not found");
		}

		if (!await _noteRepository.IsUserOwnsNoteAsync(userId.Value, noteId))
		{
			return new UnauthorizedObjectResult("User does not own the note");
		}

		Note? note = await _noteRepository.GetNoteByIdAsync(noteId);

		if (note is null)
		{
			return new NotFoundObjectResult("Note not found");
		}

		return note;
	}

	public async Task<ActionResult<IEnumerable<Note>>> GetUserNotesAsync(string jwt)
	{
		if (string.IsNullOrWhiteSpace(jwt))
		{
			return new BadRequestObjectResult("JWT is required");
		}

		if (!_tokenService.IsTokenValid(jwt))
		{
			return new UnauthorizedObjectResult("Invalid JWT");
		}

		var (userId, expirationDate) = _tokenService.GetTokenIdAndExpirationDate(jwt);

		if (userId is null || expirationDate is null)
		{
			return new UnauthorizedObjectResult("Invalid refresh token");
		}

		if (expirationDate < DateTime.UtcNow)
		{
			return new UnauthorizedObjectResult("Refresh token expired");
		}

		User? existingUser = await _userRepository.GetUserByIdAsync(userId.Value);

		if (existingUser is null)
		{
			return new NotFoundObjectResult("User not found");
		}

		var notes = await _noteRepository.GetUserNotesAsync(userId.Value);
		return new ActionResult<IEnumerable<Note>>(notes);
	}

	public async Task<ActionResult<Note>> UpdateNoteAsync(string jwt, Guid noteId, NoteDto note)
	{
		if (string.IsNullOrWhiteSpace(jwt))
		{
			return new BadRequestObjectResult("JWT is required");
		}

		if (note is null)
		{
			return new BadRequestObjectResult("Note is required");
		}

		if (!_tokenService.IsTokenValid(jwt))
		{
			return new UnauthorizedObjectResult("Invalid JWT");
		}

		var (userId, expirationDate) = _tokenService.GetTokenIdAndExpirationDate(jwt);

		if (userId is null || expirationDate is null)
		{
			return new UnauthorizedObjectResult("Invalid refresh token");
		}

		if (expirationDate < DateTime.UtcNow)
		{
			return new UnauthorizedObjectResult("Refresh token expired");
		}

		User? existingUser = await _userRepository.GetUserByIdAsync(userId.Value);

		if (existingUser is null)
		{
			return new NotFoundObjectResult("User not found");
		}

		if (note.CategoryId is not null)
		{
			if (await _categoryRepository.GetCategoryByIdAsync(note.CategoryId.Value) is null)
				return new NotFoundObjectResult("Category not found");

			if (!await _categoryRepository.IsUserOwnsCategoryAsync(userId.Value, note.CategoryId.Value))
				return new UnauthorizedObjectResult("User does not own the category");
		}

		Note? existingNote = await _noteRepository.GetNoteByIdAsync(noteId);

		if (existingNote is null)
		{
			return new NotFoundObjectResult("Note not found");
		}

		if (!await _noteRepository.IsUserOwnsNoteAsync(userId.Value, noteId))
		{
			return new UnauthorizedObjectResult("User does not own the note");
		}

		Note updatedNote = new()
		{
			Id = existingNote.Id,
			CategoryId = note.CategoryId,
			UserId = existingNote.UserId,
			User = existingNote.User,
			Title = note.Title,
			Content = note.Content,
			CreatedAt = existingNote.CreatedAt,
			UpdatedAt = DateTime.UtcNow
		};

		Note? updatedNoteResult = await _noteRepository.UpdateNoteAsync(updatedNote);

		if (updatedNoteResult is null)
		{
			return new StatusCodeResult(500);
		}

		return updatedNoteResult;
	}
}

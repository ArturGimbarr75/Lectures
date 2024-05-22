using Microsoft.EntityFrameworkCore;
using NoteExam.Models;
using NoteExam.Persistence.Context;

namespace NoteExam.Persistence.Repositories.EF;

internal class NoteRepository : INoteRepository
{
	private readonly AppDbContext _context;

	public NoteRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<Note?> AddNoteAsync(Note note)
	{
		try
		{
			await _context.Notes.AddAsync(note);
			await _context.SaveChangesAsync();
			return note;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public async Task<bool> DeleteNoteAsync(Guid id)
	{
		Note? foundNote = await _context.Notes.FindAsync(id);
		if (foundNote is null)
		{
			return false;
		}

		_context.Notes.Remove(foundNote);
		await _context.SaveChangesAsync();
		return true;
	}

	public async Task<Note?> GetNoteByIdAsync(Guid id)
	{
		return await _context.Notes.FindAsync(id);
	}

	public async Task<IEnumerable<Note>> GetUserNotesAsync(Guid userId)
	{
		return await _context.Notes.Where(n => n.UserId == userId).ToListAsync();
	}

	public Task<bool> IsUserOwnsNoteAsync(Guid userId, Guid noteId)
	{
		throw new NotImplementedException();
	}

	public async Task<Note?> UpdateNoteAsync(Note note)
	{
		Note? foundNote = _context.Notes.Find(note.Id);

		if (foundNote is null)
		{
			return null;
		}
		
		_context.Entry(foundNote).CurrentValues.SetValues(note);
		_context.Notes.Update(foundNote);
		await _context.SaveChangesAsync();

		return foundNote;
	}
}

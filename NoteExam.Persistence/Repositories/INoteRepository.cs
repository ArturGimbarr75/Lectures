using NoteExam.Models;

namespace NoteExam.Persistence.Repositories;

public interface INoteRepository
{
	Task<bool> IsUserOwnsNoteAsync(Guid userId, Guid noteId);
	Task<Note?> GetNoteByIdAsync(Guid id);
	Task<IEnumerable<Note>> GetUserNotesAsync(Guid userId);
	Task<Note?> AddNoteAsync(Note note);
	Task<Note?> UpdateNoteAsync(Note note);
	Task<bool> DeleteNoteAsync(Guid id);
}

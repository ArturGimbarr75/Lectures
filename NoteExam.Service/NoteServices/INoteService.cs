using Microsoft.AspNetCore.Mvc;
using NoteExam.DTO;
using NoteExam.Models;

namespace NoteExam.Service.NoteServices;

public interface INoteService
{
	Task<ActionResult<Note>> AddNoteAsync(string jwt, NoteDto note);
	Task<ActionResult<Note>> UpdateNoteAsync(string jwt, Guid noteId, NoteDto note);
	Task<ActionResult> DeleteNoteAsync(string jwt, Guid noteId);
	Task<ActionResult<IEnumerable<Note>>> GetUserNotesAsync(string jwt);
	Task<ActionResult<Note>> GetNoteByIdAsync(string jwt, Guid noteId);
}

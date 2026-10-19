using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WUWA_API.Contracts;
using WUWA_API.DataAccess;
using WUWA_API.Models;

namespace WUWA_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly NotesDbContext _dbContext;
        public NotesController(NotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetNotesRequest request, CancellationToken ct)
        {
            var notesQuery = _dbContext.Notes
                .Where(n => string.IsNullOrWhiteSpace(request.Serch) ||
                n.Title.ToLower().Contains(request.Serch.ToLower()));

            Expression<Func<Note, object>> selectorKey = request.SortItem?.ToLower() switch
            {
                "date" => note => note.CreatedAt,
                "title" => note => note.Title,
                _ => note => note.Id

            };



            notesQuery = request.SortOrder == "desc"
                ? notesQuery.OrderByDescending(selectorKey)
                : notesQuery.OrderBy(selectorKey);

            var noteDtos = await notesQuery
                .Select(n => new NoteDto(n.Id, n.Title, n.Description, n.CreatedAt))
                .ToListAsync(ct);

            return Ok(new GetNotesResponse(noteDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Crerate([FromBody] CreateNoteRequest request, CancellationToken ct)
        {
            var note = new Note(request.Title, request.Description);

            await _dbContext.Notes.AddAsync(note, ct);
            await _dbContext.SaveChangesAsync(ct);

            return Ok();
        }

        
        
    }
}

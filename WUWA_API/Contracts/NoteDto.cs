namespace WUWA_API.Contracts
{
    public record NoteDto(Guid Id, string Title, string Description, DateTime CreateAt);
}

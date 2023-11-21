namespace LinkShorteningSite.Data.Entities;

public class Url : BaseEntity
{
    public string FullUrl { get; set; }
    public string ShortUrl { get; set; }
    public DateTime DateCreated { get; set; }
    public int JumpCounter { get; set; }
}
namespace LinkShorteningSite.Models;

public class UrlViewModel
{
    public int Id { get; set; }
    public string FullUrl { get; set; }
    public string ShortUrl { get; set; }
    public DateTime DateCreated { get; set; }
    public int JumpCounter { get; set; }
}
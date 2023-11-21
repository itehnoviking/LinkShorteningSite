namespace LinkShorteningSite.Models;

public class UrlCreateViewModel
{
    public string FullUrl { get; set; }
    public DateTime DateCreated { get; set; }
    public int JumpCounter { get; set; } = 0;
}
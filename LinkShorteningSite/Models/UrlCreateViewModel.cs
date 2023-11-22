using AutoMapper.Execution;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LinkShorteningSite.Models;

public class UrlCreateViewModel : IValidatableObject
{
    public string FullUrl { get; set; }
    public DateTime DateCreated { get; set; }
    public int JumpCounter { get; set; } = 0;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> validationResults = new List<ValidationResult>();
        string regex = @"(https?:\/\/|ftps?:\/\/|www\.)((?![.,?!;:()]*(\s|$))[^\s]){2,}";

        if (!Regex.IsMatch(FullUrl, regex, RegexOptions.IgnoreCase))
        {
            validationResults.Add(new ValidationResult("FullUrl is not URL",
                new[] { "FullUrl" }));
        }

        return validationResults;
    }
}
using Microsoft.AspNetCore.Http;
namespace CinemaOL.Models
{
    public class VMMovieInfo
    {
        public string txtTitle { get; set; }
        public int ddlStatus { get; set; }
        public string txtDirector { get; set; }
        public string txtCasts { get; set; }
        public string txtReleaseDate { get; set; }
        public string ddlLanguage { get; set; }
        public string ddlIndustry { get; set; }
        public IFormFile fuPoster { get; set; }
    }
}
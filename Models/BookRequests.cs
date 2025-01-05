using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Biblioteca_UniLib.Models
{
    public class BookRequests
    {
        [Key]
        public int Id { get; set; }

        public int BookId { get; set; }

        public bool IsAccepted { get; set; } = false;

        public bool IsReturned { get; set; } = false;

        public string? AcceptedBy { get; set; }

        public string? ReturnedBy { get; set; }

        public DateTime? AcceptedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        public DateTime RequestStartDate { get; set; }

        public DateTime RequestEndDate { get; set; }

        public string? BookTitle { get; set; }

        public string? UserName { get; set; }
    }
}

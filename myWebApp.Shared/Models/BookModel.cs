using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace myWebApp.Shared.Models
{
    public class BookModel
    {
        public Guid Id { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public string state { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NUnitTestWebApis.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Headline { get;set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public virtual Reviewer Reviewer  { get;set;}
        public virtual Book Book { get; set; }
    }
}

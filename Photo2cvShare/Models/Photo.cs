using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Photo2cvShare.Models
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public string Title { get; set; }
        public string ImageMimeType { get; set; }
        [DisplayName("Picture")]
        [MaxLength]
        public byte[] PhotoFile { get; set; }
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Apartment.Application.UseCase.DTO
{
    public class BlogDto : BaseDto
    {

        public string Title { get; set; }
        public string Content { get; set; }
        public string WorkTime { get; set; }
        public string GoogleMap { get; set; }
        public string Adress { get; set; }
        public int FileId { get; set; }
        public string Path {get;set;}
        public string Alt {get;set;}
        public FileDto File { get; set; }
    }

    public class UpdateBlogDto : BaseDto
    {

        public string Title { get; set; }
        public string Content { get; set; }
        public string WorkTime { get; set; }
        public string GoogleMap { get; set; }
        public string Adress { get; set; }
        public int FileId { get; set; }
        public string Path {get;set;}
        public string Alt {get;set;}
        public string FileBase64 { get; set; }
    }

    public class CreateBlogDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string WorkTime { get; set; }
        public string GoogleMap { get; set; }
        public string Adress { get; set; }
        public string FileBase64 { get; set; }
    }
}

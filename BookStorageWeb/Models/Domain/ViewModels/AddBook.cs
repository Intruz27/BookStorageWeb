﻿namespace BookStorageWeb.Models.Domain.ViewModels
{
    public class AddBook
    {

        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public string Location { get; set; }
    }
}

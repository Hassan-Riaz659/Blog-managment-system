﻿using Blog_managment_system.Web.Models.Domain;
using Blog_managment_system.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_managment_system.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ITagRepository tagRepository;
        

        public List<BlogPost> Blogs { get; set; }
        public List<Tag> Tags { get; set; }

        public IndexModel(ILogger<IndexModel> logger,IBlogPostRepository blogPostRepository,
             ITagRepository tagRepository)
        {
            _logger = logger;
            this.blogPostRepository = blogPostRepository;
            this.tagRepository = tagRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            Blogs = (await blogPostRepository.GetAllAsync()).ToList();
            Tags = (await tagRepository.GetAllAsync()).ToList();
            return Page();
        }
    }
}
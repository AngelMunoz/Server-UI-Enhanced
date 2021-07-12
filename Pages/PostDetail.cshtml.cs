using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Enhanced.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;

namespace Enhanced.Pages
{
    public class PostDetailModel : PageModel
    {
        private readonly HttpClient _posts;
        public Post Post { get; private set; }

        public PostDetailModel(IHttpClientFactory factory)
        {
            _posts = factory.CreateClient(nameof(Post));
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Post = await _posts.GetFromJsonAsync<Post>($"posts/{id}");
            return Page();
        }
    }
}

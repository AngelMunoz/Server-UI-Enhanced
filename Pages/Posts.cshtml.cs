using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Enhanced.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Enhanced.Pages
{
    public class PostsModel : PageModel
    {
        private readonly HttpClient _http;

        public IEnumerable<Post> Posts { get; private set; }
        public int PageNum { get; private set; } = 1;
        public int PageSize { get; private set; } = 100;

        public PostsModel(IHttpClientFactory factory)
        {
            _http = factory.CreateClient(nameof(Post));
        }

        public async Task<IActionResult> OnGetAsync(int pageNum = 1, int pageSize = 100)
        {
            PageNum = pageNum;
            PageSize = pageSize;

            Posts = await _http.GetFromJsonAsync<IEnumerable<Post>>($"posts?_page={PageNum}&_limit={pageSize}");
            return Page();
        }
    }
}

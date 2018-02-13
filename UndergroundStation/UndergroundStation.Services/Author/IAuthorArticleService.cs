using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UndergroundStation.Data.Models.Enums;

namespace UndergroundStation.Services.Author
{
    public interface IAuthorArticleService
    {
        Task<bool> CreateAsync(string title, string content, string imageUrl, string videoUrl, ArticleType type);
    }
}

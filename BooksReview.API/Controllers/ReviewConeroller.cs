using BooksReview.BL.Interfaces;
using BooksReview.Common.Enums;
using BooksReview.Common;
using BooksReview.Common.Models;
using BooksReview.Common.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;

namespace BooksReview.API.Controllers
{
    [AuthenPermission]
    public class ReviewController : BaseController<Review>
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(reviewService, httpContextAccessor, userTokenService)
        {
            _reviewService = reviewService;
        }

        
        [HttpPost]
        [Route("GetReviewPost")]
        public virtual IActionResult GetReviewPost([FromBody] PagingModel paramFilter)
        {
            try
            {
                // Xử lý
                var result = _reviewService.GetReviewPost(paramFilter);

                // Trả về thông tin của employee muốn lấy
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }
    }
}

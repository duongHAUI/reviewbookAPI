using BooksReview.Common.Constants;
using BooksReview.Common;
using BooksReview.Common.Enums;
using BooksReview.Common.Models;
using BooksReview.Common.Models.DTO;
using BooksReview.DL.Database;
using BooksReview.DL.Interfaces;
using Dapper;
using static Dapper.SqlMapper;
using System.Data;
using System.Reflection;

namespace BooksReview.DL.Repository
{
    public class ReviewDL : BaseDL<Review>, IReviewDL
    {
        private readonly IBaseDL<ReviewBookUser> _reviewBookUserDL;
        public ReviewDL(IBaseDL<ReviewBookUser> reviewBookUserDL, IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
            _reviewBookUserDL = reviewBookUserDL;
        }
        public override void CustomAfterInsert(Review review)
        {
            var reviewBookUser = new ReviewBookUser()
            {
                user_id = review.user_id,
                book_id= review.book_id,
                created_at= DateTime.Now,
                modified_at= DateTime.Now,
                rating= review.rating
            };
            _reviewBookUserDL.Insert(reviewBookUser, true);
        }

        public object GetReviewPost(PagingModel parametersFilter)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetReviewPost, tableName);

                var parameters = new DynamicParameters();
                foreach (PropertyInfo propertyInfo in parametersFilter.GetType().GetProperties())
                {
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(parametersFilter));
                }

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryMultiple(storedProducedureName, parameters, commandType: CommandType.StoredProcedure);
                var reviewPost = result.Read<ReviewPost>().ToList();
                // Đóng kết nối
                _databaseConnection.Close();

                return reviewPost;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
    }
}

using LordDesign.Utilities;
using System.Collections.Generic;
using System.Globalization;

namespace ShelfSort
{
    using System;

    public class GoodreadsWrapper
    {
        private readonly ApiCall _call = new ApiCall();

        public ICollection<ShelfItem> GetBookIds(string userId, string shelfName, byte perPage)
        {
            _call.BaseUrl = "https://www.goodreads.com/review/list/" + userId;

            _call.QueryParams.Add("format", "json");
            _call.QueryParams.Add("key", "iBGqAvHjYE9W1CrqyreXRA");
            _call.QueryParams.Add("v", "2");
            _call.QueryParams.Add("shelf", shelfName);

            if (perPage > 0)
            {
                _call.QueryParams.Add("per_page", perPage.ToString(CultureInfo.InvariantCulture));
            }

            var result = _call.Execute<ShelfItem[]>();
            return result.DataItem;
        }

        public Book GetBookByIsbn(string isbn)
        {
            // https://www.goodreads.com/book/isbn?isbn=0441172717&key=iBGqAvHjYE9W1CrqyreXRA
            _call.BaseUrl = "https://www.goodreads.com/book/isbn";
            _call.QueryParams.Add("isbn", isbn);
            _call.QueryParams.Add("key", "iBGqAvHjYE9W1CrqyreXRA");
            _call.Payload = string.Empty;

            var result = _call.Execute<GoodreadsResponse>();
            var response = result.DataItem as GoodreadsResponse;
            return response.Book;
        }

        public UserStatus GetUserStatusByBook(string bookId, string userId)
        {
            //https://www.goodreads.com/user_status/show/34980137?format=xml
            //&key=iBGqAvHjYE9W1CrqyreXRA&user_id=15469076-aaron-lord

            _call.BaseUrl = "https://www.goodreads.com/user_status/show/" + bookId;
            
            // Call does not support JSON as of dev date.
            _call.QueryParams.Add("format", "xml");
            _call.QueryParams.Add("key", "iBGqAvHjYE9W1CrqyreXRA");
            _call.QueryParams.Add("user_id", userId);
            _call.Payload = string.Empty;

            var result = _call.Execute<GoodreadsResponse>();
            var response = result.DataItem as GoodreadsResponse;

            throw new NotImplementedException();
           // return response.UserStatus;
        }

        public Review GetMyReviewsForBook(string reviewId, string userId)
        {
            //https://www.goodreads.com/user_status/show/34980137?format=xml
            //&key=iBGqAvHjYE9W1CrqyreXRA&user_id=15469076-aaron-lord

            _call.BaseUrl = "https://www.goodreads.com/review/show/";

            // Call does not support JSON as of dev date.
            _call.QueryParams.Add("id", reviewId);
            _call.QueryParams.Add("format", "xml");
            _call.QueryParams.Add("key", "iBGqAvHjYE9W1CrqyreXRA");
            _call.QueryParams.Add("user_id", userId);
            _call.Payload = string.Empty;

            var result = _call.Execute<GoodreadsResponse>();
            var response = result.DataItem as GoodreadsResponse;

            return response.Review;
        }
    }
}

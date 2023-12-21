using Akb_Bootcamp_Week1.Models;

namespace Akb_Bootcamp_Week1.Services
{
    public class BookService
    {
        private List<BookModel> bookList;

        public BookService()
        {
            // Book listesini oluşturun
            bookList = new List<BookModel>();
        }

        public void AddBook(BookModel book)
        {
            // Book eklemek için metot
            bookList.Add(book);
        }

        public bool UpdateBook(BookModel book, int id)
        {
            var tmpBook = GetBookById(id);
            if (tmpBook != null)
            {
                tmpBook.Name = book.Name;
                tmpBook.Description = book.Description;
                tmpBook.Author = book.Author;
                tmpBook.Price = book.Price;
                return true;
            }
            return false;
        }

        public bool UpdateBookPatch(BookUpdateModel book, int id)
        {
            var tmpBook = GetBookById(id);
            if (tmpBook != null)
            {
                if (!string.IsNullOrEmpty(book.Name))
                {
                    tmpBook.Name = book.Name;

                }
                if (!string.IsNullOrEmpty(book.Description))
                {
                    tmpBook.Description = book.Description;

                }
                if (!string.IsNullOrEmpty(book.Author))
                {
                    tmpBook.Author = book.Author;

                }
                if (book.Price != null)
                {
                    tmpBook.Price = book.Price;

                }



                return true;
            }
            return false;
        }
        public bool DeleteBook(int id)
        {

            return bookList.Remove(GetBookById(id));

        }

        public List<BookModel> GetBooks(string order = "")
        {

            switch (order)
            {
                case "name":
                    return bookList.OrderBy(x => x.Name).ToList();
                case "id":
                    return bookList.OrderBy(x => x.Id).ToList();
                case "price":
                    return bookList.OrderBy(x => x.Price).ToList();
                case "author":
                    return bookList.OrderBy(x => x.Author).ToList();
                default:
                    return bookList;

            }
        }

        public BookModel GetBookById(int id)
        {
            return bookList.Where(x => x.Id == id).FirstOrDefault();
        }



    }
}

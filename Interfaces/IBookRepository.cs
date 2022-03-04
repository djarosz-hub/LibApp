using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;


namespace LibApp.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book Get(int bookId);
        void Add(Book book);
        void Update(Book book);
        void Remove(int bookId);
        void Save();
    }
}

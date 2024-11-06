using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerBlazorEF.Models;

namespace ServerBlazorEF.Data;
public class BookService
{
    private SchoolDbContext _context;

    public BookService(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetAsync()
    {
        List<Book> response = await _context.Books.ToListAsync();

        return response;
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id) ?? null;
    }

    public async Task<Book?> InsertAsync(Book Book)
    {
        _context.Books.Add(Book);
        await _context!.SaveChangesAsync();

        return Book;
    }

    public async Task<Book> UpdateAsync(int id, Book s)
    {
        var book = await _context.Books!.FindAsync(id);

        if (book == null)
            return null!;

        book.Name = s.Name;
        book.AuthorName = s.AuthorName;
        book.Genre = s.Genre;
        book.DatePublication = s.DatePublication;
        book.Synopsis = s.Synopsis;

        _context.Books.Update(book);
        await _context.SaveChangesAsync();

        return book!;
    }

    public async Task<Book> DeleteBookAsync(int id)
    {
        var Book = await _context.Books!.FindAsync(id);

        if (Book == null)
            return null!;

        _context.Books.Remove(Book);
        await _context.SaveChangesAsync();

        return Book!;
    }

    private bool BookExists(int id)
    {
        return _context.Books!.Any(e => e.BookId == id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerBlazorEF.Models;

namespace ServerBlazorEF.Data;
public class PersonService {
  private SchoolDbContext _context;
  
  public PersonService(SchoolDbContext context) {
    _context = context;
  }

  public async Task<List<Person>> GetAsync() {
   return await  _context.Persons.ToListAsync();
  }

  public async Task<Person?> GetByIdAsync(int id) {
    return await _context.Persons.FindAsync(id) ?? null;
  }

  public async Task<Person?> InsertAsync(Person Person) {
    _context.Persons.Add(Person);
    await _context!.SaveChangesAsync();

    return Person;
  }

  public async Task<Person> UpdateAsync(int id, Person s) {
    var Person = await _context.Persons!.FindAsync(id);

    if (Person == null)
      return null!;

    Person.FirstName = s.FirstName;
    Person.LastName = s.LastName;

    _context.Persons.Update(Person);
    await _context.SaveChangesAsync();

    return Person!;
  }

  public async Task<Person> DeleteAsync(int id) {
    var Person = await _context.Persons!.FindAsync(id);

    if (Person == null)
      return null!;

    _context.Persons.Remove(Person);
    await _context.SaveChangesAsync();

    return Person!;
  }

  private bool PersonExists(int id) {
    return _context.Persons!.Any(e => e.PersonId == id);
  }
}
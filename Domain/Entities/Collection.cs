using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Collection
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public List<Book> Books { get; private set; }

    public void AddBooks()
    {

    }

    public int GetBookCount() =>
        Books.Count;
}

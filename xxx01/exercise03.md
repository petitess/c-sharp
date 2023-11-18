Create a Book class, create two private fields: a string called _title and an integer called _pages.

Implement properties for both _title and _pages:

For the Title property, ensure that it cannot be set to an empty string. If an empty string is passed, set it to "Unknown".

For the Pages property, ensure that it cannot be set to a value less than 1. If a value less than 1 is passed, set it to 1.

Use getters and setters for creating properties
```cs
Book titanic = new Book("", 0);
Console.WriteLine("The name of the book is " + titanic.Title + " and it has " + titanic.Pages + " pages");
```
```cs
namespace exercise
{
    internal class Book
    {
        private string _title;
        private int _pages;
        public Book(string title, int pages) 
        {
            _title = title;
            _pages = pages;
        }
        public string Title
        {
            get { return _title; }
            set { _title = string.IsNullOrEmpty(value) ? "Unknown" : value; }
        }
        public int Pages
        {
            get { return _pages; }
            set { _pages = value < 1 ? 1 : value; }
        }
    }
}
```

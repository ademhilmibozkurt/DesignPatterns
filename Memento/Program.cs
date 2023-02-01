using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Isbn = "1327430", Title = "ON : İÇİMDEKİ KATİL", Author = "Mario MAZZANTI"
            };
            book.ShowBook();

            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo(); // yedek oluşturduk.

            book.Isbn = "75446852";
            book.Title = "Şah Mat";

            book.ShowBook();

            book.RestoreFromUndo(history.Memento);
            book.ShowBook();

            Console.ReadKey();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        private DateTime _lastEdited;
        public string Title 
        { 
            get{ return _title; }
            set
            {
                _title = value;
                SetLastEdited();
            } 
        }
        public string Author
        {
            get { return _author; }
            set 
            { 
                _author = value;
                SetLastEdited();
            }
        }
        public string Isbn
        {
            get { return _isbn; }
            set 
            { 
                _isbn = value;
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.Now;
        }

        public Memento CreateUndo()
        {
            return new Memento(_isbn, _title, _author, _lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine($"Book : {Isbn}, {Title}, {Author}, edited : {_lastEdited}");
        }
    }

    class Memento
    {
        public string Title{ get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn, string title, string author, DateTime lastEdited)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }


}

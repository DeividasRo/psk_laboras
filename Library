import datetime

class book:
    def __init__(self, title, author, ISBN, publication_year):
        self.title = title
        self.Author = author
        self.ISBN = ISBN
        self.publication_year = publication_year
        self.is_available = True

class library_System:
    def __init__(self):
        self.books = []
        self.borrowed_books = {}

    def add_Book(self, book):
        self.books.append(book)

    def remove_book(self, ISBN):
        for book in self.books:
            if book.ISBN == ISBN:
                self.books.remove(book)
                return True
        return False

    def borrow_book(self, ISBN, user_id):
        for book in self.books:
            if book.ISBN == ISBN and book.is_available:
                book.is_available = False
                self.borrowed_books[ISBN] = (user_id, datetime.datetime.now())
                return True
        return False

    def return_book(self, ISBN):
        if ISBN in self.borrowed_books:
            for book in self.books:
                if book.ISBN == ISBN:
                    book.is_available = True
                    del self.borrowed_books[ISBN]
                    return True
        return False

    def get_available_books(self):
        return [book for book in self.books if book.is_available]

    def get_borrowed_books(self):
        borrowed = []
        for ISBN, (user_id, borrow_date) in self.borrowed_books.items():
            for book in self.books:
                if book.ISBN == ISBN:
                    borrowed.append((book, user_id, borrow_date))
        return borrowed

    def search_books_by_author(self, author):
        return [book for book in self.books if book.Author.lower() == author.lower()]

    def generate_report(self):
        total_books = len(self.books)
        available_books = len(self.get_available_books())
        borrowed_books = len(self.borrowed_books)

        report = f"Library Report\n"
        report += f"Total books: {total_books}\n"
        report += f"Available books: {available_books}\n"
        report += f"Borrowed books: {borrowed_books}\n"

        return report

# Example usage
library = library_System()

book1 = book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565", 1925)
book2 = book("To Kill a Mockingbird", "Harper Lee", "9780446310789", 1960)

library.add_Book(book1)
library.add_Book(book2)

library.borrow_book("9780743273565", "user123")

print(library.generate_report())
print(library.search_books_by_author("Harper Lee"))

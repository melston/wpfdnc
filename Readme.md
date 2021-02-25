This is a small test project to explore an implementation of Drag and Drop in WPF using a 
TreeView representation of a moderately complex data tree.  The sample data comes from a
Star Wars fan fiction site.

The data consists of the following:
- Authors that have the following fields:
  - Name - the name of the author
  - Books - the books they have authored.  This is really just the list of series that
    individual stories are associated with.
- Books.  As the site doesn't really deal with books, but rather stories, a book for our purposes
  is simply a set of stories published that are associated together as a series:  Books have the following fields:
  - Chapters - this is the list of stories published in the series.
  - Title - this is the name of the series.  If there is no real series then the title of the 'book' is the
    title of the one story the book contains.  
- Chapters.  As implied above, all chapters must be associated with a book.  If a story (chapter) is really
  a standalone story then it is part of a book with the same name as the story itself.  Chapters have the following fields:
  - ChapterName - the title of the story as it was published on the site.
  - Date - the date a story was published on the site

Inside the WpfBooks project the code is organized as follows:
- Author.cs/Book.cs/Chapter.cs - the basic data elements that get moved about.
- Utils.cs - contains the code to generate the sample data.
- MainWindow.xaml.cs - creates the overall UI and has a function to move the observable data from
  one place to another (moving chapters from one book to another or reorder chapters in a book).
- MainWindowDnd.cs - contains the code for handling all of the Drag and Drop functionality.

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
  - Title - this is the name of the series.
- Chapters which have the following fields:
  - ChapterName - the title of the story as it was published on the site.
  - Date - the date a story was published on the site


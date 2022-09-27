namespace Values 
module Directories =
    open System.IO
    open System

    let docs = Environment.GetFolderPath Environment.SpecialFolder.Personal
    let vault = Path.Combine(docs, "Notes")
    let templates =  Path.Combine(vault,"Templates")
    let entertainment = Path.Combine(vault,"Entertainment")
    let movies = Path.Combine(entertainment,"Movies")
    let games = Path.Combine(entertainment,"Games")
    let reading = Path.Combine(entertainment,"Reading")
    let shows = Path.Combine(entertainment,"Shows")

module MainFile = 
    let moviesFile = "Movies.md"
    let gamesFile = "Games.md"
    let booksFile = "Books.md"
    let comicsFile = "Comics.md"
    let webcomicsFile = "Webcomics.md"
    let showsFile = "Shows.md"
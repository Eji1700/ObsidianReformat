namespace Types

type EntryRecord = 
    {   Path: string
        Template: string
        Name: string
        Tags: string
        Watched: string
        Rating: string 
        Review: string }

module EntryRecord =
    let private deTag (s: string) =
        s.Replace("#","")

    let Empty = 
        {   Path = ""
            Template = ""
            Name = ""
            Tags = ""
            Watched = ""
            Rating = "" 
            Review = "" }

    let Populate (idx, dataRecord) value =
        match idx with 
        | 0 ->
            let path, temp, name = value 
            1, { dataRecord with Path = path; Template = temp; Name = name }
        | 1 -> 
            let tags, _, _ = value
            let cleanTags = deTag tags
            2, { dataRecord with Tags = cleanTags }
        | 2 -> 
            let watched, _, _ = value
            let cleanWatched = deTag watched
            3, { dataRecord with Watched = cleanWatched }
        | 3 -> 
            let rating, _, _ = value
            let cleanRating = deTag rating
            4, { dataRecord with Rating = cleanRating }
        | 4 -> 
            let review, _, _ = value
            0, { dataRecord with Review = review }
        | _ -> failwith "Unhandled index passed to EntryRecord.Populate"

type Templates =
    {   Books: string []
        Movies: string []
        Games: string []
        Shows: string [] }

module Templates =
    open System.IO
    let Empty = 
        {   Books = [||]
            Movies = [||]
            Games = [||]
            Shows = [||] }

    let Populate templates (templatePath: string)  =
        if templatePath.Contains "Movie" then 
            {templates with Movies = File.ReadAllLines(templatePath) }
        elif  templatePath.Contains "Book" then 
            {templates with Books = File.ReadAllLines(templatePath) }
        elif  templatePath.Contains "Game" then 
            {templates with Games = File.ReadAllLines(templatePath) }
        elif  templatePath.Contains "Show" then 
            {templates with Shows = File.ReadAllLines(templatePath) }
        else
            templates

    let private replace word value (template: string []) =
        template
        |> Array.map(fun line ->
            line.Replace("<" + word + ">", value))
    
    let Create entryRecord template =
        template
        |> replace "name" entryRecord.Name
        |> replace "watched" entryRecord.Watched
        |> replace "tags" entryRecord.Tags
        |> replace "rating" entryRecord.Rating
        |> replace "watched" entryRecord.Watched
        |> replace "review" entryRecord.Review
    
            

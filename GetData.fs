namespace GetData
module ObsidianFiles =
    open System.IO
    open Types

    let Templates templatesFolder = 
        Directory.GetFiles templatesFolder
        |> Seq.fold Templates.Populate Templates.Empty

    let MainFileParse directory file =
        Path.Combine(directory, file)
        |> File.ReadAllLines
        |> Seq.skip 2
        |> Seq.map(fun line -> 
            line.Split("|")
            |> Array.mapi( fun i entry ->
                match i with 
                | 0 -> 
                    let name = entry.Replace("[","") |> fun x -> x.Replace("]","") 
                    let path = Path.Combine(directory, name + ".md")
                    let template = "Movie"
                    path, template, name
                | _ -> entry, "", "" )
            |> Array.fold EntryRecord.Populate (0, EntryRecord.Empty)
        >> (fun (_, data) -> data ) )
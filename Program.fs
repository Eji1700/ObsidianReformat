open GetData
open Values
open CreateFiles

[<EntryPoint>]
let main argv = 
    let templates = ObsidianFiles.Templates Directories.templates
    ObsidianFiles.MainFileParse Directories.movies MainFile.moviesFile
    |> Seq.iter(fun entry ->
        ObsidianFile.MDFile templates entry
    )
    0
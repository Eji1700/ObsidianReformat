namespace CreateFiles

module ObsidianFile =
    open Types
    open System.IO

    let MDFile templates entryRecord =
        printfn $"Creating note for {entryRecord.Name}"
        let file = File.Create(entryRecord.Path)
        file.Close()
        let entry = Templates.Create entryRecord templates.Movies
        File.WriteAllLines(entryRecord.Path, entry)
type Result<'a, 'b> =
    | Success of 'a
    | Failure of 'b

// list everything exception that you want to handle
type FileErrorReason =
    | FileNotFound of string
    | UnauthorizedAccess of string * System.Exception

let performActionOnFile action filePath =
    try
        use sr = new System.IO.StreamReader(filePath: string)
        let result = action sr
        Success(result)
    with
    | :? System.IO.FileNotFoundException as ex -> Failure(FileNotFound filePath)
    | :? System.Security.SecurityException as ex -> Failure(UnauthorizedAccess(filePath, ex))

//performActionOnFile returns a Result object that is either Success of result or Failure of FileErrorReason

let middleLayerDo action filePath =
    let fileResult = performActionOnFile action filePath
    fileResult

let topLayerDo action filePath =
    let fileResult = middleLayerDo action filePath
    fileResult

let printFirstLineOfFile filePath =
    let fileResult = topLayerDo (fun fs ->fs.ReadLine()) filePath

    match fileResult with
    | Success result ->
        printfn "first line is: '%s'" result
    | Failure reason ->
        match reason with 
            | FileNotFound file ->
                printfn "File not found: %s" file
            | UnauthorizedAccess (file, _) ->
                printfn "You do not have access to the file: %s" file

printFirstLineOfFile "Program.fs"
printFirstLineOfFile "yayaya"

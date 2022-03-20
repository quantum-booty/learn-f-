module CommandlineV1 =
    let OrderByName = "N"
    let OrderBySize = "S"

    type CommandLineOptions =
        { verbose: bool
          subdirectories: bool
          orderBy: string }

    let rec parseCommandLineRec args optionsSoFar =
        match args with
        | [] -> optionsSoFar
        | "/v" :: xs ->
            let newOptionsSoFar = { optionsSoFar with verbose = true }
            parseCommandLineRec xs newOptionsSoFar
        | "/s" :: xs ->
            let newOptionsSoFar = { optionsSoFar with subdirectories = true }
            parseCommandLineRec xs newOptionsSoFar
        | "/o" :: xs ->
            match xs with
            | "S" :: xss ->
                let newOptionsSoFar = { optionsSoFar with orderBy = OrderBySize }
                parseCommandLineRec xs newOptionsSoFar
            | "N" :: xss ->
                let newOptionsSoFar = { optionsSoFar with orderBy = OrderByName }
                parseCommandLineRec xs newOptionsSoFar
            | _ ->
                eprintfn "orderBy needs a second argument"
                parseCommandLineRec xs optionsSoFar
        | x :: xs ->
            eprintfn "Option '%s' is unrecognized" x
            parseCommandLineRec xs optionsSoFar

    let parseCommandLine args =
        let defaultOptions =
            { verbose = false
              subdirectories = false
              orderBy = OrderByName }

        parseCommandLineRec args defaultOptions

module CommandlineV2 =
    type OrderByOption =
        | OrderBySize
        | OrderByName

    type SubdirectoryOption =
        | IncludeSubDirectories
        | ExcludeSubdirectories

    type VerboseOption =
        | VerboseOutput
        | TerseOutput

    type CommandLineOptions =
        { verbose: VerboseOption
          subdirectories: SubdirectoryOption
          orderBy: OrderByOption }

    // create the "helper" recursive function
    let rec parseCommandLineRec args optionsSoFar =
        match args with
        // empty list means we're done.
        | [] -> optionsSoFar

        // match verbose flag
        | "/v" :: xs ->
            let newOptionsSoFar = { optionsSoFar with verbose = VerboseOutput }
            parseCommandLineRec xs newOptionsSoFar

        // match subdirectories flag
        | "/s" :: xs ->
            let newOptionsSoFar = { optionsSoFar with subdirectories = IncludeSubDirectories }
            parseCommandLineRec xs newOptionsSoFar

        // match sort order flag
        | "/o" :: xs ->
            //start a submatch on the next arg
            match xs with
            | "S" :: xss ->
                let newOptionsSoFar = { optionsSoFar with orderBy = OrderBySize }
                parseCommandLineRec xss newOptionsSoFar
            | "N" :: xss ->
                let newOptionsSoFar = { optionsSoFar with orderBy = OrderByName }
                parseCommandLineRec xss newOptionsSoFar
            // handle unrecognized option and keep looping
            | _ ->
                printfn "orderBy needs a second argument"
                parseCommandLineRec xs optionsSoFar

        // handle unrecognized option and keep looping
        | x :: xs ->
            printfn "Option '%s' is unrecognized" x
            parseCommandLineRec xs optionsSoFar

    // create the "public" parse function
    let parseCommandLine args =
        // create the defaults
        let defaultOptions =
            { verbose = TerseOutput
              subdirectories = ExcludeSubdirectories
              orderBy = OrderByName }

        // call the recursive one with the initial options
        parseCommandLineRec args defaultOptions




printfn "%A" (CommandlineV1.parseCommandLine [ "/v" ])

printfn
    "%A"
    (CommandlineV1.parseCommandLine [ "/v"
                                      "/s" ])

printfn
    "%A"
    (CommandlineV1.parseCommandLine [ "/o"
                                      "S" ])

printfn
    "%A"
    (CommandlineV1.parseCommandLine [ "/v"
                                      "xyz" ])

printfn
    "%A"
    (CommandlineV1.parseCommandLine [ "/o"
                                      "xyz" ])


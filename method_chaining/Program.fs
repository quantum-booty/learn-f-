type FluentShape =
    { label: string
      color: string
      onClick: FluentShape -> FluentShape }

let defaultShape =
    { label = ""
      color = ""
      onClick = fun shape -> shape }

let click shape = shape.onClick shape

let display shape =
    printfn "My label=%s and my color=%s" shape.label shape.color
    shape

// are these akin to setters in OOP?
let setLabel label shape =
    { shape with FluentShape.label = label }

let setColor color shape =
    { shape with FluentShape.color = color }

let appendClickAction action shape =
    { shape with FluentShape.onClick = shape.onClick >> action }

let setBox = setLabel "box"
let setRedBox = setColor "red" >> setBox // composing and currying
let setBlueBox = setColor "blue" >> setBox
let changeColorOnClick color = appendClickAction (setColor color)

let redBox = defaultShape |> setRedBox
let blueBox = defaultShape |> setBlueBox

redBox
|> display
|> changeColorOnClick "orange"
|> display
|> ignore

let rainbowColors =
    [ "red"
      "orange"
      "yellow"
      "green"
      "blue"
      "indigo"
      "purple" ]

let showRainbow =
    let setColorAndDisplay color = setColor color >> display

    rainbowColors
    |> List.map setColorAndDisplay
    |> List.reduce (>>)

redBox |> showRainbow |> ignore
redBox |> display |> ignore // the original object is not mutated
defaultShape |> showRainbow |> ignore

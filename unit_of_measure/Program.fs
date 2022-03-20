[<Measure>]
type cm

[<Measure>]
type inches

[<Measure>]
type feet =
    // add a conversion function
    static member toInches(feet: float<feet>) : float<inches> = feet * 12.0<inches/feet>

// using the conversion function
let myFeet = 10.0<feet>
let myMeter = 1
let yaya = feet.toInches (myFeet)
printfn "%A" yaya

// define some values
let meter = 100.0<cm>
let yard = 3.0<feet>
// meter + yard // would not compile, as types does not match

// wild card
let wildmeter = meter + 1.0<_>

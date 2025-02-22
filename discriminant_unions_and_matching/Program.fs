﻿type Shape =
    | Circle of radius: int
    | Rectangle of height: int * width: int // this is a tuple
    | Point of x: int * y: int
    | Polygon of pointList: (int * int) list

let draw shape =
    match shape with
    | Circle radius -> printfn "The circle has a radius of %d" radius
    | Rectangle (height, width) -> printfn "The rectangle is %d high by %d wide" height width
    | Polygon points -> printfn "The polygon is made of these points %A" points
    | _ -> printfn "I don't recognize this shape"

let circle = Circle(10)
let rect = Rectangle(4, 5)
let point = Point(2, 3)
let polygon = Polygon([ (1, 1); (2, 2); (3, 3) ])

[ circle; rect; polygon; point ] |> List.iter draw


// Single-case discriminated unions are often used to create type-safe abstractions with pattern matching support:
type OrderId = OrderId of string

// Create a DU value
let orderId = OrderId "12"

// Use pattern matching to deconstruct single-case DU
let (OrderId id) = orderId

// use a function that takes OrderID type as input
let printOrderId (OrderId id) =
    printfn "The order id is %s" id

printOrderId orderId
// printOrderId "hello" // would not compile, as a string is not an OrderId


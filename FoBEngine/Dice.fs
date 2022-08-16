namespace FoBEngine

module Dice =
    type Die =
        | One
        | Two
        | Three
        | Four
        | Five
        | Six

    type Roll = Die list
    
    let parser (input:string) =
        let tokens = input.Split(" ")
        tokens
        |> Array.map (fun token ->
            match token with
            | "1" -> One
            | "2" -> Two
            | "3" -> Three
            | "4" -> Four
            | "5" -> Five
            | "6" -> Six
            | _ -> failwith "invalid die token" )
        |> Array.toList

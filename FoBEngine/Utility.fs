namespace FoBEngine

module Utility =
    open System
    
    //
    let rec removeFirst item list' =
        match list' with
        | [] -> []
        | x :: remainder when x = item -> remainder
        | x :: remainder -> x :: removeFirst item remainder
    
    let rec addMultiple item count list' =
        match count with
        | 0 -> list'
        | _ -> addMultiple item (count-1) (item::list')
    
    let shuffle list =
        let rng = Random()
        list
        |> List.map (fun item -> (item,rng.Next()))
        |> List.sortBy snd
        |> List.map fst

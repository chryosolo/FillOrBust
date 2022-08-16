namespace FoBEngine

module Cards =
    open Utility
    
    type Card =
        | Bonus300
        | Bonus400
        | Bonus500
        | NoDice
        | Fill1000
        | MustBust
        | Vengeance2500
        | DoubleTrouble
    
    let newDeck : Card list =
        []
        |> addMultiple Card.Bonus400 10
        |> addMultiple Card.Bonus500 8
        |> addMultiple Card.Bonus300 12
        |> addMultiple Card.NoDice 8
        |> addMultiple Card.Fill1000 6
        |> addMultiple Card.MustBust 4
        |> addMultiple Card.Vengeance2500 4
        |> addMultiple Card.DoubleTrouble 2
    
    let appendDiscards deck discards  =
        discards
        |> shuffle
        |> List.append deck        
    
    
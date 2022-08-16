namespace FoBEngine

module Game =
    open Cards
    open Rules
    
    type State =
        | P1Turn
        | P2Turn
        | P1PendingWin
        | P2PendingWin    
        
    type Player = Name of string

    type Game = {State: State; Players: Player[]; Scores: int[]; Active: byte; Deck: Card list; Discard: Card list}

    type Node = {Match:Match; Children:Node list}
    
    type Move = {Key:string; Matches:Match list; Points:int; DiceLeft:int}
    
    type Strategy = Node list -> Move
    
    let printState (game:Game) : unit =
        printfn $"Players: %i{game.Players.Length}"
        game.Players |> Array.iter (fun p -> printfn $"Player: %A{p}")
        game.Scores |> Array.iter (fun s -> printfn $"Score: %d{s}")
    
    let rec matchDice remainingDice rule =
        match rule.Uses with
        | [] -> Some {Name=rule.Name; Points=rule.Points; Left=remainingDice}
        | die::next when remainingDice |> List.contains die ->
            let available = remainingDice |> Utility.removeFirst die
            matchDice available {rule with Uses=next}
        | _ -> None
    
    let rec matchRules rules dice =
        rules
        |> List.choose (matchDice dice)
        |> List.map (fun m ->
            let children = matchRules rules m.Left
            {Match=m; Children=children})

    let treeToList nodes =
        let rec treeToListInner path nodes' =
            nodes'
            |> List.collect (fun node ->
                match node.Children with
                | [] ->
                    let path' =
                        node.Match::path
                        |> List.sortBy (fun m -> m.Name)
                    [{
                        Key=(List.fold (fun s m -> $"{s},{m.Name}") "" path')
                        Matches=path'
                        Points=path' |> List.sumBy (fun m -> m.Points)
                        DiceLeft=node.Match.Left.Length
                    }]
                | _ -> treeToListInner (node.Match::path) node.Children)
        treeToListInner [] nodes
        |> List.groupBy (fun m -> m.Key)
        |> List.map (fun (_,i) -> i.Head)

    let speedo input =
        input
        |> Dice.parser
        |> (matchRules standardRules)
        |> treeToList
        
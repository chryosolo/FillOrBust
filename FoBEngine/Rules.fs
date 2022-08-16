namespace FoBEngine

module Rules =
    open Dice

    type Rule = {Name:string; Uses:Die list; Points:int}

    type Match = {Name:string; Points:int; Left:Die list}

    let standardRules =
        [{Name="SingleOne"; Uses=[Die.One]; Points=100}
         {Name="SingleFive"; Uses=[Die.Five]; Points=50}
         {Name="TripleOne"; Uses=[Die.One; Die.One; Die.One]; Points=1000}
         {Name="TripleTwo"; Uses=[Die.Two; Die.Two; Die.Two]; Points=200}
         {Name="TripleThree"; Uses=[Die.Three; Die.Three; Die.Three]; Points=300}
         {Name="TripleFour"; Uses=[Die.Four; Die.Four; Die.Four]; Points=400}
         {Name="TripleFive"; Uses=[Die.Five; Die.Five; Die.Five]; Points=500}
         {Name="TripleSix"; Uses=[Die.Six; Die.Six; Die.Six]; Points=600}
         {Name="Straight"; Uses=[Die.One; Die.Two; Die.Three; Die.Four; Die.Five; Die.Six]; Points=1500}]

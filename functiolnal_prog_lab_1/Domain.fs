namespace Entities

type Genre = 
    | Action
    | Adventure
    | Puzzle
    | RPG
    | Simulation
    | Strategy
    | Shooter

type Platform =
    | PC
    | Console of string

type User = { FirstName: string; LastName: string }

type Rating = { User: User; Score: float }

type Developer = { StudioName: string; Country: string; Games: Game list }
and Game = { Name: string; Genre: Genre; Year: int; Developer: Developer; Platform: Platform; Rating: Rating }
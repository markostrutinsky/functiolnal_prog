namespace Operations

open Entities

module Game = 
    let createGame name genre year developer platform rating =
        { Name = name; Genre = genre; Year = year; Developer = developer; Platform = platform; Rating = rating }

    //Використання композиції
    let getFormattedStats =
        //Використання кортежу
        let getGameStats game = 
            (game.Name, game.Year, game.Rating.Score)

        getGameStats >> fun (name, year, score) -> $"Game: {name} ({year}), Score: {score}/10"
    
    //Використання карованої форми
    let hasMinRating minScore game =
        game.Rating.Score >= minScore

    let filterGamesByRating ratingFilter games =
        games |> List.filter ratingFilter

    let categorizeGames games =
        let categorizeGame game =
            if game.Rating.Score >= 9.0 then
                "Masterpiece"
            elif game.Rating.Score >= 8.0 then
                "Great"
            elif game.Rating.Score >= 6.5 then
                "Decent"
            else
                "Skip"

        games |> List.map (fun game -> (game.Name, categorizeGame game))

module User = 

    let createUser firstName lastName =
        { FirstName = firstName; LastName = lastName; }

    let fullName { FirstName = firstName; LastName = lastName } =
        $"{firstName} {lastName}"

module Developer = 
    let createDeveloper studioName country games =
        { StudioName = studioName; Country = country; Games = games }

    let addGameToDeveloper developer game =
        { developer with Games = game :: developer.Games}

    //Використання карованої форми та конвеєру
    let averageRatingByDeveloper =
        fun studioName ->
            fun games ->
                games
                |> List.filter (fun game -> game.Developer.StudioName = studioName)
                |> List.map (fun game -> game.Rating.Score)
                |> function
                    | [] -> "There is no such studio"
                    | scores ->  $"Average rating of the {studioName} is {List.average scores}/10" 

module Rating =
    let createRating user score =
        { User = user; Score = score }
    
    //Використання зіставлення зі зразком
    let genreDescription genre =
        match genre with
        | Action -> "Action -> Fast-paced combat and reflex-based challenges, often requiring quick reactions"
        | Adventure -> "Adventure -> Focuses on exploration, puzzle-solving, and story-driven gameplay"
        | Puzzle -> "Puzzle -> Logic-based challenges and problem-solving"
        | RPG -> "RPG -> Character progression, leveling up, and engaging quests"
        | Simulation -> "Simulation -> Realistic mechanics replicating real-world activities or systems"
        | Strategy -> "Strategy -> Tactical planning, resource management, and decision-making"
        | Shooter -> "Shooter -> Firearm-based combat, ranging from first-person to third-person perspectives"




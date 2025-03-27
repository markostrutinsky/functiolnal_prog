open Entities
open Operations

[<EntryPoint>]
let main argv =
    let user = User.createUser "Marko" "Strutynskyi"

    let exodusRating = Rating.createRating user 9.0
    let lastLightRating = Rating.createRating user 9.0
    let witcher3Rating = Rating.createRating user 9.8
    let cyberpunk2077Rating = Rating.createRating user 8.5
    let redDeadRedemption2Rating = Rating.createRating user 8.5
    let skyrimRating = Rating.createRating user 9.5
    let gta5Rating = Rating.createRating user 9.6
    let doomEternalRating = Rating.createRating user 9.6
    
    let fourAGame = Developer.createDeveloper "4A Games" "Ukraine" []
    let CDProject = Developer.createDeveloper "CD Project" "Poland" []
    let rockstarGames = Developer.createDeveloper "Rockstar Games" "United States" []
    let bethesdaGameStudios = Developer.createDeveloper "Bethesda Game Studios" "United States" []
    
    let metroLastLight = Game.createGame "Metro: Last Light" Genre.Shooter 2013 fourAGame Platform.PC exodusRating
    let metroExodus = Game.createGame "Metro Exodus" Genre.Shooter 2019 fourAGame Platform.PC lastLightRating
    let theWitcher3 = Game.createGame "The Witcher 3: Wild Hunt" Genre.RPG 2015 CDProject Platform.PC witcher3Rating
    let cyberpunk2077 = Game.createGame "Cyberpunk 2077" Genre.RPG 2020 CDProject Platform.PC cyberpunk2077Rating
    let redDeadRedemption2 = Game.createGame "Red Dead Redemption 2" Genre.Adventure 2018 rockstarGames Platform.PC redDeadRedemption2Rating
    let gta5 = Game.createGame "Grand Theft Auto V" Genre.Action 2013 rockstarGames Platform.PC gta5Rating
    let skyrim = Game.createGame "The Elder Scrolls V: Skyrim" Genre.RPG 2011 bethesdaGameStudios Platform.PC skyrimRating
    let fallout4 = Game.createGame "Fallout 4" Genre.RPG 2015 bethesdaGameStudios Platform.PC redDeadRedemption2Rating
    let doomEternal = Game.createGame "Doom Eternal" Genre.Shooter 2020 bethesdaGameStudios Platform.PC doomEternalRating

    let games = [metroLastLight; metroExodus; theWitcher3; cyberpunk2077; redDeadRedemption2; gta5; skyrim; fallout4; doomEternal;]

    User.fullName user |> printfn "%s\n"
    Developer.averageRatingByDeveloper "CD Project" games |> printfn "%s\n"
    Game.getFormattedStats metroExodus |> printfn "%s\n"
    Rating.genreDescription metroExodus.Genre |> printfn "%s\n"

    let isHighlyRated = Game.hasMinRating 9.0
    let isDecentRated = Game.hasMinRating 6.5

    let topGames = Game.filterGamesByRating isHighlyRated games
    let decentGames = Game.filterGamesByRating isDecentRated games
    
    topGames |> List.map (fun game -> game.Name) |> printfn "Highly Rated Games: %A\n"
    decentGames |> List.map (fun game -> game.Name) |> printfn "Decent Rated Games: %A\n"

    let categorizedGames = Game.categorizeGames games
    printfn "Game Categories: %A\n" categorizedGames

    let developer = Developer.addGameToDeveloper fourAGame metroExodus
    Developer.addGameToDeveloper developer metroLastLight |> printf "4A Games: %A"

    0

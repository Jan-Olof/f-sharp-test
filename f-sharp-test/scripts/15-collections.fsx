type FootballResult =
    { HomeTeam : string
      AwayTeam : string
      HomeGoals : int
      AwayGoals : int }

let create (ht, hg) (at, ag) =
    { HomeTeam = ht; AwayTeam = at; HomeGoals = hg; AwayGoals = ag }

let results =
    [ create ("Messiville", 3) ("Ronaldo City", 2)
      create ("Messiville", 4) ("Bale Town", 3)
      create ("Bale Town", 3) ("Ronaldo City", 1)
      create ("Bale Town", 2) ("Messiville", 3)
      create ("Ronaldo City", 4) ("Messiville", 5)
      create ("Ronaldo City", 1) ("Bale Town", 2) ]

let isAwayWin result =
    result.AwayGoals > result.HomeGoals

results
|> List.filter isAwayWin
|> List.countBy(fun result -> result.AwayTeam)
|> List.sortByDescending(fun (_, awayWins) -> awayWins)
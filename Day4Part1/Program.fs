open System

let grid =
    Seq.initInfinite (fun _ -> stdin.ReadLine())
    |> Seq.takeWhile (fun s -> not (String.IsNullOrWhiteSpace s))
    |> array2D

let word = "XMAS"

let stride = [-1; 0; 1]
let steps =
    stride
    |> List.collect (fun s -> stride |> List.map(fun s' -> (s, s')))
    |> List.filter (fun s -> not (s = (0, 0)))

let search (i: int) (j: int) _=
    let walk ((di, dj): int * int) =
        let rec walk i' j' n =
            if n = word.Length then 1
            else if (i' < 0 || i' >= Array2D.length1 grid) || (j' < 0 || j' >= Array2D.length2 grid) then 0
            else if word[n] = grid[i', j'] then
                walk (i' + di) (j' + dj) (n + 1)
            else 0

        walk i j 0

    steps
    |> Seq.map walk
    |> Seq.sum


grid
|> Array2D.mapi search
|> Seq.cast<int>
|> Seq.sum
|> printfn "%A"

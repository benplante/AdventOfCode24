open System.Text.RegularExpressions

let expr = Regex("do\(\)|don't\(\)|mul\((\d+),(\d+)\)")

let matches (expr: Regex) input =
    let rec matches idx = seq {
        let m = expr.Match(input, idx)
        if m.Success then
            yield m
            yield! matches (m.Index + m.Length)
    }

    matches 0

let folder (state: int * bool) (item: Match) =
    let result, enabled = state
    match item.Value with
    | "do()" -> result, true
    | "don't()" -> result, false
    | _ when not enabled -> state
    | _ ->
        let res = (int item.Groups[1].Value) * (int item.Groups[2].Value)
        res + result, enabled


let input = stdin.ReadToEnd()
matches expr input
|> Seq.fold folder (0, true)
|> printfn "\n%A"
// expr.EnumerateMatches(input)
// |> Seq.cast<ValueMatch>
// |> Seq.iter (printfn "%A")

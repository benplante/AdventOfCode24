open System.Text.RegularExpressions

let expr = Regex("mul\((\d+),(\d+)\)")

let matches (expr: Regex) input =
    let rec matches idx = seq {
        let m = expr.Match(input, idx)
        if m.Success then
            yield m
            yield! matches (m.Index + m.Length)
    }

    matches 0

let input = stdin.ReadToEnd()
matches expr input
|> Seq.map (fun x -> (int x.Groups[1].Value) * (int x.Groups[2].Value))
|> Seq.sum
|> printfn "\n%A"

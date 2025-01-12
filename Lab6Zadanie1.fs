// Napisz program, który pobiera tekst od u¿ytkownika, a nastêpnie oblicza i wyœwietla:
//• Liczbê s³ów w podanym tekœcie.
//• Liczbê znaków (bez spacji).

open System

let countWords (text: string) =
    text.Split([| ' '; '\t'; '\n'; '\r' |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.length


let countCharacters (text: string) =
    text.ToCharArray()
    |> Array.filter (fun c -> not (Char.IsWhiteSpace(c)))
    |> Array.length


[<EntryPoint>]
let main _ =
    printfn "Podaj tekst:"
    let input = Console.ReadLine()
    
    let wordCount = countWords input
    let charCount = countCharacters input

    printfn "Liczba s³ów: %d" wordCount
    printfn "Liczba znaków bez spacji: %d" charCount

    0 

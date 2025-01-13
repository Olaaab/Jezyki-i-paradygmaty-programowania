// Napisz program, kt�ry pobiera tekst od u�ytkownika, a nast�pnie oblicza i wy�wietla:
//� Liczb� s��w w podanym tek�cie.
//� Liczb� znak�w (bez spacji).

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

    printfn "Liczba s��w: %d" wordCount
    printfn "Liczba znak�w bez spacji: %d" charCount

    0 

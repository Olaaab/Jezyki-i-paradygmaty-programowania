// Stwórz funkcjê, która sprawdza, czy podany ci¹g znaków jest palindromem (czytany od przodu i od ty³u jest taki sam). Program powinien pobieraæ tekst od u¿ytkownika i wyœwietlaæ odpowiedni komunikat.

open System

let isPalindrome (text: string) =
    let cleanedText =
        text.ToLower()
        |> Seq.filter (fun c -> Char.IsLetterOrDigit(c)) 
        |> Seq.toArray

    let reversedText = Array.rev cleanedText
    cleanedText = reversedText

[<EntryPoint>]
let main _ =
    printfn "Podaj tekst:"
    let input = Console.ReadLine()
    
    if isPalindrome input then
        printfn "Podany ci¹g jest palindromem."
    else
        printfn "Podany ci¹g nie jest palindromem."

    0 

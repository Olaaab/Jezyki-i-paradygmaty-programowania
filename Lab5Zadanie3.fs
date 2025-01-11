// Utwórz funkcjê rekurencyjn¹ generuj¹c¹ wszystkie mo¿liwe permutacje listy liczb ca³kowitych

let rec permutations list =
    match list with
    | [] -> [[]]  
    | head :: tail ->
        let restPerms = permutations tail
        restPerms |> List.collect (fun perm ->
            [for i in 0..List.length perm do
                yield List.take i perm @ (head :: List.skip i perm)])

let result = permutations [44; 45; 46; 47; 48]  
printfn "Permutacja listy: %A" result

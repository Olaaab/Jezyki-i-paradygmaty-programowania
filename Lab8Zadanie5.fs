// Napisz funkcjê, która sprawdza, czy dany element znajduje siê w liœcie.

type LinkedList<'T> =
    | Empty
    | Node of 'T * LinkedList<'T>

let rec contains element linkedList =
    match linkedList with
    | Empty -> false
    | Node(value, next) ->
        if value = element then true
        else contains element next

let fromList lst =
    List.foldBack (fun x acc -> Node(x, acc)) lst Empty

let rec printList list =
    match list with
    | Empty -> ()
    | Node(value, next) ->
        printf "%A " value
        printList next

let lista = [1; 2; 5; 9; 4]
let lista2 = fromList lista

printf "Lista: "
printList lista2

let szukanaWartosc = 7
let znaleziono = contains szukanaWartosc lista2
printfn "\nCzy %A znajduje siê w liœcie? %b" szukanaWartosc znaleziono

let brakujacyElement = 9
let nieZnaleziono = contains brakujacyElement lista2
printfn "Czy %A znajduje siê w liœcie? %b" brakujacyElement nieZnaleziono

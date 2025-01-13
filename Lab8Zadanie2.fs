// Napisz funkcjê, która sumuje elementy listy zawieraj¹cej liczby ca³kowite

type LinkedList<'T> =
    | Empty
    | Node of 'T * LinkedList<'T>

let rec sumLinkedList linkedList =
    match linkedList with
    | Empty -> 0
    | Node(value, next) -> value + sumLinkedList next

let fromList lst =
    List.foldBack (fun x acc -> Node(x, acc)) lst Empty

let nowalista = [2; 4; 6; 8]
let laczonalista = fromList nowalista

let suma = sumLinkedList laczonalista
printfn "Suma elementów listy: %d" suma 

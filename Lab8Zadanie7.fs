// Napisz funkcjê, która zlicza, ile razy dany element wystêpuje w liœcie.

type LinkedList<'T> =
    | Empty
    | Node of 'T * LinkedList<'T>


let rec countOccurrences element linkedList =
    match linkedList with
    | Empty -> 0
    | Node(value, next) ->
        let countInRest = countOccurrences element next
        if value = element then 1 + countInRest else countInRest


let fromList lst =
    List.foldBack (fun x acc -> Node(x, acc)) lst Empty


let rec printList list =
    match list with
    | Empty -> ()
    | Node(value, next) ->
        printf "%A " value
        printList next

let lista = [1; 2; 3; 4; 1; 2; 5; 1; 2]
let lista2 = fromList lista

printf "Lista: "
printList lista2

let szukanyelement = 1
let wystapienia = countOccurrences szukanyelement lista2
printfn "\nElement %A wystêpuje %d razy w liœcie." szukanyelement wystapienia

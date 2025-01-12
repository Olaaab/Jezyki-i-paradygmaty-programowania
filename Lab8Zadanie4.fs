// Napisz funkcjê, która odwraca kolejnoœæ elementów listy.

type LinkedList<'T> =
    | Empty
    | Node of 'T * LinkedList<'T>

let reverseList linkedList =
    let rec helper acc list =
        match list with
        | Empty -> acc
        | Node(value, next) -> helper (Node(value, acc)) next
    helper Empty linkedList

let fromList lst =
    List.foldBack (fun x acc -> Node(x, acc)) lst Empty

let rec printList list =
    match list with
    | Empty -> ()
    | Node(value, next) ->
        printf "%A " value
        printList next

let lista = [1; 2; 3; 6; 77; 33; 22]
let lista2 = fromList lista

printf "Oryginalna lista: "
printList lista2

let odwroconalista = reverseList lista2

printf "\nOdwrócona lista: "
printList odwroconalista

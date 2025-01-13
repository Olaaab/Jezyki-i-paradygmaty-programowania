// Napisz funkcjê, która tworzy listê ³¹czon¹ na podstawie zwyk³ej listy (List<'T>)

type LinkedList<'T> =
    | Empty
    | Node of 'T * LinkedList<'T>

let fromList lst =
    List.foldBack (fun x acc -> Node(x, acc)) lst Empty

let rec printLinkedList linkedList =
    match linkedList with
    | Empty -> ()
    | Node(value, next) ->
        printf "%A " value
        printLinkedList next

let nowalista = [1; 5; 6; 10]
let laczonalista = fromList nowalista

printf "Lista: "
printLinkedList laczonalista

//Zaimplementuj funkcjê rekurencyjn¹ do wyszukiwania elementu w drzewie binarnym. Napisz te¿ iteracyjn¹ wersjê tej funkcji z u¿yciem stosu symulowanego za pomoc¹ listy.

// Rekurencyjna
type 'a Tree = 
    | Empty
    | Node of 'a * 'a Tree * 'a Tree

let rec findElement tree value =
    match tree with
    | Empty -> false
    | Node(x, left, right) ->
        if x = value then true
        else findElement left value || findElement right value

let tree = Node(5, Node(3, Empty, Empty), Node(8, Empty, Empty))

let result1 = findElement tree 8  
printfn "Element o wartoœci 8 znaleziony: %b" result1

// Iteracyjna
let findElementIterative tree value =
    let rec loop stack =
        match stack with
        | [] -> false
        | Empty :: tail -> loop tail
        | Node(x, left, right) :: tail ->
            if x = value then true
            else loop (left :: right :: tail)
    loop [tree]


let result2 = findElementIterative tree 8  
printfn "Element o wartoœci 8 znaleziony: %b" result2
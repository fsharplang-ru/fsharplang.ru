module Fsharplangru.Views.Helpers
open Giraffe.XmlViewEngine

let class' = attr "class"
let type' = attr "type"
let dataToggle = attr "data-toggle"
let dataTarget = attr "data-target" 
let href = attr "href"
let id' = attr "id"
let role = attr "role"
let ariaExpanded = attr "aria-expanded"
let ariaHidden (b:System.Boolean) = attr "aria-hidden" (b.ToString())


let aBlank h t = a [ href h; attr "target" "_blank" ] [ encodedText t ]

let createListOfLinks a l  =
    [ for (h, t ) in l -> li [] [ a h t ] ]

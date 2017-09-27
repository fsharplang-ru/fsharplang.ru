module Fsharplangru.Views.Navigation
open Giraffe.XmlViewEngine
let class' = attr "class"
let type' = attr "type"
let dataToggle = attr "data-toggle"
let dataTarget = attr "data-target" 
let href = attr "href"
let section = 
    nav [ class'  "navbar navbar-default navbar-fixed-top"] [
        div [ class' "container-fluid content-width" ] [
            div [ class' "navbar-header"  ] [
                button [ type' "button" 
                         class' "navbar-toggle collapsed" 
                         dataToggle "collapse"
                         dataTarget "#bs-example-navbar-collapse-1"
                         ] ([
                             span [ class' "sr-only" ] [encodedText "Переключить навигацию"]
                         ] @ [ for _ in 1..3 -> span [ class' "icon-bar"] [] ])
                a [ class' "navbar-brand" ; href "" ] [
                    img [ attr "src" "/img/min_logo.png" ; class' "inline-block logo" ]
                    encodedText "Русскоязычное сообщество F#"
                 ]
             ]
            div  [] []
         ] 
     ]
module Fsharplangru.Views.Navigation
open Giraffe.XmlViewEngine
open Helpers

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
            div  [ class' "collapse navbar-collapse" ; id' "bs-example-navbar-collapse-1" ] [
                ul [ class' "nav navbar-nav navbar-right" ] (
                    [for (h,t) in [ ("#code-snippets", "Примеры кода") 
                                    ("#top-reasons", "Почему F#") 
                                    ("#online-compiler", "Компилятор онлайн")
                                    ("#video-lessons","Уроки") ] -> li [] [ a [ href h] [ encodedText t ]   ]          
                    ] @ [
                        li [ class' "dropdown" ] [
                            a [ href  "#"
                                class' "dropdown-toggle"
                                dataToggle "dropdown" 
                                role "button"
                                attr "aria-expanded" "false"
                                ] [
                                    encodedText "Сообщество"
                                    span [ class' "caret" ] []
                                ]
                            [
                                "https://gitter.im/fsharplang_ru/Lobby", "Чат в Gitter"
                                "https://t.me/fsharp_chat", "Чат в Telegram"
                                "https://github.com/fsharplang-ru", "Мы на GitHub"
                                "http://fsharp.org/","Официальный сайт F#"
                            ] |> createListOfLinks aBlank 
                            |> ul [ class' "dropdown-menu"; role "menu"] 
                        ] 
                 ])
             ]
         ] 
     ]
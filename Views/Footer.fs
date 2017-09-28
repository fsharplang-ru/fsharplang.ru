module Fsharplangru.Views.Footer
open Giraffe.XmlViewEngine
open Helpers

let private paBlank h t = p [] [ a [ attr "target" "_blank" ; href h ] [ encodedText t ] ]

let private column headerText l = 
    div [ class' "col-sm-2" ] ( 
        [ p [ class' "gray"] [ encodedText headerText ] ] @ [ for (h, t) in l -> paBlank h t ])

let section = 
 section [ class' "darkest-background light"] [
     div [ class' "container content-width footer"] [
         div [ class' "row margin-top margin-bottom" ] [
             [
                 "https://t.me/fsharp_chat" , "Чат в Telegram"
                 "https://gitter.im/fsharplang_ru/Lobby" , "Чат в Gitter"
                 "https://github.com/fsharplang-ru",  "Наш Github"
             ] |>  column "Спросите нас"

             [
                "http://fsharp.org", "Сайт проекта"
                "http://fsharp.org/learn.html", "Обучение F#"
                "http://fsharp.org/about/index.html#documentation", "Документация"
                "http://fsharp.org/specs/language-spec/", "Спецификация"
                "http://fsharp.org/specs/component-design-guidelines/", "Кодстайл"
                "https://github.com/fsharp", "Github"
             ] |> column "FSharp.org"
             
             column "Литература" []
             column "Мероприятия" []
             column "Ещё" []
             div [ class' "col-sm-2"] [
                 a [ href "https://github.com/fsharplang-ru"] [
                     img [ class' "logo-note" ; attr "src" "img/min_logo.png" ]
                 ]
             ]
         ]
         div [ class' "margin-top text-center" ] [
             p [class' "rights" ] [
                 encodedText "Copyright © 2017 fsharplang.ru — Русскоязычное сообщество разработчиков F#"
                 br []
                 small [] [
                     a [attr "target" "_blank"; href "https://worldbeater.github.io"] [
                         encodedText "Designed by Worldbeater"
                     ]
                 ]
             ]
         ]
     ]
 ]
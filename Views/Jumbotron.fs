module Fsharplangru.Views.Jumbotron
open Giraffe.XmlViewEngine
open Helpers

let sectionImage = 
  section [ class' "front-bgr" ] [
      div [ class' "jumbotron content-width container" ] [
          div [ class' "light row"] [
              div [ class' "col-sm-7" ] [
                  h1 [ class' "shadowed" ] [ encodedText "Функциональный кроссплатформенный язык программирования" ]
                  p [ class' "shadowed secondary-title" ] [ encodedText "F# позволяет разработчикам решать сложные задачи с помощью простого и выразительного кода."]
                  p [] [
                      a [class' "btn btn-primary btn-lg scrollable"; href "#code-snippets" ] [
                          encodedText "Узнать больше о F#"
                      ]
                  ]
              ]
              div [ class' "col-sm-5"] []
           ]
       ]
   ]

let sectionWithLogo = 
    section [class' "blue-background" ] [
        div [ class' "container content-width" ] [
            div [class' "row light" ] [
                div [ class' "col-sm-10" ] [
                    p [ class' "light note margin-top margin-bottom" ] [
                        encodedText """F# — это мультипарадигмальный язык программирования из семейства языков .NET Framework, поддерживающий функциональное программирование
                        в дополнение к императивному и объектно-ориентированному программированию."""
                    ]
                ]
                div [ class' "col-sm-2 text-center"] [
                    img [ class' "logo-note"; attr "src" "img/min_logo.png" ]
                ]
            ]
        ]
    ]
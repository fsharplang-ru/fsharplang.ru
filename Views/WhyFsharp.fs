module Fsharplangru.Views.WhyFsharp
open Giraffe.XmlViewEngine
open Helpers


let private card ico headerText txt = 
   div [ class' "col-sm-3 text-center" ] [
                   div [ class' "panel panel-default" ] [
                       div [ class' "panel-body" ] [
                           i [ class' <| sprintf "fa %s icon-image" ico ; ariaHidden true ] []
                           p [ class' "b" ] [ encodedText headerText]
                           encodedText txt
                       ]
                   ]
               ]


let section = 
   section [ class' "dark-background" ] [
       div [ class' "container content-width"] [
           h1 [ id' "top-reasons"; class' "margin-top" ] [
               encodedText "Почему F#? "
               small [] [ 
                   encodedText "Несколько причин обратить внимание на этот язык."
               ]
           ]
           div [ class' "row margin-top margin-bottom" ] [
               card "fa-desktop"   "Кроссплатформенность" "F# работает на Linux, OS X, iOS, Windows, Android, а также в браузерах."
               card "fa-code-fork" "Открытость"           "F# является бесплатным проектом с открытым исходным кодом."
               card "fa-gears"     "Активная разработка"  "F# активно поддерживают как разработчики, так и большие корпорации."
               card "fa-code"      "Write less — do more" "Выбери F# и в несколько раз увеличь свою производительность!"
           ]
       ]
   ]
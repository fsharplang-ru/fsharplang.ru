module Navbar.View

open Fable.Helpers.React
open Fable.Helpers.React.Props

let liHref classy href txt =
   li [] 
      [ a [ ClassName  classy
            Href href ]
          [  str txt ] 
      ]

let repeat e times = 
  let rec loop t s = 
    if t = 0 then
      s
    else
      e::s |> loop (t-1)
  loop times []

let root =
  let iconBar = span [ ClassName "icon-bar"][]
  let logoButtonDiv = 
    div [ClassName "navbar-header"]
                [ button 
                    [ Type "button" 
                      ClassName "navbar-toggle collapsed" 
                      DataToggle "collapse"
                      unbox ("data-target", "#bs-example-navbar-collapse-1")
                      ] 
                    (repeat iconBar 3)
                  a [ ClassName "navbar-brand"] 
                    [ img [ ClassName "inline-block logo"
                            Src "./img/min_logo.png" ]
                      str "Русскоязычное сообщество F#" ] ]
  let scrlblLiHref = liHref "scrollable"    
  let societeList = 
    ul [ ClassName "dropdown-menu" ; Role "menu" ]
       [  li [] [a [Href "https://t.me/fsharp_chat"; Target "_blank" ] [str "Чат в Telegram" ] ]
          li [] [a [Href "https://gitter.im/fsharplang_ru/Lobby"; Target "_blank" ] [str "Чат в Gitter" ] ]         
          li [] [a [Href "https://github.com/fsharplang-ru"; Target "_blank" ] [str "Мы на GitHub" ] ]
          li [] [a [Href "http://fsharp.org/"; Target "_blank" ] [str "Официальный сайт F#" ] ] ] 

  let linksDiv = 
    div [ ClassName "collapse navbar-collapse" 
          Id "bs-example-navbar-collapse-1" ] 
        [ ul [ ClassName "nav navbar-nav navbar-right" ]
             [ scrlblLiHref "#code-snippets" "Примеры кода"
               scrlblLiHref "#top-reasons" "Почему F#" 
               scrlblLiHref "#online-compiler" "Компилятор онлайн"
               scrlblLiHref "#video-lessons" "Видео"
               li  [ ClassName "dropdown" ]
                   [ a [ Href "#"; ClassName "dropdown-toggle" ; DataToggle "dropdown"; Role "button"; unbox("aria-expanded", "false") ]
                       [ str "Сообщество " ; span [ClassName "caret"] [] ] 
                     societeList ]
               ] ]
  nav
    [ ClassName "navbar navbar-default navbar-fixed-top" ]
    [ div [ ClassName "container-fluid content-width" ]
          [ logoButtonDiv
            linksDiv ] ]

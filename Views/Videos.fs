module Fsharplangru.Views.Videos 
open Giraffe.XmlViewEngine
open Helpers

let private vid href = 
    div [ class' "col-sm-4"] [
        rawText <| sprintf """<iframe class="margin-bottom" height="220" src="%s" frameborder="0" allowfullscreen ></iframe>""" href
    ]

let section = 
  section [ class' "dark-background" ]  [
      div [ class' "container content-width" ] [
          h1 [ id' "video-lessons"; class' "margin-top margin"] [
              encodedText "Обучающие видео. "
              small [] [
                  encodedText "Уроки, которые помогут вам научиться F#!"
              ]
          ]
          div [ class' "row text-center"] [ 
              vid "https://www.youtube.com/embed/mOS5qTd7JRY?ecver=1"
              vid "https://www.youtube.com/embed/hmDvOoaZXxc?ecver=1"
              vid "https://www.youtube.com/embed/Bn132AtZLhc?ecver=1"
          ]
      ]
  ]
module Fsharplangru.Views.Layout
open Giraffe.XmlViewEngine

let stylesheet href = 
    link [ attr "rel" "stylesheet"; attr "type" "text/css" ; attr "href" href ]
let loadJS src = 
    script [attr "type" "text/javascript"; attr "src" src] []
let page txt content = 
    html [] [
        head [] [
            meta [ attr "http-equiv" "X-UA-Compatible"; attr "content" "IE=edge"  ]
            meta [ attr "http-equiv" "Content-Type"; attr "content" "text/html;charset=utf-8"  ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0"  ]
            link [ attr "rel" "icon"; attr "href" "/img/favicon.ico?v=1.1" ]
            stylesheet "/css/font-awesome.min.css"
            stylesheet "/css/bootstrap.css"
            stylesheet "/css/additional.css"
            stylesheet "/css/default.css"
            loadJS "/js/highlight.pack.js"
            loadJS "/js/jquery.min.js"
            loadJS "/js/bootstrap.js"
            loadJS "/monaco/min/vs/loader.js"
            title [] [encodedText txt]
        ]
        body [] [
            main [] content
        ]
    ]
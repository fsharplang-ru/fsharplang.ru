module FSharpLangRu.Components

open Browser
open Browser.Types
open Fable.React
open Fable.React.Props
          
let row elements =
    let column = sprintf "col-lg-%i" <| 12 / Seq.length elements
    div [ ClassName "row container-fluid" ] [
        for element in elements do 
        yield div [ ClassName column ] [ element ] ]
        
let card title description icon =
    let icon = sprintf "icon-image text-primary fa fa-%s" icon
    div [ ClassName "card text-center rounded mt-3 border-light"
          Style [ BoxShadow "0 1px 1px rgba(0, 0, 0, 0.05)" ] ] [
        div [ Style [ FontSize "90px" ] ] [ i [ ClassName icon ] [] ]
        div [ ClassName "card-body pt-0" ] [
            div [ ClassName "card-title text-uppercase mb-1" ] [ b [] [ str title ] ]
            p [ ClassName "card-text" ] [ str description ] ] ]

let layout color shadow title subtitle nested =
    div [ Style [ Fable.React.Props.BoxShadow shadow; BackgroundColor color ] ] [
        div [ ClassName "container pb-5 pt-3" ] [
            h1 [ ClassName "mt-3 mb-2 ml-3" ] [ 
                str title 
                small [ ClassName "ml-2 text-muted" ] [
                    small [ Style [ FontWeight "300" ] ] [ 
                        str subtitle ] ] ]
            div [] nested ] ]
            
let code samples =
    let select identity (link: obj) =
        let tab = document.getElementById identity
        let link = link :?> HTMLLinkElement
        link.classList.toggle("active", true) |> ignore
        tab.classList.toggle("show", true) |> ignore
        failwith "PIDOR"
        
    div [ ClassName "ml-3" ] [
        ul [ ClassName "nav nav-tabs" ] [
            for (identity, title, _) in samples do
            let reference = sprintf "#%s" identity
            yield li [ ClassName "nav-item" ] [
                a [ OnClick (fun e -> select identity e.target)
                    ClassName "nav-link" 
                    Href reference ] [ str title ] ] ]
        div [ ClassName "tab-content" ] [
            for (identity, _, code) in samples do
            yield div [ ClassName "tab-pane fade" 
                        Id identity ] [ str code ] ] ]
    
let lightLayout title subtitle = layout "#ffffff" "" title subtitle
                        
let darkLayout title subtitle = layout "#f9f9f9" "inset 0 10px 30px -10px rgba(0, 0, 0, .05), 
                                   inset 0 -10px 30px -10px rgba(0, 0, 0, .05)" title subtitle
                                   
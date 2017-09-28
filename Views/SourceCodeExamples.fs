module Fsharplangru.Views.SourceCodeExamples
open Giraffe.XmlViewEngine
open Helpers

let private liNav cls hr txt = 
    li [ class' cls ] [
           a [ href hr; dataToggle "tab"; ariaExpanded "true" ] 
             [ encodedText txt]
       ]

let private tabNav = 
   ul [ class' "nav nav-tabs"] [
       liNav "active" "#simple-code"    "Простой и понятный код"
       liNav ""       "#concise-syntax" "Лаконичный синтаксис"
       liNav ""       "#type-system"    "Мощная система типов"
       liNav ""       "#pipelines"      "Пайплайны"
   ]

let private codeTab (cls:string) i codeExample = 
    div [ class' ("tab-pane fade in" + cls) ; id' i ] [
        pre [ class' "margin-top managed-code-block" ] [
            code [ class' "fsharp code-holder"] [
                encodedText codeExample
            ]
        ]
    ]

let private simpleCodeSrc = """[<EntryPoint>]
let main argv =
    printfn "%A" argv
    0"""
let private conciseSyntaxSrc = """let rec fib n a b = match n with
    | 0 -> a
    | 1 -> b
    | _ -> fib (n - 1) b (a + b)"""

let private typeSystemSrc = """type ContactInfo =
    | EmailOnly of EmailInfo
    | PostOnly of PostInfo
    | EmailPost of EmailInfo * PostInfo"""

let private pipelinesSrc = """let messages =
    friends
    |> Seq.map (fun x -> x.Messages)
    |> Seq.concat"""

let section = 
    section [] [
        div [ class' "container content-width" ] [
            h1 [ id' "code-snippets" ; class' "margin-top margin-bottom" ] [
                encodedText "Как выглядит F#? " 
                small [] [ encodedText "Самые простые примеры кода."]
            ]
            tabNav
            div [ class' "tab-content"; id' "myTabContent"] [
                codeTab "active" "simple-code"     simpleCodeSrc
                codeTab ""        "concise-syntax" conciseSyntaxSrc
                codeTab ""        "type-system"    typeSystemSrc
                codeTab ""        "pipelines"      pipelinesSrc
            ]
        ]
    ]
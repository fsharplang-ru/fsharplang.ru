module Fsharplangru.Views.TryOnline
open Giraffe.XmlViewEngine
open Helpers

let section = 
    section [] [
        div [ class' "container content-width" ] [
            h1 [ id' "online-compiler" ; class' "margin-top margin-bottom"] [
                encodedText "Попробоуйте сами! "
                small [] [
                    encodedText "Скомпилируйте свой первый F# скрипт онлайн."
                ]
            ]

            div [ class' "row" ] [
                div [ class' "col-sm-7"] [
                    div [ id' "monaco-container"] []
                    a [ id' "build-run-button" ; class' "btn btn-info margin-top margin-bottom"] [
                        encodedText "Собрать изапустить"
                    ]
                ]
                div [ class' "col-sm-5" ] [
                    p [] [
                        b [] [ encodedText "ВЫВОД:"]
                        div [ class' "margin-bottom"] [
                            div [ id' "run-status-box" ; class' "code-box"] []
                            div [ id' "run-warnings-box" ; class' "code-box warning"] []
                            div [ id' "run-errors-box" ; class' "code-box error"] []
                            code [ id' "run-result-box"] [ encodedText "0" ]
                        ]
                        p [] [
                            encodedText "Возникли трудености?"
                            br []
                            encodedText "Напишите нам в "
                            a [ href "https://t.me/fsharp_chat" ] [ encodedText "Telegram" ] 
                            encodedText " или "
                            a [ href "https://gitter.im/fsharplang_ru/Lobby"] [ encodedText "Gitter"]
                            encodedText " и мы с радостью вам поможем!"
                        ]
                    ]
                ]
            ]
        ]
    ]
module FSharpLangRu.App

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Components
open Elmish.React
open Elmish
             
let view model dispatch = 
    section [] [
        lightLayout "Как выглядит F#?" "Самые простые примеры кода." [
            code [ ("simple-code", "Простой и понятный код", "code here")
                   ("convenient-syntax", "Лаконичный синтаксис", "syntax here")
                   ("powerful-types", "Продвинутая система типов", "types here")
                   ("inline-functions", "Мощь инлайн функций", "inlines here3") ] ]
        darkLayout "Почему F#?" "Несколько причин обратить внимание на этот язык." [
            row [ card "Кросплатформенность" "F# работает на Linux, OS X, iOS, Windows, Android, а также в браузерах." "desktop"
                  card "Открытость" "F# является бесплатным проектом с открытым исходным кодом." "code-fork" 
                  card "Активная разработка" "F# активно поддерживают как разработчики, так и большие корпорации." "gears" 
                  card "Write less — do more" "Выбери F# и в несколько раз увеличь свою производительность!" "code" ] ]
        lightLayout "Попробуйте сами!" "Скомпилируйте свой первый F# скрипт онлайн." []
        darkLayout "Обучающие видео." "Уроки, которые помогут вам научиться F#!" []
    ]
        
let init _ = 0
 
let update message count = 
    count + 1

Program.mkSimple init update view
|> Program.withReact "elmish-app"
|> Program.withConsoleTrace
|> Program.run 

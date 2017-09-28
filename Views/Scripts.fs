module Fsharplangru.Views.Scripts
open Giraffe.XmlViewEngine

let private src = """
        (function ($) {

            // Register smooth animators
            const bodyPart = $('html, body');
            $('a.scrollable').click(function (event) {
                event.preventDefault();
                bodyPart.animate({
                    scrollTop: $($.attr(this, 'href')).offset().top - 80
                }, 500);
                return false;
            });

            // Init highlight.JS for syntax highlighting
            hljs.initHighlightingOnLoad();

            // Get links to needed elements
            const monacoContainer = $('#monaco-container');
            const runButton = $("#build-run-button");
            const statusBox = $('#run-status-box');
            const warningsBox = $('#run-warnings-box');
            const errorsBox = $('#run-errors-box');
            const resultBox = $("#run-result-box");

            // Set initial content of Monaco editor
            const initialCodeContent =
                "// Фигура\n" +
                "type Shape =\n" +
                "    | Rectangle of height : float * width : float\n" +
                "    | Ellipse of radiusV : float * radiusH : float\n" +
                "\n" +
                "// Функция, вычисляющая площадь фигуры\n" +
                "let area shape = \n" +
                "    match shape with\n" +
                "    | Rectangle(h, w) -> h * w\n" +
                "    | Ellipse(rv, rh) -> System.Math.PI * rv * rh\n" +
                "\n" +
                "// Точка входа приложения, эквивалент main()\n" +
                "[<EntryPoint>]\n" +
                "let main argv =\n" +
                "    let ellipse = Ellipse(2., 1.)\n" +
                "    printfn \"%A\" (area ellipse)\n" +
                "    0 // код завершения приложения\n";

            // Launch Monaco online editor
            require.config({ paths: { 'vs': 'monaco/min/vs' } });
            require(['vs/editor/editor.main'], function () {
                window.editor = monaco.editor.create(monacoContainer[0], {
                    value: initialCodeContent,
                    theme: 'vs',
                    language: 'fsharp'
                });
            });

            // Register events
            runButton.click(function () {
                const enterErrorState = function () {
                    statusBox.text('ⓧ Ошибка').removeClass('success').removeClass('warning').addClass('error');
                };
                const enterWarningState = function () {
                    statusBox.text('⚠ Предупреждение').removeClass('success').addClass('warning').removeClass('error');
                };
                const enterSuccessState = function () {
                    statusBox.text('✔ Успех').addClass('success').removeClass('warning').removeClass('error');
                };

                const program = window.editor.getValue();
                const url = 'http://rextester.com/rundotnet/api';
                const fsharp = 3; // in rextester encoding
                const params = {
                    LanguageChoice: fsharp,
                    Program: program
                };

                runButton.addClass('disabled');
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: params
                }).done(function (data) {
                    const warnings = data.Warnings;
                    const errors = data.Errors;
                    const result = data.Result;
                    warningsBox.text(warnings);
                    errorsBox.text(errors);
                    resultBox.text(result);
                    if (errors) {
                        enterErrorState();
                    } else if (warnings) {
                        enterWarningState();
                    } else {
                        enterSuccessState();
                    }
                }).fail(function () {
                    warningsBox.clear();
                    errorsBox.text('ⓧ Сетевая ошибка. Пожалуйста, повторите запрос.');
                    enterErrorState();
                }).always(function () {
                    runButton.removeClass('disabled');
                });
            });

        })($);
"""

let code = 
   script [ attr "type" "text/javascript"] [
       rawText src
   ]
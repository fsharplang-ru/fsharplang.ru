module FSharplang_ru.App

open System
open System.IO
open System.Collections.Generic
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe.HttpHandlers
open Giraffe.Middleware


// ---------------------------------
// Web app
// ---------------------------------

let redirectTo route  =
    fun (ctx:HttpHandlerContext) -> 
        ctx.HttpContext.Response.Redirect route
        ctx |> Some |> async.Return


let webApp = 
    choose [
        // GET >=>
        //     choose [
        //         route "/" >=> razorHtmlView "Index" { Text = "Hello world, from Giraffe!" }
        //         route "/index" >=> htmlFile  (Path.Combine "./../client/index.html" )
        //         route "/blog" >=> redirectTo "/blog/"
        //     ]
        setStatusCode 404 >=> text "Not Found" ]

// ---------------------------------
// Error handler
// ---------------------------------

let errorHandler (ex : Exception) (ctx : HttpHandlerContext) =
    ctx.Logger.LogError(EventId(0), ex, "An unhandled exception has occurred while executing the request.")
    ctx |> (clearResponse >=> setStatusCode 500 >=> text ex.Message)

// ---------------------------------
// Config and Main
// ---------------------------------

let configProxyPath (app:IApplicationBuilder) from toscheme tohost  toport =
    let proxyInfo = ProxyOptions()
    proxyInfo.Scheme <- toscheme
    proxyInfo.Host <- tohost 
    proxyInfo.Port <- toport 
    let predicateWhen (path:string) (x:HttpContext) = 
        let path' = x.Request.Path
        if path'.HasValue && path'.Value.StartsWith(path) then 
            let mutable newPath = path'.Value.Remove(0,path.Length)  
            if newPath.StartsWith("/") |> not then 
                newPath <- "/" +  newPath
            x.Request.Path <- PathString(newPath)
            true
        else
            false

    let proxyPathRouter = 
        predicateWhen from
    let configuration (a:IApplicationBuilder) = 
        a.RunProxy(proxyInfo) |> ignore
    app.MapWhen <| ( (Func<HttpContext, bool> proxyPathRouter),  ( Action<IApplicationBuilder> configuration )) |> ignore


let configureApp (app : IApplicationBuilder) = 
    configProxyPath app "/" "http" "fsharplang-ru.github.io" "80"
    app.UseGiraffeErrorHandler(errorHandler)
    app.UseGiraffe(webApp)
    

    
    

let configureServices (services : IServiceCollection) =
    let sp  = services.BuildServiceProvider()
    let env = sp.GetService<IHostingEnvironment>()
    let viewsFolderPath = Path.Combine(env.ContentRootPath, "Views")
    services.AddRazorEngine(viewsFolderPath) |> ignore

let configureLogging (loggerFactory : ILoggerFactory) =
    loggerFactory.AddConsole(LogLevel.Trace).AddDebug() |> ignore

[<EntryPoint>]
let main argv =                                
    WebHostBuilder()
        .UseKestrel()
        .UseUrls("http://localhost:5000/")
        .UseContentRoot(Directory.GetCurrentDirectory())
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(Action<IServiceCollection> configureServices)
        .ConfigureLogging(Action<ILoggerFactory> configureLogging)
        .Build()
        .Run()
    0
// open System.Runtime.Versioning
// open Avalonia
// open Avalonia.Browser
// #if (ReactiveUIToolkitChosen)
// open Avalonia.ReactiveUI
// #endif
// open AvaloniaTest
//
// module Program =
//     [<assembly: SupportedOSPlatform("browser")>]
//     do ()
//
//     [<CompiledName "BuildAvaloniaApp">] 
//     let buildAvaloniaApp () = 
//         AppBuilder
//             .Configure<App>()
//
//     [<EntryPoint>]
//     let main argv =
//         task {
//             do! (buildAvaloniaApp()
//             .WithInterFont()
// #if (ReactiveUIToolkitChosen)
//             .UseReactiveUI()
// #endif
//             .StartBrowserAppAsync("out"))
//         }
//         |> ignore
//         0

namespace FabAvaloniaTemplate.Browser

open System.Diagnostics
open System.Runtime.Versioning
open Avalonia
open Avalonia.Browser
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Logging
open Avalonia.Threading
open Aperture.Core


module Program =
    [<assembly: SupportedOSPlatform("browser")>]
    do ()

    [<CompiledName "BuildAvaloniaApp">]
    let buildAvaloniaApp () = App.create()

    [<EntryPoint>]
    let main argv =
        Trace.Listeners.Add(new ConsoleTraceListener()) |> ignore

        buildAvaloniaApp()
            .LogToTrace(LogEventLevel.Warning)
            .StartBrowserAppAsync("out", BrowserPlatformOptions())
        |> ignore

        0

namespace Feliz

open System.ComponentModel
open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Feliz

[<EditorBrowsable(EditorBrowsableState.Never)>]
module Object =
    [<Emit("$0 === undefined")>]
    let private isUndefined x = jsNative

    let fromFlatEntries (kvs: seq<string * obj>) : obj =
        let rec setProperty (target : obj) (key : string) (value : obj) =
            match key.IndexOf '.' with
            | -1 -> target?(key) <- value
            | sepIdx ->
                let topKey = key.Substring (0, sepIdx)
                let nestedKey = key.Substring (sepIdx + 1)
                if isUndefined target?(topKey) then
                    target?(topKey) <- obj ()
                setProperty target?(topKey) nestedKey value

        let target = obj ()
        for (key, value) in kvs do
            setProperty target key value
        target

[<AutoOpen; EditorBrowsable(EditorBrowsableState.Never)>]
module ReactInputMaskHelpers =

    let reactElement (el: ReactElementType) (props: 'a) : ReactElement =
        import "createElement" "react"

    let reactElementTag (tag: string) (props: 'a) : ReactElement =
        import "createElement" "react"

    let createElement (el: ReactElementType) (properties: IReactProperty seq) : ReactElement =
        reactElement el (!!properties |> Object.fromFlatEntries)

    let createElementTag (tag: string) (properties: IReactProperty seq) : ReactElement =
        reactElementTag tag (!!properties |> Object.fromFlatEntries)

type onLoadSuccessResult = {
    numPages : int
}

type onLoadErrorResult = {
    message : string
}

type fileRequest = {
    url : string option
    data : byte array option
}

type reactPdf =
    static member inline pageNumber (value : int) = Interop.mkAttr "pageNumber" value
    static member inline scale (value : float) = Interop.mkAttr "scale" value
    static member inline url (value : string) = Interop.mkAttr "url" value
    static member inline file (value : string) = Interop.mkAttr "file" value
    static member inline fileFromRecord (value : fileRequest) = Interop.mkAttr "file" value
    static member inline pageIndex (value : int) = Interop.mkAttr "pageNumber" value
    static member inline renderMode (value : string) = Interop.mkAttr "renderMode" value
    static member inline onLoadSuccess (value : onLoadSuccessResult option -> unit) = Interop.mkAttr "onLoadSuccess" value
    static member inline onLoadError (value : onLoadErrorResult -> unit) = Interop.mkAttr "onLoadError" value
    static member inline onRenderSuccess (value : unit -> unit) = Interop.mkAttr "onRenderSuccess" value
    static member inline onRenderError (value : unit -> unit) = Interop.mkAttr "onRenderError" value
    static member inline loading (value : string) = Interop.mkAttr "loading" value
    static member inline loadingElem (value : ReactElement) = Interop.mkAttr "loadingElem" value
    static member inline loadingFn (value : unit -> ReactElement) = Interop.mkAttr "loadingFn" value
    static member inline externalLinkTarget (value : string) = Interop.mkAttr "externalLinkTarget" value
    static member inline imageResourcesPath (value : string) = Interop.mkAttr "imageResourcesPath" value
    static member inline error (value : ReactElement) = Interop.mkAttr "error" value

type ReactPdf =
    static member inline document props = createElement (import "Document" "react-pdf/dist/esm/entry.webpack") props
    static member inline page props = createElement (import "Page" "react-pdf/dist/esm/entry.webpack") props
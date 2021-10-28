namespace App

open Fable
open Fable.React.Helpers
open Fable.MaterialUI.Icons
open Feliz
open Feliz.MaterialUI

type Components =
    /// <summary>
    /// Display a sample document.
    /// </summary>
    [<ReactComponent>]
    static member TestReactPdf () =
        let numPages, setNumPages = React.useState(1)
        let pageNumber, setPageNumber = React.useState(1)
        let pdfOpen, setPdfOpen = React.useState(false)

        let onDocumentLoadSuccess (pdf) =
            match pdf with
            | Some p -> 
                setNumPages p.numPages
            | None -> setNumPages 1

        let onPageUp _ =
            if pageNumber < numPages then
                setPageNumber (pageNumber + 1)

        let onPageDown _ =
            if pageNumber > 1 then
                setPageNumber (pageNumber - 1)

        let button =
            Html.div [
                Mui.button [
                    button.variant.contained
                    prop.onClick (fun _ -> setPdfOpen true)
                    prop.text "Open PDF"
                ]
            ]
        
        let pdfModal =
            Mui.modal [
                modal.open' pdfOpen
                modal.children (
                    Mui.card [
                        Html.div [
                            Mui.iconButton [
                                prop.onClick onPageDown
                                prop.children [
                                    arrowLeftIcon []
                                ]
                            ]
                            str (sprintf "%i of %i pages" pageNumber numPages)
                            Mui.iconButton [
                                prop.onClick onPageUp
                                prop.children [
                                    arrowRightIcon []
                                ]
                            ]
                        ]
                        Html.div [
                            Mui.iconButton [
                                prop.onClick (fun _ -> setPdfOpen false)
                                prop.children [
                                    closeIcon []
                                ]
                            ]
                        ]
                        Html.div [
                            prop.tabIndex -1
                            prop.children [
                                ReactPdf.document [
                                    reactPdf.file "FableResources.pdf"
                                    reactPdf.onLoadSuccess onDocumentLoadSuccess
                                    reactPdf.scale 1.5
                                    prop.children [
                                        ReactPdf.page [
                                            reactPdf.pageNumber pageNumber
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                )
            ]

        Html.div [
            button
            pdfModal
        ]


module Modules

open System.IO
open System
open System.Text.RegularExpressions

//Single case active patterns
//Example 7.1 - Single case active pattern
//Convert a file path into its extension
let (|FileExtension|) filePath = Path.GetExtension(filePath)

let determineFileType (filePath : string) =
    match filePath with
    //Without active patterns
    | filePath when Path.GetExtension(filePath) = ".txt"
        -> printfn "It's a text file."
    //Converting the data using an active pattern
    | FileExtension ".jpg"
    | FileExtension ".png"
    | FileExtension ".gif"
        -> printfn "It is an image file."

    // Binding a new value
    | FileExtension ext
        -> printfn "Unknown file extension [%s]" ext

//7.2 - partial active pattern

let (|ToBool|_|) x =
    let success, result = Boolean.TryParse(x)
    if success then Some(result)
    else None

let (|ToInt|_|) x =
    let success, result = Int32.TryParse(x)
    if success then Some(result)
    else None

let (|ToFloat|_|) x =
    let success, result = Double.TryParse(x)
    if success then Some(result)
    else None

let describeString str =
    match str with
    | ToBool b -> printfn "%s is a bool with a value %b" str b
    | ToInt i -> printfn "%s is an int with a value %i" str i
    | ToFloat f -> printfn "%s is a float with a value %f" str f
    | _ -> printfn "%s is not a bool, int or a float" str

//Parameterized active patterns
let (|RegexMatch3|_|) (pattern : string) (input : string) =
    let result = Regex.Match(input,pattern)

    if result.Success then
        match (List.tail [ for g in result.Groups -> g.Value]) with
        |fst :: snd :: trd :: [] -> Some(fst,snd,trd)
        | [] -> failwith <| "Match succeeded, but no groups found. \n" + " Use '(.*)' to capture groups"
        | _ -> failwith "Match succeeded, but did not find exactly three groups. "
    else None

let parseTime input =
    match input with
    //Match input of the form "6/20/2008"
    | RegexMatch3 "(\d+)/(\d+)/(\d\d\d\d)" (month,day,year)
    //Match inout of the form ""2004-12-8
    | RegexMatch3 "(\d\d\d\d)-(\d+)-(\d+)" (year,month,day)
        -> Some( new DateTime(int year, int month, int day) )
    | _ -> None


//Using active patterns 
let (|ToUpper|) (input : string) = input.ToUpper()
let f (ToUpper x) = printfn "x = %s" x


//Example 7-11 Effective list manipulation
let removeConsecutiveeDupes lst =
    let f item acc =
        match acc with
        | [] -> [item]
        | hd :: tl when hd <> item
            -> item :: acc
        | _ -> acc
    
    List.foldBack f lst []


module WebScraperModule =
    open System.IO
    open System.Net
    open System.Text.RegularExpressions

    let imagesPath = @"C:\src"
    let url = "http://oreilly.com/"

    type WebScraper(url) =

        //Download the website
        let downloadWebpage (url : string) =
            let req = WebRequest.Create(url)
            let resp = req.GetResponse()
            let stream = resp.GetResponseStream()
            let reader = new StreamReader(stream)
            reader.ReadToEnd()

    
        //Extract all images
        let extractImageLinks (html : string) =
            let results = Regex.Matches(html, "<img src =\"([^\"]*)\"")
            [
                for r in results do
                    for grpIdx = 1 to r.Groups.Count - 1 do
                        yield r.Groups.[grpIdx].Value
            ] |> List.filter (fun url -> url.StartsWith("http://"))

        let downloadToDisk (url : string) (filePath : string) =
            use client = new System.Net.WebClient()
            client.DownloadFile (url,filePath)

        let scrapeWebsite destPath (imageUrls : string list) =
            imageUrls
            |> List.map(fun url ->
                let parts = url.Split( [| '/' |] )
                url, parts.[parts.Length - 1])
            |> List.iter(fun (url, fileName) ->
                downloadToDisk url (Path.Combine(destPath, fileName)))

        //Add class fields
        let m_html = downloadWebpage url
        let m_images = extractImageLinks m_html
        //Add class members
        member this.SaveImagesToDisk(destPath) =
            scrapeWebsite destPath m_images

    let testWebScraper = WebScraper url

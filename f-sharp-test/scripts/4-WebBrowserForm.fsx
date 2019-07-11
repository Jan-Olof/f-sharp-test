open System
open System.Net
open System.Windows.Forms

let browserFunc(uri, text) =
    let fsharpOrg =
        let webClient = new WebClient()
        webClient.DownloadString(Uri uri)

    let form = new Form(Text = text)
    let browser = new WebBrowser(ScriptErrorsSuppressed = true, Dock = DockStyle.Fill, DocumentText = fsharpOrg)

    form.Controls.Add browser
    form.Show()

browserFunc("http://fsharp.org", "Hello from F#!")
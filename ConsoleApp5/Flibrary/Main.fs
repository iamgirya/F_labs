module WinFormsApp1.Main

open System
open System.Windows.Forms
open System.Drawing

[<EntryPoint; STAThread>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    use form = new StartupForm()

    let text = new TextBox(Width= 350, ReadOnly = true, Text="Введите по форме: aХ^2 + bХ + с")
    let richTextBox2 = new RichTextBox(Font = new Font(familyName = "Segoe UI",emSize = 22.0f),Width = 200, Top = 50, Left = 0,Text="1")
    let richTextBox3 = new RichTextBox(Font = new Font(familyName = "Segoe UI",emSize = 22.0f),Width = 200, Top = 50, Left = 200,Text="1")
    let richTextBox4 = new RichTextBox(Font = new Font(familyName = "Segoe UI",emSize = 22.0f),Width = 200, Top = 50, Left = 400,Text="1")
    let richTextBox1 = new RichTextBox(Font = new Font(familyName = "Segoe UI",emSize = 18.0f), Width = 700, Top = 200, Left = 0,Text="")
    let button1 = new Button(Height=50, Width = 150, Top = 0, Left = 350,Text="Вычислить")
    let _ = button1.Click.Add((fun (e:EventArgs) -> 
        try 
            let a = double(richTextBox2.Text)
            let b =  double(richTextBox3.Text)
            let c =  double(richTextBox4.Text)   
            let d = b*b - 4.0*a*c
            let output = 
                if (d > 0.0)
                then "X1 = " + Convert.ToString((-b+Math.Sqrt(d))/(2.0*a)) + " X2 = " + Convert.ToString((-b-Math.Sqrt(d))/(2.0*a))
                elif (d = 0.0)
                then "X = " + Convert.ToString((-b)/(2.0*a))
                else 
                    let sign,supsign = if (a > 0.0) then '+','-' else '-','+'
                    "X1 = " + Convert.ToString((-b)/(2.0*a)) + Convert.ToString(sign) + "sqrt(" + Convert.ToString((d/4.0)/(a*a)) + ") X2 = " + Convert.ToString((-b)/(2.0*a)) + Convert.ToString(supsign) + "sqrt(" + Convert.ToString((d/4.0)/(a*a)) + ")"
            richTextBox1.Text <- output
        with
        | _ ->
            richTextBox1.Text <- "Ошибка ввода!"
            ))
    form.Controls.Add(text)
    form.Controls.Add(richTextBox2)
    form.Controls.Add(richTextBox3)
    form.Controls.Add(richTextBox4)
    form.Controls.Add(richTextBox1)
    form.Controls.Add(button1)
    Application.Run(form)    
    0 
namespace WinFormsApp1
open WinFormsApp1
open System
open System.Windows.Forms

type StartupForm() as this = 
    inherit Form1()
    do
        this.button1.Click.Add <| fun _ -> 
        try 
            let a = double(this.richTextBox2.Text)
            let b =  double(this.richTextBox3.Text)
            let c =  double(this.richTextBox4.Text)   
            let d = b*b - 4.0*a*c
            let output = 
                if (d > 0.0)
                then "X1 = " + Convert.ToString((-b+Math.Sqrt(d))/(2.0*a)) + " X2 = " + Convert.ToString((-b-Math.Sqrt(d))/(2.0*a))
                elif (d = 0.0)
                then "X = " + Convert.ToString((-b)/(2.0*a))
                else 
                    let sign,supsign = if (a > 0.0) then '+','-' else '-','+'
                    "X1 = " + Convert.ToString((-b)/(2.0*a)) + Convert.ToString(sign) + "sqrt(" + Convert.ToString((d/4.0)/(a*a)) + ") X2 = " + Convert.ToString((-b)/(2.0*a)) + Convert.ToString(supsign) + "sqrt(" + Convert.ToString((d/4.0)/(a*a)) + ")"
            this.richTextBox1.Text <- output
        with
        | _ ->
            this.richTextBox1.Text <- "Ошибка ввода!"
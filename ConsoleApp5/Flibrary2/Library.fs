open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
let mwXaml = " 
<Window 
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
 xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
 Title='F# WPF' Height='300' Width='300'>
 <Grid>
 <GroupBox Header='Введите по форме: aХ^2 + bХ + с' Height='100' HorizontalAlignment='Left' Name='groupBox1' VerticalAlignment='Top' Width='350' 
 Grid.ColumnSpan='2'>
  <Grid>
  <TextBox Height = '25' HorizontalAlignment = 'Left' Margin = '56,-50,0,0' Name = 'textBox1' Width = '150' Grid.ColumnSpan='3'  />
  <TextBox Height = '25' HorizontalAlignment = 'Left' IsReadOnly='True' Text = 'a*X^2' Margin = '6,-50,0,0' Name = 'textBox11' Width = '50' Grid.ColumnSpan='2'  />
  <TextBox Height = '25' HorizontalAlignment = 'Left' Margin = '56,0,0,0' Name = 'textBox2' Width = '150' Grid.ColumnSpan='2' />
  <TextBox Height = '25' HorizontalAlignment = 'Left' IsReadOnly='True' Text = 'b*X' Margin = '6,0,0,0' Name = 'textBox12' Width = '50' Grid.ColumnSpan='2'  />
  <TextBox Height = '25' HorizontalAlignment = 'Left' Margin = '56,50,0,0' Name = 'textBox3' Width = '150' Grid.ColumnSpan='2' />
  <TextBox Height = '25' HorizontalAlignment = 'Left' IsReadOnly='True' Text = 'c' Margin = '6,50,0,0' Name = 'textBox13' Width = '50' Grid.ColumnSpan='2'  />
  <Button Content='Вычислить' Height='75' HorizontalAlignment='Left' Margin='206,1,0,0' Name='button0' VerticalAlignment='Top' 
  Width='75' Grid.Column='2' />
  </Grid>
  </GroupBox>
 
 <Grid>
<TextBox Height = '50' TextWrapping='Wrap' AcceptsReturn='True' HorizontalAlignment = 'Left' Text = '' Margin = '6,0,0,0' Name = 'textBox4' Width = '250' Grid.ColumnSpan='2'  />
 </Grid>

 </Grid>
</Window>
" 
// загрузка разметки XAML
let getWindow(mwXaml) =
    let xamlObj=XamlReader.Parse(mwXaml)
    xamlObj :?> Window

let win = getWindow(mwXaml)
//получение экземпляров элементов управления 

//главная форма:

let button0 = win.FindName("button0") :?> Button
let textbox1 = win.FindName("textBox1") :?>TextBox
let textbox2 = win.FindName("textBox2") :?>TextBox
let textbox3 = win.FindName("textBox3") :?>TextBox
let textbox4 = win.FindName("textBox4") :?>TextBox

textbox1.Text<-"1"
textbox2.Text<-"1"
textbox3.Text<-"1"
//обработка событий

//button5.Click.AddHandler(fun _ _ -> win.Top <- win.Top - 10.)
button0.Click.Add(fun e -> 
    try 
        let a = double(textbox1.Text)
        let b =  double(textbox2.Text)
        let c =  double(textbox3.Text)   
        let d = b*b - 4.0*a*c
        let output = 
            if (d > 0.0)
            then "X1 = " + Convert.ToString((-b+Math.Sqrt(d))/(2.0*a)) + " X2 = " + Convert.ToString((-b-Math.Sqrt(d))/(2.0*a))
            elif (d = 0.0)
            then "X = " + Convert.ToString((-b)/(2.0*a))
            else 
                let sign,supsign = if (a > 0.0) then '+','-' else '-','+'
                "X1 = " + Convert.ToString((-b)/(2.0*a)) + Convert.ToString(sign) + "sqrt(" + Convert.ToString((d/4.0)/(a*a)) + ") X2 = " + Convert.ToString((-b)/(2.0*a)) + Convert.ToString(supsign) + "sqrt(" + Convert.ToString((d/4.0)/(a*a)) + ")"
        textbox4.Text <- output
    with
    | _ ->
        textbox4.Text <- "Ошибка ввода!"
        )




[<STAThread>] ignore <| (new Application()).Run win 
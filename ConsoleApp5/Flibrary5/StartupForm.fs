namespace WinFormsApp1
open WinFormsApp1
open System
open System.Windows.Forms

type StartupForm() as this = 
    inherit Form1(Width= 800, Height = 400, 
    Visible = true, 
    Text = "Кортежи в F#")
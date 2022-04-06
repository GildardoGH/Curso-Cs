Main.MainMethod();

class Main
{
    //Definición objeto delegado
    delegate void DelOpen();
    delegate void DelClose(string message);

    public static void MainMethod()
    {
        //Creación del objeto delegado apuntando a OpenMessage
        DelOpen delOpen = new DelOpen(OpenMessage.Show);        
        //Uso del objeto delegado para llamar al método Show
        delOpen();


        //Creación del objeto delegado apuntando a OpenMessage
        DelClose delClose = new DelClose(CloseMessage.Show);
        //Uso del objeto delegado para llamar al método Show
        delClose("Goodbye World");
    }
}

class OpenMessage
{
    public static void Show()
    {
        Console.WriteLine("Hello World");
    }
}

class CloseMessage
{
    public static void Show(string message)
    {
        Console.WriteLine(message);
    }
}


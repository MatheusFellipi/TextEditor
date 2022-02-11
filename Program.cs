using System;
using System.IO;

namespace TextEditor
{
  class Program
  {
    static void Main(string[] args)
    {
      Menu();
    }

    static void Menu()
    {
      Console.Clear();
      Console.WriteLine("O que deseja fazer??");
      Console.WriteLine("1 - Abrir arquivo");
      Console.WriteLine("2 - Criar um novo arquivo");
      Console.WriteLine("0 - Sair");

      short option = short.Parse(Console.ReadLine());

      switch (option)
      {
        case 0: System.Environment.Exit(0); break;
        case 1: Open(); break;
        case 2: Edit(); break;
        default: Menu(); break;
      }

    }
    static void Open()
    {
      Console.Clear();
      Console.WriteLine("Qual camiinho do arquivo?");
      var path = Console.ReadLine();
      using (var file = new StreamReader(path))
      {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
      }
      Console.WriteLine("");
      Console.ReadLine();
      Menu();
    }
    static void Edit()
    {
      Console.Clear();
      Console.WriteLine("Digite seu texto abaixo (ESC - para sair)");
      Console.WriteLine("______________________");
      string text = "";
      do
      {
        text += Console.ReadLine();
        text += Environment.NewLine;
      }
      while (Console.ReadKey().Key != ConsoleKey.Escape);
      Salvar(text);
    }
    static void Salvar(string text)
    {
      Console.Clear();
      Console.WriteLine("Qual camiinho deseja salva o texto?");
      var path = Console.ReadLine();

      using (var file = new StreamWriter(path))
      {
        file.Write(text);
      }
      Console.WriteLine($"Arquivo {path} salvo com sucesso!! ");
      Console.ReadLine();
      Menu();
    }
  }
}

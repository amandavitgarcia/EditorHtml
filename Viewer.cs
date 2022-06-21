using System;
using System.Text.RegularExpressions;

namespace EditorHtml
{
    public class Viewer
    {
        public static void Show(string text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO VISUALIZAÇÃO");
            Console.WriteLine("");
            Replace(text);
            Console.WriteLine("");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Menu.Show();
        }


        //função que substitui alguns carcteres especiais
        public static void Replace(string text)
        {
            //regular expression - uma string que substitui outra de n formas diferentes 
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
            //separando as palavras por espaços
            var words = text.Split(' ');

            for (var i = 0; i < words.Length; i++)
            {
                //verificando se a expressão regular bate com a palavra testada
                if (strong.IsMatch(words[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(
                        words[i].Substring
                        (
                            words[i].IndexOf(">") + 1,
                            ((words[i].LastIndexOf("<") - 1) - 
                            words[i].IndexOf(">"))
                        )
                    );
                    
                    Console.Write(" ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(words[i]);
                    Console.Write(" ");
                }
            }
        }
    }
}
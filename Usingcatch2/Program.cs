using System.Text.RegularExpressions;
using System.Text;

StringBuilder sb = new StringBuilder();

Console.WriteLine("Veuillez rentrez des nombres séparés par des virgules, ex: 5,18,25,60");
string[] chaineNombre = Regex.Replace(Console.ReadLine(), @" ", "").Split(",");
bool isCatched = false;
float total;

while (chaineNombre[0] != "q")
{
    total = 0;

    try
    {
        foreach (var item in chaineNombre)
        {
            total += Int32.Parse(item);
        }
    }
    catch (FormatException ex)
    {
        sb = new StringBuilder("Format incorrect, veuillez tapez à nouveau ou tapez q pour quitter.");
        isCatched = true;
    }
    catch (OverflowException ex)
    {
        sb = new StringBuilder("It's over nine thousand !!!!, veuillez tapez à nouveau ou tapez q pour quitter.");
        isCatched = true;
    }
    catch (Exception ex)
    {
        sb = new StringBuilder($"{ex.Message} , veuillez tapez à nouveau ou tapez q pour quitter.");
        isCatched = true;
    }

    if (!isCatched)
    {
        Console.WriteLine($"Voici la moyenne de la liste [{string.Join(",", chaineNombre)}] : {total / chaineNombre.Length}");
        Console.WriteLine("Encore ? Sinon tapez q pour quitter");
        chaineNombre = Regex.Replace(Console.ReadLine(), @" ", "").Split(",");
    }
    else
    {
        Console.WriteLine(sb.ToString());
        sb.Clear();
        isCatched = false;
        chaineNombre = Regex.Replace(Console.ReadLine(), @" ", "").Split(",");
    }
}
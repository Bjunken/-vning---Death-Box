namespace DeathBox
{
    internal class Program
    {
        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔══════════════════════════════════════════════╗");
            Console.WriteLine("║                                              ║");
            Console.WriteLine("║              Övning - Death Box              ║");
            Console.WriteLine("║                                              ║");
            Console.WriteLine("║                - Uppgift -                   ║");
            Console.WriteLine("║  Gör ett program som låter användaren skapa  ║");
            Console.WriteLine("║   ett konto med användarnamn och lösenord.   ║");
            Console.WriteLine("║                                              ║");
            Console.WriteLine("║  Sedan låt användaren logga in och attackera ║");
            Console.WriteLine("║  bossen, för varje gång spelaren attackerar  ║");
            Console.WriteLine("║           ska bossen slå tillbaka.           ║");
            Console.WriteLine("║                                              ║");
            Console.WriteLine("║   Repetera tills spelaren eller bossen dör.  ║");
            Console.WriteLine("║                   - Extra -                  ║");
            Console.WriteLine("║           [] Gör varje output snygg          ║");
            Console.WriteLine("║           [] Hantera fel inputs              ║");
            Console.WriteLine("║           [] Låt användaren se sina stats:   ║");
            Console.WriteLine("║                -STR                          ║");
            Console.WriteLine("║                -AGI                          ║");
            Console.WriteLine("║                -INT                          ║");
            Console.WriteLine("║           [] Låt användaren sätta ett namn   ║");
            Console.WriteLine("║           [] Låt användaren välja klass      ║");
            Console.WriteLine("║                -Warrior                      ║");
            Console.WriteLine("║                -Ranger                       ║");
            Console.WriteLine("║                -Mage                         ║");
            Console.WriteLine("║           [] Ge varje klass olika stats      ║");
            Console.WriteLine("║                                              ║");
            Console.WriteLine("╚══════════════════════════════════════════════╝");
            Console.ResetColor();
            /*
            Använd:
            Console.ForegroundColor = ConsoleColor.Green; <- Ändrar text färg
            Console.ForegroundColor = ConsoleColor.Red; <- Ändrar text färg
            Console.ResetColor();
            Console.Clear(); <- Tömmer terminal rutan
            ConsoleKeyInfo key = Console.ReadKey(); <- gör inputs till: "***" för läsaren
            ╔══════════════════════════════════════════════╗ <- box ram
            ║                                              ║
            ╚══════════════════════════════════════════════╝

            Tips: Parse, Random(), Lists<>, Dicts, OOP
            */
        }
    }
}

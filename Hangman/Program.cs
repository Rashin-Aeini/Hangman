using System;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = new[] { "abruptly", "absurd", "abyss", "affix", "askew", "avenue", "awkward", "axiom", "azure", "bagpipes", "bandwagon", "banjo", "bayou", "beekeeper", "bikini", "blitz", "blizzard", "boggle", "bookworm", "boxcar", "boxful", "buckaroo", "buffalo", "buffoon", "buxom", "buzzard", "buzzing", "buzzwords", "caliph", "cobweb", "cockiness", "croquet", "crypt", "curacao", "cycle", "daiquiri", "dirndl", "disavow", "dizzying", "duplex", "dwarves", "embezzle", "equip", "espionage", "euouae", "exodus", "faking", "fishhook", "fixable", "fjord", "flapjack", "flopping", "fluffiness", "flyby", "foxglove", "frazzled", "frizzled", "fuchsia", "funny", "gabby", "galaxy", "galvanize", "gazebo", "giaour", "gizmo", "glowworm", "glyph", "gnarly", "gnostic", "gossip", "grogginess", "haiku", "haphazard", "hyphen", "iatrogenic", "icebox", "injury", "ivory", "ivy", "jackpot", "jaundice", "jawbreaker", "jaywalk", "jazziest", "jazzy", "jelly", "jigsaw", "jinx", "jiujitsu", "jockey", "jogging", "joking", "jovial", "joyful", "juicy", "jukebox", "jumbo", "kayak", "kazoo", "keyhole", "khaki", "kilobyte", "kiosk", "kitsch", "kiwifruit", "klutz", "knapsack", "larynx", "lengths", "lucky", "luxury", "lymph", "marquis", "matrix", "megahertz", "microwave", "mnemonic", "mystify", "naphtha", "nightclub", "nowadays", "numbskull", "nymph", "onyx", "ovary", "oxidize", "oxygen", "pajama", "peekaboo", "phlegm", "pixel", "pizazz", "pneumonia", "polka", "pshaw", "psyche", "puppy", "puzzling", "quartz", "queue", "quips", "quixotic", "quiz", "quizzes", "quorum", "razzmatazz", "rhubarb", "rhythm", "rickshaw", "schnapps", "scratch", "shiv", "snazzy", "sphinx", "spritz", "squawk", "staff", "strength", "strengths", "stretch ", "stronghold", "stymied", "subway", "swivel", "syndrome", "thriftless", "thumbscrew", "topaz", "transcript", "transgress", "transplant", "triphthong", "twelfth", "twelfths", "unknown", "unworthy", "unzip", "uptown", "vaporize", "vixen", "vodka", "voodoo", "vortex", "voyeurism", "walkway", "waltz", "wave", "wavy", "waxy", "wellspring", "wheezy", "whiskey", "whizzing", "whomever", "wimpy", "witchcraft", "wizard", "woozy", "wristwatch", "wyvern", "xylophone", "yachtsman", "yippee", "yoked", "youthful", "yummy", "zephyr", "zigzag", "zigzagging", "zilch", "zipper", "zodiac", "zombie" };

            int menu = 1;
            do
            {
                Console.WriteLine("Please Enter your choose:\n 1.Start game\n 2.Exit\n");

                bool menuChoosen = false;

                do
                {
                    string entry = Console.ReadLine();
                    menuChoosen = int.TryParse(entry, out menu);
                    if(menuChoosen && (menu < 1 || menu > 2))
                    {
                        Console.WriteLine("Please enter 1 or 2");
                        menuChoosen = false;
                    }
                } while (!menuChoosen);

                if(menu == 1)
                {
                    int random = (new Random()).Next(words.Length);
                    //Console.WriteLine(words[random]);
                    //Console.WriteLine(words[random].Length);
                    int counter = 0;
                    char[] word = new char[words[random].Length];
                    for (int index = 0; index < word.Length; index++)
                    {
                        word[index] = '_';
                    }
                    StringBuilder guessed = new StringBuilder();
                    Console.WriteLine(string.Format("Program choosing a word with {0} length.", word.Length));

                    do
                    {
                        Console.WriteLine("\nplease enter your guess :");
                        string entry = Console.ReadLine();
                        bool isWord = entry.Length != 1;
                        if (isWord)
                        {
                            if(words[random] == entry)
                            {
                                word = words[random].ToCharArray();
                            }
                        }
                        else
                        {
                            int index = 0;
                            foreach(char character in words[random])
                            {
                                if(char.Parse(entry) == character)
                                {
                                    word[index] = character;
                                }
                                index++;
                            }
                        }

                        if(string.Join(string.Empty, word).IndexOf('_') == -1)
                        {
                            Console.WriteLine("Congratulation you finished the game\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine(string.Format("Your gusseing is {0}", string.Join("  ", word)));
                        }

                        bool duplicate = false;
                        foreach(string guess in guessed.ToString().Split(", "))
                        {
                            if(guess == entry)
                            {
                                duplicate = true;
                                break;
                            }
                        }

                        if (!duplicate)
                        {
                            counter++;
                        }

                        guessed.Append(string.Format("{0}, ", entry));

                        Console.WriteLine(string.Format("You have 10 guessed and you used {0} of them", counter));
                        Console.WriteLine(string.Format("You gesses this word {0}", guessed.ToString()));

                    } while (counter != 10);

                    if (string.Join(string.Empty, word).IndexOf('_') != -1)
                    {
                        Console.WriteLine("Game over\n");
                    }
                }

            } while (menu != 2);
        }
    }
}

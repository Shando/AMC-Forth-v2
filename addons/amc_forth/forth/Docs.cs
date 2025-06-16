using System.Collections.Generic;
using System.Security;
using Godot;

// Utility for generating markdown documentation

namespace Forth
{
    [GlobalClass]
    public partial class Docs : Node
    {
        AMCForth _Forth;

        public override void _Ready()
        {
            base._Ready();
            CreateBuiltInsDocuments();
        }

        public void CreateBuiltInsDocuments()
        {
            static string BulletEscape(string inp)
            {
                var bullets = new List<string> { "+", "-", "*", "\\" };
            
                if (bullets.Contains(inp))
                {
                    return "\\" + inp;
                }

                return inp;
            }

            _Forth = new();
            _Forth.Initialize(this);

            var file = FileAccess.Open(
                "res://addons/amc_forth/docs/builtins.md",
                FileAccess.ModeFlags.Write
            );

            file.StoreLine($"# AMC Forth Built-In Words (Ver. {Version.Ver})");
            var WordSetSet = new SortedSet<string>();
            var WordsSet = new SortedSet<Words>();

            foreach (string name in _Forth.AllBuiltinNames)
            {
                var word = _Forth.BuiltinFromName(name);
                WordSetSet.Add(word.WordSet);
                WordsSet.Add(word);
            }

            foreach (string set in WordSetSet)
            {
                var word_set_dir = set.ToLower().Replace(" ", "_");
                file.StoreLine($"## {set}");

                foreach (Words word in WordsSet)
                {
                    if (word.WordSet == set)
                    {
                        var name = BulletEscape(SecurityElement.Escape(word.Name));
                        var linkname = word.GetType().Name;

                        if (name == "]" || name == "[")
                        {
                            name = "\\" + name;
                        }

                        file.StoreLine($"### <a name=\"{linkname}\"></a>[{name}]({linkname}.md)\n");
                        // now its own file:
                        var wfile = FileAccess.Open(
                            $"res://addons/amc_forth/docs/{linkname}.md",
                            FileAccess.ModeFlags.Write
                        );
                        wfile.StoreLine($"# {name} &emsp; ({linkname})");
                        wfile.StoreLine($"{word.Description}");
                        wfile.StoreLine($"* {word.StackEffect}");
                        wfile.StoreLine($"* [Source Code](../words/{word_set_dir}/{linkname}.cs)");
                        wfile.StoreLine(
                            $"* Execution Tokens: {word.Xt} (interpreted) and {word.XtX} (compiled)"
                        );
                        wfile.StoreLine($"\n\n[BACK](builtins.md#{linkname})");
                        wfile.Close();
                    }
                }
            }

            file.Close();
            _Forth.Cleanup();
            QueueFree();
        }
    }
}

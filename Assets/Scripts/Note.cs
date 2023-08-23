using System.Collections;
using System.Collections.Generic;

public static class Note
{
    public const int A  = 1;
    public const int Bb = 2;
    public const int B  = 3;
    public const int C  = 4;
    public const int Db = 5;
    public const int D  = 6;
    public const int Eb = 7;
    public const int E  = 8;
    public const int F  = 9;
    public const int Gb = 10;
    public const int G  = 11;
    public const int Ab = 12;

    public static HashSet<int> WhiteKeys = new HashSet<int>() { A, B, C, D, E, F, G };

    public static Dictionary<int, string> notes = new Dictionary<int, string>()
    {
        { A , "A" },
        { Bb, "Bb"},
        { B , "B" },
        { C , "C" },
        { Db, "Db" },
        { D , "D" },
        { Eb, "Eb" },
        { E , "E" },
        { F , "F" },
        { Gb, "Gb" },
        { G , "G" },
        { Ab, "Ab" },
    };

    public static bool IsWhiteKey(int note) => WhiteKeys.Contains(note);

    public static string GetNote(int note) => notes[note];
}

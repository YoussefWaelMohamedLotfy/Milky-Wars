using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;

public class Pair<T, U>
{
    public Pair()
    {

    }

    public Pair(T first, U second)
    {
        this.First = first;
        this.Second = second;
    }

    public T First { get; set; }
    public U Second { get; set; }
};
public static class Linker
{
    public static bool GotAttacked=false;
    public static float Health=100;
    public static int Score = 0;
    public static string UserName;
    public static string[] Scores;
    public static string LevelDone="0";
    public static List<Pair<string, int>> NamesAndScores = new List<Pair<string, int>>();
}


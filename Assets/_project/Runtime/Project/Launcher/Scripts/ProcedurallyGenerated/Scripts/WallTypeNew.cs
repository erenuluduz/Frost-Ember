using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallTypeNew
{
    public static HashSet<int> wallTop = new HashSet<int>
    {
        0b0010,
        0b1111
    };
    public static HashSet<int> wallSideLeft = new HashSet<int>
    {
        0b0100
    };
    public static HashSet<int> wallSideRight = new HashSet<int>
    {
        0b0001
    };
    public static HashSet<int> wallBottm = new HashSet<int>
    {
        0b1000
    };
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static int score = 0;
    public static int lastscore = 0;
    public static int topscore = 0;
    public static Vector3 controllerOffset = new Vector3(0f, 0f, 0f);
    public static List<int> scores = new List<int>();
    public static List<string> names = new List<string>();
}

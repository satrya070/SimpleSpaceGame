using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Globals
{
    public static Dictionary<Tuple<string, string>, int> specialBehaviour = new Dictionary<Tuple<string, string>, int>();

    // Start is called before the first frame update

        // specific situations where damage should be different
    //specialBehaviour.Add(Tuple.Create("Player", "SpaceStation"), 1f);
}

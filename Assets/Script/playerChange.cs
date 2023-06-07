using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerChange : MonoBehaviour
{
    public static bool player = true;
    public static bool change = false;


    public static void Change()
    {
        change = true;

        player = !player;

        Action.steps = Action.HiddenStaps += 1;

        Action.oneCard = null;
        Action.twoCard = null;

        
    }

}

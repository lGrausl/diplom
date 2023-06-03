using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerChange : MonoBehaviour
{
    public static bool player = true;


    public static void change()
    {
        player = !player;

        Action.steps = Action.HiddenStaps += 1;
    }

}

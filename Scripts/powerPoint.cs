using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerPoint : MonoBehaviour // powerPoint er ScoreManeger hjá gameplusjames
{
    public static int power;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        power = 0;
    }

    void Update()
    {
        if (power < 0)
        {
            power = 0;
        }
        text.text = "" + power;
    }

    public static void AddPoints (int pointsToAdd)
    {
        power += pointsToAdd;
    }

    public static void Reset()
    {
        power = 0;
    }
}

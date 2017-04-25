using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiRule : MonoBehaviour
{

    public static bool canGo(ChessType[,] boardData, int oldH, int oldW, int newH, int newW)
    {
        if (newW < 3 || newW > 5)
            return false;

        ChessType oldType = boardData[oldH, oldW];
        if (board::getGroupType(oldType) == GroupType.red)
        {
            if (newH > 2)
                return false;
        }
        else
        {
            if (newH < 7)
                return false;
        }


        if (Mathf.Abs(newH - oldH) == 1 && Mathf.Abs(newW - oldW) == 1)
        {
            return true;
        }

        return false;
    }

}
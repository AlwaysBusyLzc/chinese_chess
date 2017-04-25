using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soliderRule : MonoBehaviour
{
    public static bool canGo(ChessType[,] boardData, int oldH, int oldW, int newH, int newW)
    {
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
    }
}
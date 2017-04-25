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
            if (newH < oldH)
                return false;

            if (oldH > 4)
            {
                if ()
            }
            else
            {
                if (newH - oldH == 1 && newW == oldW)
                    return true;
            }  
        }
        else
        {
            if (newH > oldH)
                return false;

            if (oldH < 5)
            {
            }
            else
            {
            }
        }

        return false;
    }
}
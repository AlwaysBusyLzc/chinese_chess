using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soliderRule : MonoBehaviour
{
    public static GroupType getGroupType(ChessType chessType)
    {
        if ((int)chessType > 10)
            return GroupType.black;

        return GroupType.red;
    }

    public static bool canGo(ChessType[,] boardData, int oldH, int oldW, int newH, int newW)
    {
        ChessType oldType = boardData[oldH, oldW];
        if (getGroupType(oldType) == GroupType.red)
        {
            if (newH < oldH)
                return false;

            if (oldH > 4)
            {
                if (Mathf.Abs(newH - oldH) == 1 && Mathf.Abs(newW - oldW) == 0)
                {
                    return true;
                }
                else if (Mathf.Abs(newH - oldH) == 0 && Mathf.Abs(newW - oldW) == 1)
                {
                    return true;

                }
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
                if (Mathf.Abs(newH - oldH) == 1 && Mathf.Abs(newW - oldW) == 0)
                {
                    return true;
                }
                else if (Mathf.Abs(newH - oldH) == 0 && Mathf.Abs(newW - oldW) == 1)
                {
                    return true;

                }
            }
            else
            {
                if (newH - oldH == -1 && newW == oldW)
                    return true;
            }
        }

        return false;
    }
}
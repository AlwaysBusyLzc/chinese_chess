using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalRule : MonoBehaviour
{

    public static bool canGo(ChessType[,] boardData, int oldH, int oldW, int newH, int newW)
    {
        if (newW < 3 || newW > 5)
            return false;

        ChessType oldType = boardData[oldH, oldW];
        ChessType newType = boardData[newH, newW];

        if (newW == oldW && newType == ChessType.black_general || newType == ChessType.red_general)
        {
            int biggerH = newH;
            int litterH = oldH;
            if (oldH > newW)
            {
                biggerH = oldH;
                litterH = newH;
            }
            for (int i = litterH + 1; i < biggerH; i++)
            {
                if (boardData[i, oldW] != ChessType.empyt)
                    return false;
            }

            return true;
        }

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


        if (Mathf.Abs(newH - oldH) == 1 && Mathf.Abs(newW - oldW) == 0)
        {
            return true;
        }

        if (Mathf.Abs(newH - oldH) == 0 && Mathf.Abs(newW - oldW) == 1)
        {
            return true;
        }

        return false;
    }

}
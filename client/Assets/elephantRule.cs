using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elephantRule : MonoBehaviour
{

    public static bool canGo(ChessType[,] boardData, int oldH, int oldW, int newH, int newW)
    {
        ChessType oldType = boardData[oldH, oldW];
        if (board::getGroupType(oldType) == GroupType.red)
        {
            if (newH > 4)
                return false;
        }
        else
        {
            if (newH <= 4)
                return false;
        }

        int xiangYanH = oldH - 1;
        int xiangYanW = oldW - 1;
        if (newH > oldH)
            xiangYanH = oldH + 1;

        if (newW > oldW)
            xiangYanW = oldW + 1;


        if (Mathf.Abs(newH - oldH) == 2 && Mathf.Abs(newW - oldW) == 2)
        {
            if (boardData[xiangYanH, xiangYanW] != ChessType.empty)
                return false;

            return true;
        }
        
        return false;
    }

}
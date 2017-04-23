using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horseRule : MonoBehaviour {

    public static bool canGo(ChessType[,] boardData, int oldH, int oldW, int newH, int newW)
    {

        if (Mathf.Abs(newH - oldH) == 1)
        {
            if (Mathf.Abs(newW - oldW) != 2)
                return false;

            int maTui = newW > oldW ? 1 : -1;
            if (boardData[oldH, oldW + maTui] != ChessType.empty)
                return false;

            return true;
        }
        else if (Mathf.Abs(newH - oldH) == 2)
        {
            if (Mathf.Abs(newW - oldW) != 1)
                return false;

            int maTui = newH > oldH ? 1 : -1;
            if (boardData[oldH + maTui, oldW] != ChessType.empty)
                return false;

            return true;
        }

        return false;
    }

}

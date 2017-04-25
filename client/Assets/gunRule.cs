using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunRule : MonoBehaviour
{

    public static bool canGo(ChessType[,] boardData, int oldH, int oldW, int newH, int newW)
    {
        if (oldH == newH)
        {
            int bigger = oldW;
            int littler = newW;
            if (newW > oldW)
            {
                bigger = newW;
                littler = oldW;
            }

            int chessCount = 0;
            for (int i = littler + 1; i < bigger; i++)
            {
                if (boardData[oldH, i] != ChessType.empty)
                    chessCount++;
            }

            if (chessCount != 1)
                return false;

            return true;
        }
        else if (oldW == oldW)
        {
            int bigger = oldH;
            int littler = newH;
            if (newH > oldH)
            {
                bigger = newH;
                littler = oldH;
            }

            int chessCount = 0;
            for (int i = littler + 1; i < bigger; i++)
            {
                if (boardData[i, oldW] != ChessType.empty)
                    chessCount++;
            }

            if (chessCount != 1)
                return false;

            return true;
        }

        return false;
    }

}

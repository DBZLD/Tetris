using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlock : MonoBehaviour
{
    private static int height = 20;
    private static int width = 10;
    private static Transform[,] ghostgrid = new Transform[width, height];

    public bool VaildMove()
    {
        ghostgrid = Gamemanagers.grid;
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }
            if (ghostgrid[roundedX, roundedY] != null)
            {
                return false;
            }
        }
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanagers : MonoBehaviour
{


    protected static Gamemanagers m_Instance = null;
    public static Gamemanagers GetInstance()
    {
        if(m_Instance == null)
        {
            m_Instance = GameObject.FindObjectOfType<Gamemanagers>();
        }

        return m_Instance;
    }


    public Vector3 rotationPoint;
    public static float fallTime = 0.8f;
    public static int Height = 20;
    public static int Width = 10;
    public static Transform[,] grid = new Transform[Width, Height];

    public void DisableBlock()
    {
        AddToGide();
        CheckForLines();

        this.enabled = false;

        FindObjectOfType<SpawnBlock>().ResetTetromino();
        FindObjectOfType<GhostSpawner>().ReSetGhostBlock();
        FindObjectOfType<NextBlock>().ResetNextBlock();
        FindObjectOfType<HoldBlock>().HoldEnable = true;
    }
    public void DestroyBlock()
    {
        Destroy(this.gameObject);
    }

    void CheckForLines()
    {
        for (int i = Height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    bool HasLine(int i)
    {
        for (int j = 0; j < Width; j++)
        {
            if (grid[j, i] == null)
            {
                return false;
            }

        }
        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < Width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void RowDown(int i)
    {
        for (int y = i; y < Height; y++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void AddToGide()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }
}

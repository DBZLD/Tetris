using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    public GameObject[] Tetrominos;
    private int[] nBag = new int[] { 0, 1, 2, 3, 4, 5, 6 };
    private int nBagTurn = 0;
    public static int nNextBlock;
    public static int nNowBlock;


    [Header("[µð¹ö±ë¿ë]")]
    public bool ISDebug = false;
    public List<int> m_DebugSpawnBlockList = new List<int>() { 0, 0, 0, 4 };

    void Awake()
    {
        StartTetromino();
        FindObjectOfType<GhostSpawner>().StartGhostBlock();
        FindObjectOfType<NextBlock>().StartNextBlock();
    }

    public void StartTetromino()
    {
        nNowBlock = Bag();
        NewTetromino();
        nNextBlock = Bag();
    }
    public void NewTetromino()
    {
        GameObject copyblock = Instantiate(Tetrominos[nNowBlock], transform.position, Quaternion.identity);
        

    }
    public void NextTetromino()
    {
        nNowBlock = nNextBlock;
        nNextBlock = Bag();
    }

    public void ResetTetromino()
    {
        NextTetromino();
        NewTetromino();
    }
    private int Bag()
    {
        int nReturn;

        while(true)
        {
            nReturn = Random.Range(0, 7);
            if (nBag[nReturn] != 7)
            {
                nBag[nReturn] = 7;
                nBagTurn++;
                if (nBagTurn == 7)
                {
                    nBag = new int[] { 0, 1, 2, 3, 4, 5, 6};
                    nBagTurn = 0;
                }

                if (ISDebug && m_DebugSpawnBlockList.Count > 0)
                {
                    nReturn = m_DebugSpawnBlockList[0];
                    m_DebugSpawnBlockList.RemoveAt(0);
                }

                return nReturn;
            }
        }
    }
}

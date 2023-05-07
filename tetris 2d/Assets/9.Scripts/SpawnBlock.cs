using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    public GameObject[] Tetrominos;
    private int[] nBag = new int[] { 0, 1, 2, 3, 4, 5, 6 };
    private int nBagTurn = 0;
    public int nNextBlock;
    public int nNowBlock;

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
        Instantiate(Tetrominos[nNowBlock], transform.position, Quaternion.identity);
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

            if(nBag[nReturn] != 7)
            {
                nBag[nReturn] = 7;
                nBagTurn++;
                if (nBagTurn == 7)
                {
                    nBag = new int[] { 0, 1, 2, 3, 4, 5, 6};
                    nBagTurn = 0;
                }
                return nReturn;
            }
        }
    }
}

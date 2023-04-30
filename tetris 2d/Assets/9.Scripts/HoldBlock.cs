using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldBlock : MonoBehaviour
{
    public GameObject[] ImageTetrominos;
    public int nHoldBlock = 7;
    public bool HoldEnable = true;

    void Update()
    {

    }

    public void ShowHoldBlock()
    {
        if(HoldEnable == true)
        {
            if (nHoldBlock == 7)
            {
                SetHoldBlock();
                FindObjectOfType<TetrisBlock>().DestroyBlock();
                FindObjectOfType<SpawnBlock>().NextTetromino();
                FindObjectOfType<SpawnBlock>().NewTetromino();
                FindObjectOfType<NextBlock>().ShowNextBlock();

                HoldEnable = false;
            }
            else
            {
                int nChange = nHoldBlock;
                SetHoldBlock();
                FindObjectOfType<SpawnBlock>().nNowBlock = nChange;
                FindObjectOfType<TetrisBlock>().DestroyBlock();
                FindObjectOfType<SpawnBlock>().NewTetromino();
                FindObjectOfType<Block>().DestroyBlock();
                CopyHoldBlock();

                HoldEnable = false;
            }
        }
    }
    private void SetHoldBlock()
    {
        nHoldBlock = FindObjectOfType<SpawnBlock>().nNowBlock;
    }
    private void CopyHoldBlock()
    {
        Instantiate(ImageTetrominos[nHoldBlock], this.transform.position, Quaternion.identity);
    }
}

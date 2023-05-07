using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldBlock : MonoBehaviour
{
    public GameObject[] ImageTetrominos;
    private int nHoldBlock = 7;
    public bool HoldEnable = true;

    public void ResetHoldBlock()
    {
        if(HoldEnable == true)
        {
            if (nHoldBlock == 7)
            {
                SetHoldBlock();
                CopyHoldBlock();
                FindObjectOfType<TetrisBlock>().DestroyBlock();
                FindObjectOfType<SpawnBlock>().ResetTetromino();
                FindObjectOfType<NextBlock>().ResetNextBlock();

                HoldEnable = false;
            }
            else
            {
                ChangeHoldBlock();
                FindObjectOfType<TetrisBlock>().DestroyBlock();
                FindObjectOfType<SpawnBlock>().NewTetromino();
                DestroyHoldBlock();
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
        GameObject copyholdblock = Instantiate(ImageTetrominos[nHoldBlock], this.transform.position, Quaternion.identity);
        copyholdblock.tag = "Hold";
    }
    private void ChangeHoldBlock()
    {
        int nChange = nHoldBlock;
        SetHoldBlock();
        FindObjectOfType<SpawnBlock>().nNowBlock = nChange;
    }
    private void DestroyHoldBlock()
    {
        GameObject destroynextblock = GameObject.FindGameObjectWithTag("Hold");
        Destroy(destroynextblock.gameObject);
    }
}

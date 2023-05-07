using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBlock : MonoBehaviour
{
    public GameObject[] ImageTetrominos;
    private int nShowBlock;

    public void StartNextBlock()
    {
        SetNextBlock();
        CopyNextBlock();
    }

    public void ResetNextBlock()
    {
        DestroyNextBlock();
        SetNextBlock();
        CopyNextBlock();
    }

    private void SetNextBlock()
    {
        nShowBlock = SpawnBlock.nNextBlock;
    }

    private void CopyNextBlock()
    {
        GameObject copynextblock = Instantiate(ImageTetrominos[nShowBlock], this.transform.position, Quaternion.identity);
        copynextblock.tag = "Next";
    }
    private void DestroyNextBlock()
    {
        GameObject destroynextblock = GameObject.FindGameObjectWithTag("Next");
        Destroy(destroynextblock.gameObject);
    }
}

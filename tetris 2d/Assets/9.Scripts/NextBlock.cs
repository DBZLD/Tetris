using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBlock : MonoBehaviour
{
    public GameObject[] ImageTetrominos;
    private int nShowBlock;
    void Start()
    {
        SetNextBlock();
        CopyNextBlock();
    }

    public void ShowNextBlock()
    {
        FindObjectOfType<Block>().DestroyBlock();
        SetNextBlock();
        CopyNextBlock();
    }

    private void SetNextBlock()
    {
        nShowBlock = FindObjectOfType<SpawnBlock>().nNextBlock;
    }

    private void CopyNextBlock()
    {
        Instantiate(ImageTetrominos[nShowBlock], this.transform.position, Quaternion.identity);
    }
}

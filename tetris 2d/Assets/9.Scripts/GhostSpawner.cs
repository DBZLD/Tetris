using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GhostBlock[] Tetrominos;
    public GhostBlock m_CopyGhostBlock = null;
    private Vector3 TetrominoVector;
    private Transform TetrominoTransform;
    private void CopyGhostBlock()
    {
        TetrominoTransform = FindObjectOfType<TetrisBlock>().transform;

        TetrominoVector.x = TetrominoTransform.position.x;
        TetrominoVector.y = 15;

        GhostBlock copyghostblock = Instantiate(Tetrominos[FindObjectOfType<SpawnBlock>().nNowBlock], TetrominoVector, TetrominoTransform.rotation);
        m_CopyGhostBlock = copyghostblock;
        m_CopyGhostBlock.tag = "Ghost";
    }



    private void DownGhostBlock()
    {
        if( m_CopyGhostBlock == null)
        {
            return;
        }

        int tempval = 0;
        while (true)
        {
            ++tempval;

            m_CopyGhostBlock.transform.position += new Vector3(0, -1, 0);
            if (!m_CopyGhostBlock.VaildMove())
            {
                m_CopyGhostBlock.transform.position += new Vector3(0, 1, 0);
                break;
            }
        }
    }
    private void DestroyGhostBlock()
    {
        GameObject destroyghostblock = GameObject.FindGameObjectWithTag("Ghost");
        if( destroyghostblock )
        {
            Destroy(destroyghostblock.gameObject);
            m_CopyGhostBlock = null;
        }
        
    }


    public void UpdateGhostBlock( TetrisBlock p_blockinfo )
    {
        m_CopyGhostBlock.transform.position = p_blockinfo.transform.position;
        m_CopyGhostBlock.transform.rotation = p_blockinfo.transform.rotation;

        DownGhostBlock();
    }

    public void ReSetGhostBlock()
    {
        DestroyGhostBlock();
        CopyGhostBlock();
        DownGhostBlock();
    }
    public void StartGhostBlock()
    {
        CopyGhostBlock();
        DownGhostBlock();
    }
}

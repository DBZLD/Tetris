using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanagers : MonoBehaviour
{
    public CountClearLine m_CountClearLine = null;
    public CountScore m_CountScore = null;
    public CountCombo m_CountCombo = null;
    public GameOverPanel m_GameOverPanel = null;
    public GameoverScore m_GameOverScore = null;
    public bool IsGameOver = false;
    public int nTakeBlock = 0;
    private void Start()
    {
        m_CountClearLine = GameObject.FindObjectOfType<CountClearLine>();
        m_CountScore = GameObject.FindObjectOfType<CountScore>();
        m_CountCombo = GameObject.FindObjectOfType<CountCombo>();
    }

    public static float fallTime = 0.8f;
    public static int Height = 20;
    public static int Width = 10;
    public static Transform[,] grid = new Transform[Width, Height];

    public void DisableBlock(TetrisBlock block)
    {
        if (IsGameOver == true) return;

        block.AddToGide();
        CheckForLines();

        block.enabled = false;

        m_CountClearLine.ResetCount();
        FindObjectOfType<SpawnBlock>().ResetTetromino();
        FindObjectOfType<GhostSpawner>().ReSetGhostBlock();
        FindObjectOfType<NextBlock>().ResetNextBlock();
        FindObjectOfType<HoldBlock>().HoldEnable = true;
        nTakeBlock++;
    }

    void CheckForLines()
    {
        bool isdeleteline = false;
        for (int i = Height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                isdeleteline = true;
                DeleteLine(i);
                RowDown(i);
                m_CountClearLine.AddCount();
                
            }
        }

        if(isdeleteline)
        {
            m_CountClearLine.UpdateUI();
            m_CountCombo.CheckCombo();
            m_CountScore.GetAddScore(m_CountClearLine.ClearLine, m_CountCombo.ComboCount);
        }
        else
        {
            m_CountCombo.ResetCombo();
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

    private void Update()
    {
        if (IsGameOver == true)
        {

            m_GameOverPanel.gameObject.SetActive(true);
            m_GameOverScore.SetText(m_CountScore.Score);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);             
            }
        }
    }
}

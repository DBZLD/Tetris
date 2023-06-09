using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    private float previousTime;
    public Vector3 rotationPoint;
    public float SetTime = 0.1f;
    public float LeftTime = 0.1f;
    public float Speed = 3f;
    public Gamemanagers m_GameManager = null;

    void Update()
    {

        if( Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            LeftTime = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            LeftTime = 0f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            LeftTime -= Time.deltaTime;
            if (LeftTime <= 0)
            {
                LeftTime = SetTime;

                transform.position -= new Vector3(1, 0, 0);
                FindObjectOfType<GhostSpawner>().UpdateGhostBlock(this);
                if (!VaildMove())
                {
                    transform.position += new Vector3(1, 0, 0);
                    FindObjectOfType<GhostSpawner>().UpdateGhostBlock(this);
                }
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            LeftTime -= Time.deltaTime;
            if (LeftTime <= 0)
            {
                LeftTime = SetTime;

                transform.position += new Vector3(1, 0, 0);
                FindObjectOfType<GhostSpawner>().UpdateGhostBlock(this);
                if (!VaildMove())
                {
                    transform.position -= new Vector3(1, 0, 0);
                    FindObjectOfType<GhostSpawner>().UpdateGhostBlock(this);
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            FindObjectOfType<GhostSpawner>().UpdateGhostBlock(this);
            if (!VaildMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
                FindObjectOfType<GhostSpawner>().UpdateGhostBlock(this);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            FindObjectOfType<GhostSpawner>().UpdateGhostBlock(this);
            if (!VaildMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
                FindObjectOfType<GhostSpawner>().UpdateGhostBlock(this);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 180);
            FindObjectOfType<GhostSpawner>().UpdateGhostBlock(this);
            if (!VaildMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -180);
                FindObjectOfType<GhostSpawner>().UpdateGhostBlock(this);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            while(true)
            {
                transform.position -= new Vector3(0, 1, 0);
                if(!VaildMove())
                {
                    transform.position += new Vector3(0, 1, 0);

                    m_GameManager.DisableBlock(this);
                    break;
                }
            }
        }
        if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? Gamemanagers.fallTime / 10 : Gamemanagers.fallTime))
        {
            transform.position -= new Vector3(0, 1, 0);
            if (!VaildMove())
            {
                transform.position += new Vector3(0, 1, 0);

                m_GameManager.DisableBlock(this);
            }
            previousTime = Time.time;
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(FindObjectOfType<HoldBlock>().HoldEnable)
            {
                FindObjectOfType<HoldBlock>().ResetHoldBlock();
                FindObjectOfType<GhostSpawner>().ReSetGhostBlock();
                DestroyBlock();
            }
        }
    }
    public bool VaildMove()
        {
            foreach ( Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);

                if (roundedX < 0 || roundedX >= Gamemanagers.Width || roundedY < 0 || roundedY >= Gamemanagers.Height)
                {
                    return false;
                }
                if (Gamemanagers.grid[roundedX, roundedY] != null)
                {
                    return false;
                }

            }
            return true;
        }
    public void AddToGide()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            Gamemanagers.grid[roundedX, roundedY] = children;
        }
    }
    public void DestroyBlock()
    {
        Destroy(this.gameObject);
    }

    public void Start()
    {
        m_GameManager = GameObject.FindObjectOfType<Gamemanagers>();

        if (!VaildMove())
        {
            m_GameManager.IsGameOver = true;
        }
    }
}

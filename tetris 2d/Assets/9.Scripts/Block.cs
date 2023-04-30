using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public void DestroyBlock()
    {
        Destroy(this.gameObject);
    }
}

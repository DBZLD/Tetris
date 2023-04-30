using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCreateLine : MonoBehaviour
{
    public GameObject VerticalLineObj = null;
    public GameObject HorizontalLineObj = null;

    [ContextMenu("라인강제로 그리기")]
    void _Editor_GridLine()
    {

        for (int i = 0; i < 11; i++)
        {
            GameObject verticalclone = GameObject.Instantiate(VerticalLineObj);
            verticalclone.transform.position = new Vector3( (i * 1) - 0.5f
                                    , VerticalLineObj.transform.position.y
                                    , 0);
            verticalclone.transform.SetParent(this.transform);
        }
        for (int i = 0; i < 21; i++)
        {
            GameObject horizontalclone = GameObject.Instantiate(HorizontalLineObj);
            horizontalclone.transform.position = new Vector3(HorizontalLineObj.transform.position.x
                                    , (i * 1) - 0.5f
                                    , 0);
            horizontalclone.transform.SetParent(this.transform);
        }
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}

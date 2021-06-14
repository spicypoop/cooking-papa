using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerBehavior : MonoBehaviour 
{
    public Transform burgerPositionObj;
    public float startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = -1.52f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("click yo");
        Instantiate(burgerPositionObj, new Vector3(startPos, 3, -3.7f), new Quaternion(0,0,0, 0));
        startPos += 1f;
    }
}

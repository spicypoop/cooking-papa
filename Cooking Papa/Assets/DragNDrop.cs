using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragNDrop : MonoBehaviour
{
    float zPos;
    Vector3 Offset;
    Camera MainCamera;
    bool isDragging;
    GameObject clone;

    public UnityEvent OnBeginDrag;
    public UnityEvent OnEndDrag;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        zPos = MainCamera.WorldToScreenPoint(transform.position).z;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zPos);
            //transform.position = MainCamera.ScreenToWorldPoint(newPosition + new Vector3(Offset.x, Offset.y));
            clone.transform.position = MainCamera.ScreenToWorldPoint(newPosition + new Vector3(Offset.x, Offset.y));
        }
    }

    private void OnMouseDown()
    {
        if (!isDragging)
        {
            BeginDrag();
            clone = Instantiate(gameObject, transform.position, new Quaternion(0, 0, 0, 0));
        }
    }
    private void OnMouseUp()
    {
        EndDrag();
    }
    private void BeginDrag() 
    {
        OnBeginDrag.Invoke();
        isDragging = true;
        Offset = MainCamera.WorldToScreenPoint(transform.position) - Input.mousePosition;
    }
    private void EndDrag()
    {
        OnEndDrag.Invoke();
        isDragging = false;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCam : MonoBehaviour
{
    [SerializeField]
    public float sensitivity = 5.0f;
    [SerializeField]
    public float smoothing = 2.0f;
    public GameObject character;
    Vector2 mouseLook;
    void Start()
    {
        character = this.transform.parent.gameObject;
    }
    void Update()
    {
        var mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseInput = Vector2.Scale(mouseInput, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        mouseLook += mouseInput;
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
  
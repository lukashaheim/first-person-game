using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour

	{
    public static bool cursorLocked=true;
    public Transform player;
    public Transform cams;
    public Transform weapon;

    public float xSens;
    public float ySens;
    public float maxAngle;

    private Quaternion camCenter;

    void Start()
    {
        camCenter = cams.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        SetY();
        SetX();
        UpdateCursorLock();
    }


    void SetY()
    {
        float y_input = Input.GetAxis("Mouse Y") * ySens * Time.deltaTime;
        Quaternion ty = Quaternion.AngleAxis(y_input, -Vector3.right);
        // Debug.Log(t);
        Quaternion ty_delta = cams.localRotation * ty;

        if (Quaternion.Angle(camCenter, ty_delta) < maxAngle)
        {
            cams.localRotation = ty_delta;
            weapon.localRotation = ty_delta;
        }

        // weapon.rotation = cams.rotatioùn;
    }

    void SetX()
    {
        float x_input = Input.GetAxis("Mouse X") * ySens * Time.deltaTime;
        Quaternion tx = Quaternion.AngleAxis(x_input, Vector3.up);
        // Debug.Log(t);
        Quaternion tx_delta = player.localRotation * tx;
        player.localRotation = tx_delta;
    }

    void UpdateCursorLock()
    {
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = false;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = true;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera : MonoBehaviour
{
    public CinemachineFreeLook cam;
    public CharacterController playerObj;
    public float speed = 200.0f;
    private float cam_XAxis;

    void Start()
	{

	}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) 
        {
            cam.m_YAxis.Value += 0.05f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            cam.m_YAxis.Value -= 0.05f;
        }

        if (Input.GetKey(KeyCode.Mouse0))
		{
            Cursor.lockState = CursorLockMode.Locked;
            if (Input.GetAxis("Mouse X") > 0f) cam.m_XAxis.Value += speed * Time.deltaTime;
            if (Input.GetAxis("Mouse X") < 0f) cam.m_XAxis.Value -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Mouse1))
		{
            Cursor.lockState = CursorLockMode.Locked;
            cam_XAxis = cam.m_XAxis.Value;
            cam.m_XAxis.Value = 0.0f;
            playerObj.transform.Rotate(0, cam_XAxis, 0);
            if (Input.GetAxis("Mouse X") > 0f) 
            {
                playerObj.transform.Rotate(Vector3.up * speed * Time.deltaTime);
            }
            if (Input.GetAxis("Mouse X") < 0f) 
            {
                playerObj.transform.Rotate(-Vector3.up * speed * Time.deltaTime);
            }
            
        }
        else
		{
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

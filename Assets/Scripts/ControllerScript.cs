using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerScript : MonoBehaviour
{
    
    public Camera MainCamera;
    public GameObject [] weapons = new GameObject[2];
    public float WeaponPoints;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        WeaponPoints = 1;
        characterController = GetComponent<CharacterController>();

       
    }

    void Update()
    {
        Move();
        Weapons();
        CrossHair();
        if (Input.GetKeyDown(KeyCode.Mouse0)) Shooting(WeaponPoints);
    }

    public void Move()
    {

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);


        float curSpeedX = canMove ? 6f * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? 6f * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = 5f;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }


        if (!characterController.isGrounded)
        {
            moveDirection.y -= 18f * Time.deltaTime;
        }


        characterController.Move(moveDirection * Time.deltaTime);


        if (canMove)
        {

            rX += -Input.GetAxis("Mouse Y") * 1.5f;
            rX = Mathf.Clamp(rX, -45f, 45f);
            MainCamera.transform.localRotation = Quaternion.Euler(rX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * 1.5f, 0);
        }
    }
    public void Weapons()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponPoints = 1;
            weapons[0].gameObject.SetActive(true);
            weapons[1].gameObject.SetActive(false);
            weapons[2].gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponPoints = 3;
            weapons[1].gameObject.SetActive(true);
            weapons[0].gameObject.SetActive(false);
            weapons[2].gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeaponPoints = 5;
            weapons[1].gameObject.SetActive(false);
            weapons[0].gameObject.SetActive(false);
            weapons[2].gameObject.SetActive(true);
        }
    }
    public void CrossHair()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Camera.main.fieldOfView = 45f;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Camera.main.fieldOfView = 60f;
        }
    }

    public void Shooting(float points)
    {
        
        RaycastHit hit;
        Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hit);
        Object_text object_text = hit.transform.GetComponent<Object_text>();
        object_text.SubtractPoints(points);

    }

    public void LockCursour()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
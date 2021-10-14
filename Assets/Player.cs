using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int playerSpeed = 5;
    private int rotationSpeed = 700;
    public Health health;

    void Start()
    { 
        health = GetComponent<Health>();
        health.SetHealth(200, 200);
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    if (MovementBoundaries.leftTrespass(transform.position) == false)
        //        transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    if (MovementBoundaries.forwardTrespass(transform.position) == false)
        //        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    if (MovementBoundaries.downwardTrespass(transform.position) == false)
        //        transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    if (MovementBoundaries.rightTrespass(transform.position) == false)
        //        transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        //}
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction.Normalize();
        transform.Translate(direction * playerSpeed * Time.deltaTime, Space.World);
        if (direction != Vector3.zero)
        {
            Quaternion rotate = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotate, rotationSpeed * Time.deltaTime);
        }
        //transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime);
        //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);
    }
}

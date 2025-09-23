﻿using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    public float speed = 20;
    public float angle = 180;
    Vector3 velocity;
    void Update()
    {
        // 사용자가 입력하면 상하좌우로 이동하고싶다.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = transform.forward * v;
        velocity += dir * speed * Time.deltaTime;

        transform.Rotate(Vector3.up, h * angle * Time.deltaTime);

        Quaternion q = Quaternion.Euler(Vector3.up * h * angle * Time.deltaTime);
        rb.MoveRotation(rb.transform.rotation * q);
        // 현재위치 P = P0 + vt
        // 순간이동
        //transform.position = transform.position + velocity * Time.deltaTime;
        // rb를 이용한 이동
        rb.MovePosition(rb.transform.position + velocity * Time.deltaTime);

        velocity = Vector3.Lerp(velocity, Vector3.zero, Time.deltaTime * 6);
    }
}

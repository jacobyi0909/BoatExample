using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Player instance;

    public Rigidbody rb;
    public GameObject defaultTailTarget;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Player.instance = this;
    }

    void Start()
    {
        POINT = 0;
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

    int garbageCount;
    public Tail tailFactory;
    public GameObject lastTail = null;
    List<Tail> tails = new List<Tail>();
    internal void AddGarbage(int addCount, Vector3 position)
    {
        garbageCount += addCount;

        Tail tail = Instantiate<Tail>(tailFactory, position, Quaternion.identity);

        float tailSpeed = Mathf.Max(1f, 10f - garbageCount);
        tail.SetInfo(tailSpeed, lastTail);

        lastTail = tail.gameObject;
        
        tails.Add(tail);
    }

    int point;
    public TextMeshProUGUI textPoint;

    public int POINT
    {
        get { return point; }
        set {
            point = value;
            textPoint.SetText(point.ToString());
        }
    }

    internal void CalcGarbagePoint()
    {
        // UI에 point값을 반영하고싶다.
        POINT += garbageCount * garbageCount;
        
        garbageCount = 0;
        // tail들을 다 파괴하고싶다.
        for (int i = 0; i < tails.Count; i++)
        {
            Destroy(tails[i].gameObject);
        }
        tails.Clear();

        lastTail = defaultTailTarget;
    }
}

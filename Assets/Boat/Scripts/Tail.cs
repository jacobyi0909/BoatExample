using System;
using UnityEngine;

public class Tail : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public float speed = 5f;
    void Update()
    {
        // 내가 플레이어를 향하는 방향을 알고싶다.
        Vector3 dir = target.transform.position - this.transform.position;
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;

    }
    GameObject target;
    internal void SetInfo(float tailSpeed, GameObject newTarget)
    {
        target = newTarget;
        speed = tailSpeed;
    }
}

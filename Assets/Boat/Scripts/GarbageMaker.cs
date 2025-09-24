using System.Collections;
using UnityEngine;

public class GarbageMaker : MonoBehaviour
{
    // 일정시간마다 Garbage공장에서 Garbage를 생성해서 랜덤한 위치에 배치하고싶다.
    public GameObject garbageFactory;
    public float makeTime = 1f;
    void Start()
    {
        StartCoroutine(IELoop());
    }
    IEnumerator IELoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(makeTime);
            Vector3 point = transform.position + Random.insideUnitSphere * 10f;

            point.y = 0;
            Vector3 dir= point - Player.instance.transform.position;
            float dist = Vector3.Distance(point, Player.instance.transform.position);
            if (dir.magnitude < 2)
            {
                point += dir * 2;
            }
            
            point.y = 0;
            Instantiate(garbageFactory, point, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

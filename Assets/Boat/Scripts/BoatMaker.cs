using UnityEngine;

public class BoatMaker : MonoBehaviour
{
    // Spawn목록을 가지고싶다.
    public Transform[] spawns;
    // 일정시간마다 보트공장에서 보트를 만들어서 내위치에 배치하고싶다.
    float curTime;
    public float makeTime = 2f;
    public GameObject boatFactory;

    // 이전 위치를 기억하고싶다.
    int prevIdex;
    
    void Start()
    {
        
    }

    void Update()
    {
        // 1. 시간이 흐르다가
        curTime += Time.deltaTime;
        // 2. 현재시간이 생성시간이 되면
        if (curTime > makeTime)
        {
            curTime = 0;
            // 3. 보트공장에서 보트를 만들어서 내위치에 배치하고싶다.
            int index = Random.Range(0, spawns.Length);

            // 만약 이전에 만든 위치라면 다른 위치로 정하고싶다.
            if (index == prevIdex)
            {
                index = (index + 1) % spawns.Length;
                //index = (index + spawns.Length - 1) % spawns.Length;
                //index++;
                //if (index > spawns.Length - 1)
                //{
                //    index = 0;
                //}
            }

            Transform t = spawns[index].transform;
            Instantiate(boatFactory, t.position, t.rotation);

            prevIdex = index;
        }
    }
}

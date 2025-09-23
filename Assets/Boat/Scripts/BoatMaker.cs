using UnityEngine;

public class BoatMaker : MonoBehaviour
{
    // Spawn����� ������ʹ�.
    public Transform[] spawns;
    // �����ð����� ��Ʈ���忡�� ��Ʈ�� ���� ����ġ�� ��ġ�ϰ�ʹ�.
    float curTime;
    public float makeTime = 2f;
    public GameObject boatFactory;

    // ���� ��ġ�� ����ϰ�ʹ�.
    int prevIdex;
    
    void Start()
    {
        
    }

    void Update()
    {
        // 1. �ð��� �帣�ٰ�
        curTime += Time.deltaTime;
        // 2. ����ð��� �����ð��� �Ǹ�
        if (curTime > makeTime)
        {
            curTime = 0;
            // 3. ��Ʈ���忡�� ��Ʈ�� ���� ����ġ�� ��ġ�ϰ�ʹ�.
            int index = Random.Range(0, spawns.Length);

            // ���� ������ ���� ��ġ��� �ٸ� ��ġ�� ���ϰ�ʹ�.
            if (index == prevIdex)
            {
                index++;
                if (index > spawns.Length - 1)
                {
                    index = 0;
                }
            }

            Transform t = spawns[index].transform;
            Instantiate(boatFactory, t.position, t.rotation);

            prevIdex = index;
        }
    }
}

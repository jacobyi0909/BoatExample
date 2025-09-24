using UnityEngine;

public class Bucket : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // 만약 상대가 플레이어라면
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                // 플레이의 쓰레기를 정산하고싶다.
                Player.instance.CalcGarbagePoint();
            }
        }
    }
}

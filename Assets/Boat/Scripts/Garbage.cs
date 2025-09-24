using UnityEngine;

public class Garbage : MonoBehaviour
{
    void Start()
    {
        
    }

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
                Player.instance.AddGarbage(1, transform.position);
                Destroy(gameObject);
            }
        }
    }
}

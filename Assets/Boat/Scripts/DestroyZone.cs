using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // �ʸ� �ı��ϰ�ʹ�.
        if (other.attachedRigidbody)
        {
            Destroy(other.attachedRigidbody.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}

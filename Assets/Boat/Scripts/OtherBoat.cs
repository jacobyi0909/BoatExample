using UnityEngine;

using Random = UnityEngine.Random;

public class OtherBoat : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;
    void Start()
    {
        // 태어날 때 방향을 정하고싶다.
        // 30% 확률로 주인공 방향, 나머지 확률로는 앞방향으로 방향을 정하고싶다.
        int value = Random.Range(0, 10);
        if (value < 3)
        {
            GameObject player = GameObject.Find("Player");
            // 내가 플레이어를 향하는 방향을 알고싶다.
            dir = player.transform.position - this.transform.position;
            dir.Normalize();
            transform.forward = dir;
        }
        else
        {
            dir = transform.forward;
        }
    }

    void Update()
    {
        // 살아가면서 그 방향으로 계속 가고싶다.
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 만약 부딪힌 상대가 Player라면 결과를 보고싶다.
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Time.timeScale = 0;
            }
        }
    }

}

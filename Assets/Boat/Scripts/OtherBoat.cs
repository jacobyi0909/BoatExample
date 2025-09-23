using UnityEngine;

using Random = UnityEngine.Random;

public class OtherBoat : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;
    void Start()
    {
        // �¾ �� ������ ���ϰ�ʹ�.
        // 30% Ȯ���� ���ΰ� ����, ������ Ȯ���δ� �չ������� ������ ���ϰ�ʹ�.
        int value = Random.Range(0, 10);
        if (value < 3)
        {
            GameObject player = GameObject.Find("Player");
            // ���� �÷��̾ ���ϴ� ������ �˰�ʹ�.
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
        // ��ư��鼭 �� �������� ��� ����ʹ�.
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� �ε��� ��밡 Player��� ����� ����ʹ�.
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Time.timeScale = 0;
            }
        }
    }

}

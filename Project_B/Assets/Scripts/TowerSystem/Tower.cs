using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3.0f;          // Ÿ�� ��Ÿ�
    public float fireRate = 1.0f;       // Ÿ�� �߻� ����
    public LayerMask IsEnemy;           // ���̾� �ý������� ����

    public Collider[] colliderInRange;  // ��Ÿ��� ������ collider �迭

    public List<EnemyController> enemiesinRange = new List<EnemyController>();      // ��Ÿ� �ȿ� �ִ� enemy ������Ʈ List

    public float checkCounter;          // �ð� üũ�� float
    public float checkTime = 0.2f;      // 0.2�� ���� ����

    public bool enemiesUpdate;          // flag ������ üũ �Ϸ��ߴ��� ����
    void Start()
    {
        checkCounter = checkTime;       // ������ �ð��� CheckCounte �� �Է�
    }

    void Update()
    {
        enemiesUpdate = false;

        checkCounter -= Time.deltaTime; // 0.2 => 0�ʰ� �� ������ �ð��� ����

        if(checkCounter <= 0)           // 0�� ���ϰ� �Ǿ�����
        {
            checkCounter = checkTime;   // 0.2�ʷ� �ٽ� ����

            colliderInRange = Physics.OverlapSphere(transform.position, range, IsEnemy);    // �ڽ��� ��ġ, ������, ���̰��� ���ؼ� Collider ����

            enemiesinRange.Clear();     // ����Ʈ �ʱ�ȭ(������ ����������� �ֱ� ����)

            foreach(Collider col in colliderInRange)
            {
                enemiesinRange.Add(col.GetComponent<EnemyController>());                    // Collider �迭�� �ִ� ������Ʈ�� List�� �ִ´�.
            }

            enemiesUpdate = true;
        }
    }
}

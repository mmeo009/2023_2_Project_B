using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speedMod = 1.0f;           // 속도 선언
    public float timeSinceStart = 0.0f;     // 속도 설정
    public bool modEnd = true;              // State 상태 설정 BOOL

    public float moveSpeed;

    [SerializeField]
    private EnemyPath thePath;              // 몬스터가 가지고 있는 path값햐
    private int currentPoint;               // 지금 몇번째 point를 향하고 있는지 확인하는 변수
    private bool reacheEnd;                 // 도달 완료 체크
    // Start is called before the first frame update
    void Start()
    {
        if(thePath == null)
        {
            thePath = FindObjectOfType<EnemyPath>();        // 모든 오브젝트를 검사해서 EnemyPath가 있는 컴포넌트를 가져온다
        }    
    }

    // Update is called once per frame
    void Update()
    {

        if(modEnd == false)
        {
            timeSinceStart -= Time.deltaTime;

            if(timeSinceStart <= 0.0f )
            {
                speedMod = 1.0f;
                modEnd = true;
            }
        }




        if(reacheEnd == false)              // if(!reacheEnd) 도달 이전
        {
            transform.LookAt(thePath.points[currentPoint]);     // 몬스터는 지금 방향을 향해서 본다.(LookAt함수)

            // MoveTowards함수 (내위치, 타겟위치, 속도값)
            transform.position = 
                Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position, moveSpeed * Time.deltaTime * speedMod);

            // Vector3.Distance (A,B) 백터의 거리 => 거리가 0.01이하 일 경우 도착했다고 간주
            if(Vector3.Distance(transform.position, thePath.points[currentPoint].position) < 0.01f)
            {
                currentPoint += 1;              // 다음 포인트로 변경

                if (currentPoint >= thePath.points.Length)       // 포인트 배열 수 보다 높을 경우에는 도착 완료
                {
                    reacheEnd = true;
                }
            }

        }
    }

    public void SetMode(float value)
    {
        modEnd = false;
        speedMod = value;
        timeSinceStart = 2.0f;
    }

}

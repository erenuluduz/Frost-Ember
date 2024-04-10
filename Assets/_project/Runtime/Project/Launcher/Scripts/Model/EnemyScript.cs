using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private Transform target;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float maxDistance = 10;
    [SerializeField] private float shootInterval = 2f;

    private float timer;

    public float hp = 10;
    private bool istargetNotNull;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        target = GameObject.FindGameObjectWithTag("Player").transform;
        istargetNotNull = target != null; // Hedef null de�ilse true d�nd�r�r.
        timer = shootInterval; // Timer'� shootInterval ile ba�lat�r.
    }

    void Update()
    {
        if (istargetNotNull && target != null) // Hedef varsa ve null de�ilse devam eder.
        {
            agent.SetDestination(target.position);
            if (IsPlayerInRange())
            {
                Shoot();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet")) //player'dan mermi geldi�inde sa�l�k d��er ve �ld� m� diye kontrol eder
        {
            hp--;
            IsDead();
        }
    }

    private void Shoot() //player yak�ndaysa 2 ile 5 saniye aras�nda rastgele bir s�re i�erisinde player'�n konumuna ate� eder (pooldan mermiyi �a��r�r)
    {
        if (IsPlayerInRange())
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = UnityEngine.Random.Range(2, 5);
                EnemyBullet instance = ObjectPooler.DequeueObject<EnemyBullet>("EnemyBullet");
                
                instance.transform.position = bulletSpawnPoint.transform.position;
                instance.gameObject.SetActive(true);
                instance.Initialize();
            }
        }
    }

    private bool IsPlayerInRange() //player'�n konumundan kendi konumunu ��kart�r ve belirledi�imiz uzakl�k de�i�keniyle kar��la�t�r�r
    {
        return Vector3.Distance(transform.position, target.position) < maxDistance;
    }

    private void IsDead() // sa�l�k s�f�r m� diye kontrol eder
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

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
        istargetNotNull = target != null; // Hedef null deðilse true döndürür.
        timer = shootInterval; // Timer'ý shootInterval ile baþlatýr.
    }

    void Update()
    {
        if (istargetNotNull && target != null) // Hedef varsa ve null deðilse devam eder.
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
        if (collision.gameObject.CompareTag("PlayerBullet")) //player'dan mermi geldiðinde saðlýk düþer ve öldü mü diye kontrol eder
        {
            hp--;
            IsDead();
        }
    }

    private void Shoot() //player yakýndaysa 2 ile 5 saniye arasýnda rastgele bir süre içerisinde player'ýn konumuna ateþ eder (pooldan mermiyi çaðýrýr)
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

    private bool IsPlayerInRange() //player'ýn konumundan kendi konumunu çýkartýr ve belirlediðimiz uzaklýk deðiþkeniyle karþýlaþtýrýr
    {
        return Vector3.Distance(transform.position, target.position) < maxDistance;
    }

    private void IsDead() // saðlýk sýfýr mý diye kontrol eder
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

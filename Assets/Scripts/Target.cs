using UnityEngine;

public class Target : MonoBehaviour
{
    private readonly float xRange = 4;
    private readonly float minSpeed = 12;
    private readonly float maxSpeed = 16;
    private readonly float maxTorque = 10;
    private readonly float yConstrain = -4f;
    private readonly float zConstrain = 0f;
    private Rigidbody rb;
    private GameManager manage;
    public int point;
    public ParticleSystem particle;
    void Start()
    {
        transform.position = RandomSpawnPosition();
        
        rb = GetComponent<Rigidbody>();
        
        rb.AddForce(Vector3.up * RandomForce(), ForceMode.Impulse);
        
        rb.AddTorque(RandomTorque() , ForceMode.Impulse);

        manage = GameObject.FindObjectOfType<GameManager>();
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), yConstrain, zConstrain);
    }
    private float RandomForce()
    {
        return Random.Range(minSpeed, maxSpeed);
    }
    
    private Vector3 RandomTorque()
    {
        return new Vector3(Random.Range(-maxTorque, maxTorque), 
                           Random.Range(-maxTorque, maxTorque), 
                           Random.Range(-maxTorque, maxTorque));
    }

    private void OnMouseDown()
    {
        if (manage.active)
        {
            Instantiate(particle, transform.position, Quaternion.identity);

            Destroy(gameObject);

            if (gameObject.CompareTag("Bomb"))
            {
                manage.GameOver();

            }

            manage.IncreaseScore(point);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        //if (!other.CompareTag("Bomb"))
        //{
        //    manage.GameOver();

        //}
    }
}

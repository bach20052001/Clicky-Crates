using UnityEngine;

public class Target : MonoBehaviour
{
    private readonly float minSpeed = 10;
    private readonly float maxSpeed = 13;
    private readonly float maxTorque = 10;

    
    private Rigidbody rb;

    public ParticleSystem particle;

    void Start()
    {  
        rb = GetComponent<Rigidbody>();
        
        rb.AddForce(Vector3.up * RandomForce(), ForceMode.Impulse);
        
        rb.AddTorque(RandomTorque() , ForceMode.Impulse);

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
        if (GameManager.Instance.GameState == GameBaseState.PLAY)
        {
            if (gameObject.CompareTag("Bomb"))
            {
                this.PostEvent(GameEvent.OnHitBomb, null);
            }
            else
            {
                this.PostEvent(GameEvent.OnHitProp, null);
            }

            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!gameObject.CompareTag("Bomb"))
        {
            this.PostEvent(GameEvent.OnPropFallingOutScreen, null);

        }
        Destroy(gameObject);
    }
}

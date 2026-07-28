using UnityEngine;

public class Bulleet : MonoBehaviour
{
    public float damage = 10f;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit : " + collision.gameObject.name);

        enemyScript enemy = collision.gameObject.GetComponentInParent<enemyScript>();
        if (enemy != null) 
        {
            Debug.Log("Enemy Hit!");
            enemy.Damage(damage); 
        }

        Destroy(gameObject);
    }
// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
   
}

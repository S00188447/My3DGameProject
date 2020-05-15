using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int bulletDamage = 100;
    public GameObject impactEffect;

    public Text text;
    string message = "You Died";
    

    public void Seek(Transform _target)
    {
        target = _target;
    }
   
    void Update()
    {
        //if(target == null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        //normalizing makes it a constant speed
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);

        //player takes damage
        //TakeDamage(bulletDamage);
        Destroy(gameObject);
        
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (target.gameObject.tag == "Player")
        {
            target.gameObject.GetComponent<PlayerHealth>().currentHealth -= bulletDamage;
      
            if(target.gameObject.GetComponent<PlayerHealth>().currentHealth <= 0)
            {
                text.text = message;
            }
         
                
        }
    }
}

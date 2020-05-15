using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public float bulletDamage = 50f;
    public GameObject impactEffect;

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
        Destroy(gameObject);
        
    }
}

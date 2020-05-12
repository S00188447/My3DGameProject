using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 1f;
    public float impactForce = 30f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 1f;

    public Animator animator;

     void Start()
    {

        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);


        
    }
    void Update()
    {
        if (isReloading)
            return;

        if(currentAmmo <0)
        {
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 12f / fireRate;
            Shoot();

        }
  
        
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading....");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime -.25f);//pauses for the reload time
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);

        currentAmmo = maxAmmo;

        isReloading = false;
    }

    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);



            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGameObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGameObject, 2f);
        }
    }
}

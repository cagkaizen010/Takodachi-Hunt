using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 500f;

    AudioSource m_shootingSound;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;


    void Start()
    {
        m_shootingSound = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") )
        {

            m_shootingSound.Play();
            Shoot();
        }

    }

    void Shoot ()
    {
        RaycastHit hit;
        muzzleFlash.Play();

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range) )
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
                    
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}

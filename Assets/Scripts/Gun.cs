using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // breytur fyrir byssu
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 7;

    public Camera cam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioSource gunshot;

    private float nextFire = 0f;

    void Start()
    {
        // sækir hljóð component 
        gunshot = GetComponent<AudioSource>();   
    }

    void Update()
    {
        // þegar spilarinn ýtir á LMB og tíminn er stærri en næsta skipti sem á skjóta
        if (Input.GetButton("Fire1") && Time.time >= nextFire)
        {
            nextFire = Time.time + 1f / fireRate; // reikna út næsta tíma til að skjóta
            Shoot(); // kallar í shoot fallið
        }
    }

    void Shoot ()
    {
        
        gunshot.Play(); // spilar hljóð
        muzzleFlash.Play(); // kveikir á byssu eld/ljós við skot
        RaycastHit hit; // breyta fyrir 
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)) // finnur hlutinn sem spilarinn skaut
        {

            Target target = hit.transform.GetComponent<Target>(); // sækir component target á því sem er skotið ef gameobjectinn er með það
            if (target != null) // ef target er ekki tómt
            {
                target.TakeDamage(damage); // kallar í TakeDamage fallið
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal)); // gerir far á því sem er skotið
            Destroy(impactGO, 2f); // eyðir gameobjectinn(skotinu) sem á farið eftir 2 sek
        }
    }

}

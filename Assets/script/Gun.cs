using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f,1.5f)]
    private float fireRate = 0.3f; //Atýþ aralýðýmýzý belirledik
    [SerializeField]
    [Range(1, 10)]
    private int damage = 1; //Atýþ hasarý
    [SerializeField]
    //private Transform firePoint; //Atýþ noktamýzý konum olarak belirledik.Viewporttan dolayý sildik.
    //[SerializeField]
    private ParticleSystem muzzleParticle; // Ateþ efekti için particle system atadýk.
    [SerializeField]
    private AudioSource gunFireSource;

    private float timer; //Atýþ zamaný delta olarak frameye baðladýk.

    void Update()
    {
        timer += Time.deltaTime; // Zamaný üst üste ekledik
        if (fireRate>0) //Atýþ yapýyorsak yani basýlý tutma gibiyse
        {
            if (Input.GetButton("Fire1")) // horizontal ve vertical gibi preferences atanmýþ sol cilck manasý geliyor
            {
                timer = 0f;//basýlý tutmak için zamaný sýfýrlýyoruz
                FireGun(); //Metotumuzu çekiyoruz
            }
        }
    }

    private void FireGun()
    {
        
        muzzleParticle.Play();
        gunFireSource.Play();

        Ray ray = Camera.main.ScreenPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 300, Color.red, 1f);
        //1.cisi baþlangýç pozisyonu ,2.cisi gideceði yön,3. rangemizi belirledik,4.rengimizi belirledik

        //Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo,1000f))//Bir þeye çarparsak true dönecek
        {
            var health = hitInfo.collider.GetComponent<Health>();//Birþeye çarparsak colliderý varsa yok olcak.
            if (health != null)
            {
                health.takeDamage(damage);
                Debug.Log("damage aldý");
            }
        }
    }
}

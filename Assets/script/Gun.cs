using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f,1.5f)]
    private float fireRate = 0.3f; //At�� aral���m�z� belirledik
    [SerializeField]
    [Range(1, 10)]
    private int damage = 1; //At�� hasar�
    [SerializeField]
    //private Transform firePoint; //At�� noktam�z� konum olarak belirledik.Viewporttan dolay� sildik.
    //[SerializeField]
    private ParticleSystem muzzleParticle; // Ate� efekti i�in particle system atad�k.
    [SerializeField]
    private AudioSource gunFireSource;

    private float timer; //At�� zaman� delta olarak frameye ba�lad�k.

    void Update()
    {
        timer += Time.deltaTime; // Zaman� �st �ste ekledik
        if (fireRate>0) //At�� yap�yorsak yani bas�l� tutma gibiyse
        {
            if (Input.GetButton("Fire1")) // horizontal ve vertical gibi preferences atanm�� sol cilck manas� geliyor
            {
                timer = 0f;//bas�l� tutmak i�in zaman� s�f�rl�yoruz
                FireGun(); //Metotumuzu �ekiyoruz
            }
        }
    }

    private void FireGun()
    {
        
        muzzleParticle.Play();
        gunFireSource.Play();

        Ray ray = Camera.main.ScreenPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 300, Color.red, 1f);
        //1.cisi ba�lang�� pozisyonu ,2.cisi gidece�i y�n,3. rangemizi belirledik,4.rengimizi belirledik

        //Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo,1000f))//Bir �eye �arparsak true d�necek
        {
            var health = hitInfo.collider.GetComponent<Health>();//Bir�eye �arparsak collider� varsa yok olcak.
            if (health != null)
            {
                health.takeDamage(damage);
                Debug.Log("damage ald�");
            }
        }
    }
}

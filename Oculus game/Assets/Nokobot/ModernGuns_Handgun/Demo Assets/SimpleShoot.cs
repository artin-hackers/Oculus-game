using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleShoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public GameObject otherGun;
    public Transform barrelLocation;
    public Transform casingExitLocation;
    public Text wrongsText;
    public int wrongs;
    public AudioClip wrongSound;


    public float shotPower = 100f;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    public void TriggerShoot()
    {
        GetComponent<Animator>().SetTrigger("Fire");
    }

    void Shoot()
    {
        //  GameObject bullet;
        //  bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        // bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

        GameObject tempFlash;

        var bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Bullet>();
        bullet.OnDeath += () => {
            wrongs++;
            ;
            int wrongs1 = otherGun.GetComponent<SimpleShoot>().wrongs;
            wrongsText.text = "Wrongs:" + Environment.NewLine + (wrongs + wrongs1).ToString();
            GetComponent<AudioSource>().PlayOneShot(wrongSound);
        };
        var bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(barrelLocation.forward * shotPower);

       
        //tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

       // Destroy(tempFlash, 0.5f);
        //  Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);
       
    }

    void CasingRelease()
    {
         GameObject casing;
        //casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }


}

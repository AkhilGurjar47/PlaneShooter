using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public GameObject flash;
    public float bulletSpawnTime = 1f;
    public AudioSource audioSource;
    void Start()
    {
        StartCoroutine(Shoot());
        flash.SetActive(false);
    }

    void Update()
    {
        
    }
    void Fire()
    {
        Instantiate(playerBullet, spawnPoint1.position, Quaternion.identity);
        Instantiate(playerBullet, spawnPoint2.position, Quaternion.identity);
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            Fire();
            audioSource.Play();
            flash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            flash.SetActive(false);
        }
    }
}

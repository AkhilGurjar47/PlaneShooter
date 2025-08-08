using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform []gunPoint;
    public GameObject enemyBullet;
    public float EnemyBullet = 0.5f;
    public GameObject damageEffect;
    public HealthBar healthBar;
    public GameObject EnemyFlash;
    public float speed = 1f;
    public GameObject enemyExplosionPrefab;
    public float Health = 10f;
    public GameObject coinPrefab;
    public AudioClip bulletSound;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioSource audioSource;
    float barSize = 1f;
    float damage = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyShooting());
        EnemyFlash.SetActive(false);
        damage = barSize/Health;
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
    }
    void DamageHealthBar()
    {
        if(Health>0)
        {
            Health -= 1;
            barSize = barSize - damage;
            healthBar.SetSize(barSize);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "PlayerBullet")
        {
            audioSource.PlayOneShot(damageSound);
            DamageHealthBar();
            Destroy(collision.gameObject);
            GameObject damageVFX = Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(damageVFX,0.05f);
            if(Health<=0)
            {
                AudioSource.PlayClipAtPoint(explosionSound,Camera.main.transform.position,0.5f);
                Spawner.Instance.CountDestroyEnemy();
                Destroy(gameObject);
                GameObject enemyExplosion = Instantiate(enemyExplosionPrefab,transform.position,Quaternion.identity);
                Destroy(enemyExplosion,0.4f);
                Instantiate(coinPrefab, transform.position, Quaternion.identity);
            }
        }
    }
    void EnemyFire()
    { 
        for(int i = 0;  i < gunPoint.Length; i++)
        {
            Instantiate(enemyBullet, gunPoint[i].position,Quaternion.identity);
        }
    }
    IEnumerator EnemyShooting()
    {
        while(true)
        {
            yield return new WaitForSeconds(EnemyBullet);
            EnemyFire();
            audioSource.PlayOneShot(bulletSound,0.5f);
            EnemyFlash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            EnemyFlash.SetActive(false);
        }
    }
}

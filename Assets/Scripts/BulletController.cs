using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float firingCone;
    public float maxTimePersistence;
    public float fallOff;
    public float bulletSpeed;
    public float fireSpeed;
    public int bulletNum;
    public GameObject bulletPrefab;

    private float fireDelay;
    private bool fireDelayOn = false;
    private float remainingDelay = 0;
    private List<Bullet> bullets = new List<Bullet>();


    private void Start() 
    {
        fireDelay=2-fireSpeed;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            if(fireDelayOn){
                if(remainingDelay<=0){
                    fireDelayOn=false;
                }
            }
            if(!fireDelayOn){
                Fire();
                remainingDelay = fireDelay;
                fireDelayOn = true;
            }
        }
        remainingDelay-=Time.deltaTime;

        for (int i = 0; i < bullets.Count; i++){
            if(!UpdateBullet(bullets[i])){
                bullets.RemoveAt(i);
            }
        }
    }

    public void Fire()
    {
        float rot = Mathf.Deg2Rad*gameObject.transform.eulerAngles.z;

        for(int i = 1; i <= bulletNum; i++){
            Bullet temp = new Bullet();
            
            float bulletSlice = firingCone*Mathf.PI/bulletNum;
            float localAngle = ((bulletSlice*i)-(Mathf.PI+bulletSlice)/2);
            Vector3 localDirectionBullet = new Vector3(Mathf.Cos(localAngle), Mathf.Sin(localAngle),0);
            Vector3 worldDirectionBullet = new Vector3();
            worldDirectionBullet.x = Mathf.Cos(rot)*localDirectionBullet.x-Mathf.Sin(rot)*localDirectionBullet.y;
            worldDirectionBullet.y = Mathf.Sin(rot)*localDirectionBullet.x+Mathf.Cos(rot)*localDirectionBullet.y;

            temp.dirVel = bulletSpeed * worldDirectionBullet;
            temp.fallOffVector = temp.dirVel * fallOff;
            temp.maxTimePersistence = this.maxTimePersistence;
            temp.bullet = (GameObject) Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);


            bullets.Add(temp);
        }
    }

    public bool UpdateBullet(Bullet bullet){
        try{
        bullet.bullet.transform.position += bullet.dirVel;
        bullet.dirVel-= bullet.fallOffVector*Time.deltaTime;
        bullet.maxTimePersistence-= Time.deltaTime;

        
        if (Vector3.Dot(bullet.dirVel, bullet.fallOffVector) <=0||bullet.maxTimePersistence<=0){
            Destroy(bullet.bullet);
            return false;
        }
        return true;
        }catch{
            return false;
        }
    }
}

public class Bullet {
    public float maxTimePersistence;
    public Vector3 fallOffVector;
    public Vector3 dirVel;
    public GameObject bullet;
}
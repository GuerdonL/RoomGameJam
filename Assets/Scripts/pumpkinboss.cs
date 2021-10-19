using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pumpkinboss : MonoBehaviour
{
   //private Vector2 screenBounds;
   private Rigidbody2D rb;
   private Player player;
   public GameObject pumpkinglocation;
   public GameObject spawner;
   //public float moveSpeed;
   private Vector3 directionToPlayer;
   public bool attack;
   public  GameObject test;
    public  GameObject test2;
   public GameObject spawned;
   private Animation anim;
  WaitForSeconds wait = new WaitForSeconds(2.5f);
  public Collider2D m_Collider;
   public Collider2D p_Collider;
    private AudioSource audioSourced;
    void Start()
    {
        audioSourced=GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animation>();
        anim["jumpanim"].layer = 123;
        anim["jumpdown"].layer = 123;
        rb=GetComponent<Rigidbody2D>();
        player=FindObjectOfType(typeof(Player)) as Player;
        attack=true;

    //this is the rotating attacking pattern. time in between to attack the boss
    InvokeRepeating("cour",3f,25f);
    InvokeRepeating("Enemies",26f,25f);
    }

   public void cancel()
    {
    m_Collider.enabled = true;
    p_Collider.enabled = true;
    Debug.Log("respawns boss at location");
    rb.MovePosition(pumpkinglocation.transform.position);
    anim.Stop("jumpanim");  
    anim.Play("jumpdown");
    Invoke("Enemies",1f);
    }
  
    
    IEnumerator jumpattack()
    {
        attack=false;      
        for(int i = 1; i <=5; i++) 
        {
            m_Collider.enabled = false;
            p_Collider.enabled = false;
            {
            Invoke("Spawn", 2.4f);
            Invoke("MoveEnemy", 3.6f);
            
            yield return wait;
            }
        }
        Invoke("cancel",2f);
    }
public void Enemies()
    {
        for(int i=0;i<5;i++)
        {
        spawned=Instantiate(test2) as GameObject;
        spawned.transform.position=(spawner.transform.position);
        }
    }
    
    public void Spawn()
    {
        {
        player=FindObjectOfType(typeof(Player)) as Player;
        spawned=Instantiate(test) as GameObject;
        spawned.transform.position=(player.transform.position);
        Destroy (spawned,2.5f);
        }
    }

    private void MoveEnemy()
    {
        {        
        anim.Play("jumpanim");
        audioSourced.Play();
        //unused chasing script, dont need anymore
        //directionToPlayer=(player.transform.position-transform.position).normalized;
        //rb.position=new Vector2(directionToPlayer.x, directionToPlayer.y)*moveSpeed*cango;   
        rb.MovePosition(spawned.transform.position);
        }
    }

private void cour()
{
   StartCoroutine(jumpattack());    
}







}

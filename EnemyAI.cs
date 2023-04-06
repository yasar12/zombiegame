using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    float turnspeed = 10f;
    [SerializeField] Transform Target; //target biz oluyoruz
    NavMeshAgent agent;
    [SerializeField] float chaserange = 10f;//düşmanın bizi max algılayabileceği mesafe
    float distancetotarget=Mathf.Infinity;
    bool isprovoked=false;
    enemyhealt deadcontrol;
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        deadcontrol=GetComponent<enemyhealt>();
    }

    
    void Update()
    {
        if (deadcontrol.Isdead()) { 
            this.enabled = false;
        agent.enabled = false;
        } 

        distancetotarget=Vector3.Distance(Target.position, transform.position);//düşmanın bize olan uzaklığını ölçmeye yarar
        if (isprovoked)
        {
            engagetarget();
        }
        else if(distancetotarget<=chaserange)//eğer belirtilen düşman menzilinin içine girdiysek düşmanı harekete geçirmeye hazır hale getiren boo değeri true olur
        { 
 isprovoked = true;
        }
       
    }

    private void OnDrawGizmosSelected()//düşmanın saldırı menzilini görmek için
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, chaserange);

    }
    void engagetarget() {
        facetarget();
        if (distancetotarget>=agent.stoppingDistance)
        {
 chasetarget(); //düşmanın bizi takip etmesini sağlayan metod

        }
        if (distancetotarget <= agent.stoppingDistance)
        {
            Attacktarget();//düşmanın bize saldırmasını sağlayan metod
        }
    }

     void chasetarget()//düşmanın bizi takip etmesini sağlayan metod
    {
        GetComponent<Animator>().SetBool("attack", false);//eğer düşman yanımızdayken biz tekrar harekete geçersek saldırmayı durdurmasına yarıyor
        GetComponent<Animator>().SetTrigger("move");//düşmanın hareket etmesini sağlıyor
        agent.SetDestination(Target.position);//düşmanın konumunu bizle aynı yapmaya yani bizi takip etmesini sağlar
    }
    private void facetarget()
    {
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * turnspeed);

    }
    void Attacktarget()//düşmanın bize saldırmasını sağlayan metod
    {
        GetComponent<Animator>().SetBool("attack",true);//düşmanın saldırıya geçtiğinde oynatılcak animasyonunu etkinleştirir
    }

    public void OnDamageTaken() {

    isprovoked = true;
    }
}

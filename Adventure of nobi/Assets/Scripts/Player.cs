using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [System.Serializable]


   public class PlayerStats {
       public int Health = 100; //Maxhealth
       public int currentHealth;
   }
   public PlayerStats playerStats = new PlayerStats();
   public HealthBar healthBar;

   public int fallYBoundary = -20;


   void Update(){
       if(transform.position.y <= fallYBoundary) 
       DamagePlayer(200);
   }
   
   public void DamagePlayer(int damage){
       playerStats.Health -=damage;
       if (playerStats.Health <=0) {
         GameMaster.KillPlayer(this);
         
       }
   }

}

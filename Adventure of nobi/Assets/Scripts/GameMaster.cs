using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    void Start (){
        if (gm == null) {
            gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
        }
    }

    // void Start() {
    // if (gm == null) 
    // {gm = this;}
    // }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 1;

    public IEnumerator RespawnPlayer(){
        Debug.Log("add audio");
        yield return new WaitForSeconds (spawnDelay);

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("TODO: Add Spawn Particle");
    }

    public static void KillPlayer(Player player){
        Destroy(player.gameObject);
        gm.StartCoroutine (gm.RespawnPlayer());
    
    }
}

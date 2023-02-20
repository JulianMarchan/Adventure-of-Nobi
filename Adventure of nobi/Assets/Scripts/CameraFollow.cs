using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  public Transform target;
  public Vector3 offset;
  [Range(1,10)]
  public float smoothFactor;
  public float targetPositionBoundary = -2;
  
  float nextTimeToSearch = 0;


  private void FixedUpdate()
  {
    Follow();
  }
  void Follow()
  {
    if (target == null)
    {
      FindPlayer();
      return;
    }
    
     Vector3 targetPosition = target.position + offset;
     Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor*Time.fixedDeltaTime);

     targetPosition = new Vector3 (targetPosition.x, Mathf.Clamp(targetPosition.y, targetPositionBoundary, Mathf.Infinity), targetPosition.z);
     transform.position = targetPosition;
  }
  void FindPlayer(){
    if(nextTimeToSearch <= Time.time){
      GameObject searchResult = GameObject.FindGameObjectWithTag ("Player");
      if (searchResult != null)
      target = searchResult.transform;
      nextTimeToSearch = Time.time + 0.5f;
    }
  }
}

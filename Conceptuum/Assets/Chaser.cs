using UnityEngine;
using System.Collections;


public class Chaser : MonoBehaviour {

    public float speed = 20.0f;
    public float minDist = 1f;
    public float maxDist = 10f;    
    private Transform player;

    
    private Vector3 robotHome;
        


    void Start() {            
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        robotHome = GameObject.FindWithTag("RobotHome").GetComponent<Transform>().position;
        
    }


    void Update() {
                

        var dp = player.position - Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)).GetPoint(0);
        dp.x = 0;
        dp.z = 0;
        var playerFront = player.position + dp.normalized;

        

        var goingToPlayer = Vector3.Distance(player.position, robotHome) < maxDist;

       var target = goingToPlayer ? playerFront : robotHome;



        var robotHead = transform.FindChild("RobotHead");
        var lookTarget = goingToPlayer ? Camera.main.transform.position : robotHome+robotHead.localPosition;
        var rotation = Quaternion.LookRotation((lookTarget - robotHead.position).normalized, Vector3.up);
        robotHead.rotation = Quaternion.Slerp(robotHead.rotation, rotation, 1f * Time.deltaTime);
        
        

        if (Vector3.Distance(transform.position, player.position) > minDist && Vector3.Distance(transform.position, target) > 0.1) {
            var direction = target - transform.position;            
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
           
    }

  
}

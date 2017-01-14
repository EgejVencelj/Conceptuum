using UnityEngine;
using System.Collections;


public class Chaser : MonoBehaviour {

    public float speed = 20.0f;
    public float minDist = 1f;
    public float maxDist = 10f;
    private Transform target;
    private Transform player;
    private Transform robotHome;
  

    void Start() {            
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindWithTag("RobotHome").GetComponent<Transform>();
        target = player;
    }


    void Update() {/*

        var robotMesh = transform.FindChild("RobotHead");
        robotMesh.LookAt(target);
    
        

        target = Vector3.Distance(transform.position, robotHome.position) < maxDist ? player : robotHome;

        float targetDistance = Vector3.Distance(transform.position, target.position);

        if (targetDistance > minDist) {
            var direction = target.position - transform.position;            
            transform.position += direction.normalized * speed * Time.deltaTime;
        }*/
           
    }

  
}

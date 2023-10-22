using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    // Start is called before the first frame 

    int counter = 0;

    float charge =0;

    string enemyName = "Darth Vader";

    bool doorIsOpen = false;

    public GameObject door;
    Vector3 spawnPoint = new Vector3(0f, 2f, 0f);
    [SerializeField]
    Transform ballSpawn;
    float ballSpawnTimer =0;
    float ballSpawnInterval = 0.2f;

    void Start()
    {
        this.gameObject.name = enemyName;
        Debug.Log("The Variables script is running on the " + this.gameObject.name + "gameObject");
        if(door == null){ door = GameObject.Find("Door"); }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            counter++;
            Debug.Log("The space bar has been pressed" + counter + "times.");
        }
        if (Input.GetKey(KeyCode.C))
        {
            charge += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.C))  {
            Debug.Log("Charge is " + charge + ".");
            charge = 0f;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            if(doorIsOpen == true) {
                door.SetActive(false);
            }
            else {
                door.SetActive(true);
            }
            doorIsOpen = !doorIsOpen;

        }
        if(Input.GetKey(KeyCode.B)){
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = spawnPoint;
            cube.AddComponent<Rigidbody>();
        }
        ballSpawnTimer += Time.deltaTime;
        if(ballSpawnTimer > ballSpawnInterval){
            SpawnBall();
            ballSpawnTimer = 0;
            
        }
    }
    void SpawnBall(){
            GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            ball.transform.position = ballSpawn.position;
            ball.transform.position = (Random.insideUnitSphere * .2f) + ballSpawn.position;
            ball.transform.localScale = Vector3.one * 0.2f;
            ball.AddComponent(typeof(Rigidbody));
            ball.AddComponent(typeof(Light));
          

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private GameObject[] Walls;
    private GameObject[] Boxes;

    private bool ReadyToMove;

    // Start is called before the first frame update
    void Start()
    {
        Walls = GameObject.FindGameObjectsWithTag("Wall");
        Boxes = GameObject.FindGameObjectsWithTag("Box");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Move(Vector2 direction){
        if (Mathf.Abs(direction.x) < 0.5){
            direction.x = 0;
        } else {
            direction.y = 0;
        }
        direction.Normalize();
        
        if (Blocked(transform.position, direction)){
            return false;
        } else {
            transform.Translate(direction);
            return true;
        }
    }

    public bool Blocked(Vector3 position, Vector2 direction){
    
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
    
        foreach (var wall in Walls){
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y){
                return true;
            }
        }

        foreach (var box in Boxes){
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y){
                Box objPush = box.GetComponent<Box>();
                if (objPush && objPush.Move(direction)){
                    return false;
                } else {
                    return true;
                }
            }

        }
        return false;
    }

























}

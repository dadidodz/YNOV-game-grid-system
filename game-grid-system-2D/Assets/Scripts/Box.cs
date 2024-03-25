using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool m_OnCross;
    private GameObject[] Walls;
    private GameObject[] Boxes;
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
        if (BoxBlocked(transform.position, direction)){
            return false;
        } else {
            transform.Translate(direction);
            TestForOnCross();
            return true;
        }
    }

    public bool BoxBlocked(Vector3 position, Vector2 direction){
    
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
    
        foreach (var wall in Walls){
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y){
                return true;
            }
        }

        foreach (var box in Boxes){
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y){
                return true;
            }
        }
        return false;
    }

    void TestForOnCross(){
        GameObject[] crosses = GameObject.FindGameObjectsWithTag("Cross");
        foreach (var cross in crosses){
            if (transform.position.x == cross.transform.position.x && transform.position.y == cross.transform.position.y){
                GetComponent<SpriteRenderer>().color = Color.blue;
                m_OnCross = true;
                return;
            }
        }
        GetComponent<SpriteRenderer>().color = Color.red;
        m_OnCross = false;
    }

}

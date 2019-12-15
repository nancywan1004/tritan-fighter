using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //checks for entering a trigger
	void OnTriggerEnter2D(Collider2D other){
		//checks other collider's tag
		if(other.gameObject.tag == "Enemy"){
			score++;								//increments score
		}
    }

    
}

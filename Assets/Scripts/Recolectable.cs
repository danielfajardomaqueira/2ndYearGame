using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolectable : MonoBehaviour
{

    public LogCounter logcounter;
    

    void Start()
    {
        logcounter = GameObject.FindGameObjectWithTag("Player").GetComponent<LogCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
          logcounter.logCounter = logcounter.logCounter + 1;
          
          Destroy(gameObject);

            logcounter.logsText.text = "Logs Counter: " + logcounter.logCounter;
        }
        
    }

}

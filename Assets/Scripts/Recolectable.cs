using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolectable : MonoBehaviour
{

    private LogCounter logcounter;



    void Start()
    {
        logcounter = GameObject.FindGameObjectWithTag("Player").GetComponent<LogCounter>();
    }

    // Every time the player picks up an item, +1 is added to the log counter
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnCabin : MonoBehaviour
{
    public GameObject cabinInstance;
    private KeyCode keyCode = KeyCode.E;
    public bool insideCollider = false;
    public LogCounter logs;

    public AudioSource audioSource;
    public AudioClip cabinSFX;

    [SerializeField] private GameObject winMenu;
    public bool winPanel = false;

    void Start()
    {
        logs = GameObject.FindObjectOfType<LogCounter>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyCode) && insideCollider == true && logs.logCounter >= 10)
        {
            Instantiate(cabinInstance, transform.position, transform.rotation);
            audioSource.PlayOneShot(cabinSFX, 1.0f);
            logs.logCounter = 0f;
            winMenu.SetActive(!winPanel);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideCollider = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideCollider = false;
        }
    }
}

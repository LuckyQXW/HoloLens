using UnityEngine;
using System.Collections;

public class DataMask : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Mapbox.Examples.LabelTextSetter>().ShowText();
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Mapbox.Examples.LabelTextSetter>().HideText();
        }
    }
}

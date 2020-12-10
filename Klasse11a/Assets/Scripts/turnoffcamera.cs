using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnoffcamera : MonoBehaviour
{
    public GameObject dollycam1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dollycam1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Dollycam1()
    {
        yield return new WaitForSecondsRealtime(25.26f);
        dollycam1.SetActive(false);
    }
}

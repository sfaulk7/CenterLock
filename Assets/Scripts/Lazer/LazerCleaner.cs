using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerCleaner : MonoBehaviour
{
    [SerializeField]
    private float _lazerLifetime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void DestroyLazer()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(DestroyLazer), _lazerLifetime);
    }
}

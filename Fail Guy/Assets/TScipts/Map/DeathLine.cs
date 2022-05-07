using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLine : MonoBehaviour
{
    [SerializeField]
    public float deathLineStartTime = 10f;

    [SerializeField]
    public float speedRate = 0.2f;
    
    [SerializeField]
    public float scaleRate = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.startTime > deathLineStartTime)
        {
            this.transform.localScale += new Vector3(0, 0, scaleRate * speedRate * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLine : MonoBehaviour
{

    [SerializeField]
    private float startLineDisappearTime = 3.0f;

    [SerializeField]
    private float disappearRate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.startTime > startLineDisappearTime)
        {
            this.transform.position -= new Vector3(0, disappearRate * Time.deltaTime, 0);
        }

        if (this.transform.position.y > 1.0)
        {
            Destroy(this.gameObject);
        }
    }
}

using UnityEngine;

public class ChartSwap : MonoBehaviour
{
    private GameObject chart;
    
    private void Awake()
    {
        chart = GameObject.Find("Chart");
        // returns a single object, or null, no ideal as this might clash if multiple objects with the same names
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.transform.parent.parent.gameObject.SetActive(false);
        chart.GetComponent<ChartSetup>().AddNewLine();
    }
}

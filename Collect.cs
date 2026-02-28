using UnityEngine;

public class Collect : MonoBehaviour
{
    public DisplayStats displayStats;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.CompareTag("Coin"))
                {
                    displayStats.UpdateCoins();
                    Destroy(hit.collider.gameObject);
                }            
            }
        }
    }
}

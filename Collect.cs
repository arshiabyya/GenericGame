using UnityEngine;

public class Collect : MonoBehaviour
{
    public DisplayStats displayStats;
    public int hitCount = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                switch(hit.collider.tag)
                {
                    case "Coin":
                        displayStats.UpdateCoins();
                        hitCount += 1;
                        if (hitCount > 0)
                        {
                            Destroy(hit.collider.gameObject);
                            hitCount = 0;
                        }
                        break;
                    case "Wood":
                        hitCount += 1;
                        if (hitCount >= 5)
                        {
                            Destroy(hit.collider.gameObject);
                            hitCount = 0;
                        }
                        break;
                }            
            }
        }
    }
}

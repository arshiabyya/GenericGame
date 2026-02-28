using UnityEngine; //always call UnityEngine at the top of your script, it is the main library for Unity

public class Stats : MonoBehaviour //the name of the class must match the name of the script file
{
    private int coinsCollected; // the number of coins collected by the player, initialized to 0
    public int totalCoins; // the total number of coins collected, which can be displayed in the UI or used for other purposes

    void Start() // Start is called before the first frame update, used for initialization
    {
        PlayerPrefs.SetFloat("Coins", coinsCollected); // initialize the "Coins" key in PlayerPrefs to the value of coinsCollected, which is 0 at the start of the game
    }

    void Update() // Update is called once per frame, used for handling input and updating the game state
    {
        totalCoins = PlayerPrefs.GetInt("Coins"); // update the totalCoins variable with the current value stored in PlayerPrefs under the "Coins" key, which can be used for displaying the total coins collected in the UI or for other game logic
    }
}

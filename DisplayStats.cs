using UnityEngine; //always call UnityEngine at the top of your script, it is the main library for Unity
using UnityEngine.UI; // include the UnityEngine.UI namespace to access UI components like Text
using TMPro; // include the TMPro namespace to access TextMeshPro components for better text rendering in the UI

public class DisplayStats : MonoBehaviour
{
    public int current_coins;
    public TMP_Text coins; // a reference to the TextMeshPro UI element that will display the number of coins collected, which can be assigned in the Unity Editor by dragging the appropriate UI element into this field
    void Start()
    {
        current_coins = PlayerPrefs.GetInt("Coins");
    }

    public void UpdateCoins() // Update coins called in Collect script every time new coin is collected
    {
        current_coins = PlayerPrefs.GetInt("Coins");
        PlayerPrefs.SetInt("Coins", current_coins + 1);
        coins.text = PlayerPrefs.GetInt("Coins").ToString(); // update the text of the coins UI element with the current value of coins collected, retrieved from PlayerPrefs and converted to a string for display)
    }
}

using UnityEngine;
using UnityEngine.UI;

public class MutiplayerOption : MonoBehaviour
{
    public Dropdown timeDropdown;

    public void StartGame()
    {
        int optionIndex = timeDropdown.value;
        int selectedValue = int.Parse(timeDropdown.options[optionIndex].text);

        print("Valor seleccionado: " + selectedValue.ToString());

        (MultiplayerGameMode.Instance as MultiplayerGameMode).StartGame(selectedValue);

        Destroy(gameObject);
    }
}

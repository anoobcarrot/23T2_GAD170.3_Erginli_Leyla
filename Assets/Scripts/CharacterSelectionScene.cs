using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionScene : MonoBehaviour
{
    public void CharacterSelection()
    {

        // Go scene
        SceneManager.LoadScene("Character Selection");
    }
}

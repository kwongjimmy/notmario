using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewGameScript : MonoBehaviour {

    public void OnClick() {
        SceneManager.LoadScene("123");
    }
}

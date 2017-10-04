using UnityEngine;
using UnityEngine.VR;
using UnityEngine.SceneManagement;

public class RedirectDevice : MonoBehaviour {

    public void Start()
    {
        RedirectToMenu();
    }

    public void RedirectToMenu () {
		if(VRDevice.isPresent)
            SceneManager.LoadScene("vrMenu");
        else
            SceneManager.LoadScene("basicMenu");
    }

}

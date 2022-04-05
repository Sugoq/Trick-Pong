using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupCollider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject particle;
    
    

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Destroy (Instantiate(particle,transform.position + Vector3.up *1.3f,Quaternion.identity),5);
        UIController.instance.GameScreenOff();
        UIController.instance.CallWinScreen();
        LevelLoader.instance.WinLevel();
        Ball.instance.onCup = true;
        StarController.instance.UiStars();

    }

}

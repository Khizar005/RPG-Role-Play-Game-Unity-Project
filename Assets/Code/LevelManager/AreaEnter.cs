using UnityEngine;

public class AreaEnter : MonoBehaviour
{
    public string transitionAreaName;
    public static AreaEnter instacne;
 
    void Start()
    {
        instacne = this;
        if(transitionAreaName == Player.instance.transitionAreaName)
        {
            Player.instance.transform.position =AreaEnter.instacne.transform.position;
        }
    }

}

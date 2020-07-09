using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RandomSkinSelector : MonoBehaviour
{
    public string SkinFrameinFrame = "SkinFrameinFrame";
    public string SkinImage = "SkinImage";
    public string skinButtonTag = "SkinButton";

    public float waitTime = 0.2f;
    private float waitTimeCounter = 0.2f;
    public Color SelectionColor;
    public Color UnselectedColor;


    private List<GameObject> SkinButtons = null;
    // Start is called before the first frame update
    void Start()
    {
        SkinButtons = GameObject.FindGameObjectsWithTag(skinButtonTag)?.ToList();
    }

    public void UnlockSkin()
    {
        waitTimeCounter = waitTime;
        if (SkinButtons != null && SkinButtons.Count > 0)
        {
            // TODO: Set ALL unselected
            StartCoroutine(UnluckSkinSequence());
        }

    }

    int loopcount = 1;
    int selection = -1;

    private IEnumerator UnluckSkinSequence()
    {
        loopcount = SkinButtons.Count ;
        selection = -1;
        for (int i = 0; i < loopcount; i++)
        {

            selection = Random.Range(0, SkinButtons.Count);

            SkinButtons[selection].GetComponent<Image>().color = SelectionColor;
            yield return new WaitForSeconds(waitTimeCounter);
            if (i != loopcount - 1)
            {
                SkinButtons[selection].GetComponent<Image>().color = UnselectedColor;
            }
            else
            {
                // TODO: Open image 
                SkinButtons[selection].transform.Find(SkinImage).gameObject.SetActive(false);
                SkinButtons[selection].transform.Find(SkinFrameinFrame).gameObject.SetActive(true);
                SkinButtons.RemoveAt(selection);
            }
            waitTimeCounter *= 1.2f;

        }
        yield return null;
    }

}

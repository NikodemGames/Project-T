using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingScreenManager : MonoBehaviour
{
	public List<string> loadingTips = new List<string>();

	[SerializeField]
	private TextMeshProUGUI hintText;

    private void Start()
    {
        InvokeRepeating(nameof(UpdateHint),0, 10);
    }

    public void UpdateHint()
	{
        if(loadingTips.Count < 1)
        {
            hintText.text = "Nothing to display";
            return;
        }
        int randomIdex = Random.Range(0,loadingTips.Count);
        hintText.text = loadingTips[randomIdex];
	}


}

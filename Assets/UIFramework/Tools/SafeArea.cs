using UnityEngine;

public class SafeArea : MonoBehaviour
{
	RectTransform panel;
	Rect lastSafeArea = new Rect(0, 0, 0, 0);
	public bool applyHorizontal = true;
	public bool applyVertical = true;
	Rect safeArea;

	void Awake()
	{
		panel = GetComponent<RectTransform>();
		Refresh();
	}

	void Update()
	{
		Refresh(); // wil this not have performance issue
	}

	void Refresh()
	{
		safeArea = GetSafeArea();

		ApplySafeArea(safeArea);

		//if (safeArea != lastSafeArea)
		//{
		//	ApplySafeArea(safeArea);
		//}
	}

	Rect GetSafeArea()
	{
		return Screen.safeArea;
	}

	void ApplySafeArea(Rect r)
    {
        lastSafeArea = r;
		Vector2 anchorMin = r.position; // 136,0 (pixel 5)
		Vector2 anchorMax = r.position + r.size; // 136+2204,1080 

		Debug.Log(anchorMin + " _ " + anchorMax);
		Debug.Log(r.size);

		if (applyHorizontal && applyVertical)
		{
			anchorMin.x /= Screen.width;   //136/2340 = .058
			anchorMin.y /= Screen.height; //0/1080

			anchorMax.x /= Screen.width;  // 2340/2340 = 1
			anchorMax.y /= Screen.height; // 1080/1080 = 1
		}
		else if (!applyHorizontal && !applyVertical)
		{
			anchorMin.x = 0;
			anchorMin.y = 0;

			anchorMax.x = 1;
			anchorMax.y = 1;
		}
		else if (applyHorizontal)
		{
			anchorMin.x /= Screen.width;
			anchorMin.y = 0;

			anchorMax.x /= Screen.width;
			anchorMax.y = 1;
		}
		else if (applyVertical)
		{
			anchorMin.x = 0;
			anchorMin.y /= Screen.height;

			anchorMax.x = 1;
			anchorMax.y /= Screen.height;
		}

		panel.anchorMin = anchorMin;
		panel.anchorMax = anchorMax;
	}

}

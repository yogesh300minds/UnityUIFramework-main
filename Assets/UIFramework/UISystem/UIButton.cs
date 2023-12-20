﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	RectTransform rectTransform;
	Vector2 largeSize;
	float mux = 1.05f;
	public bool canAnimate = true;
	public AnimationCurve buttonCurve;
	void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		largeSize = new Vector2(rectTransform.localScale.x * mux, rectTransform.localScale.y * mux);
	}
	enum PointerState
	{
		None,
		Down,
		Up
	}

	public virtual void OnPointerUp(PointerEventData data)
	{
		if (canAnimate && GetComponent<Button>().IsInteractable())
		{
			StopAllCoroutines();
			StartCoroutine(Animate(largeSize, Vector2.one));
		}

	}

	public virtual void OnPointerDown(PointerEventData data)
	{
		if (canAnimate && GetComponent<Button>().IsInteractable())
		{
			StopAllCoroutines();
			StartCoroutine(Animate(Vector2.one, largeSize));
		}
	}

	IEnumerator Animate(Vector2 fromScale, Vector2 toScale)
	{

		float elapsed = 0;
		float duration = 0.2f;
		while (elapsed < duration)
		{
			rectTransform.localScale = Vector2.LerpUnclamped(fromScale, toScale, buttonCurve.Evaluate(elapsed / duration));
			elapsed += Time.deltaTime;
			yield return null;

		}
		rectTransform.localScale = toScale;
		yield return null;
	}
}


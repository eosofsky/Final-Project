using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipUser : MonoBehaviour {

	public string tooltip;

	void OnMouseOver () {
		Tooltip.Instance.ShowTooltip (tooltip);
	}

	void OnMouseExit () {
		Tooltip.Instance.HideTooltip ();
	}
}

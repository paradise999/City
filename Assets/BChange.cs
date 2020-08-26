using UnityEngine;
using UnityEngine.UI;

public class BChange : MonoBehaviour {
	public InputField fig, fir;

	public void OnClick () {
		bool s = false, r = true;
		Toggle tg = FindObjectOfType<Toggle> ();
		Slider sr = FindObjectOfType<Slider> ();
		s = tg.isOn;
		if (sr.normalizedValue == 0)
			r = true;
		else
			r = false;
		GameObject g = GetComponent<BSelect> ().o;
		if (g.name.IndexOf ("Lighter(Clone)") != -1) {
			Timer t = g.GetComponent<Timer> ();
			if (!int.TryParse (fig.text, out t.g))
				t.g = 10;
			if (!int.TryParse (fir.text, out t.r))
				t.r = 10;
			g.GetComponent<road> ().s = s;
			t.red = r;
		}
	}
	

}

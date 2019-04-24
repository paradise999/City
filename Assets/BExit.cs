using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;


public class BExit : MonoBehaviour {

	public void OnClick ()
	{			
		string s = MessageBox.Show("Do you want close program?", "Exit", MessageBoxButtons.YesNo).ToString();
		if (s == "Yes") {
			UnityEngine.Application.Quit ();
		}
	}
}

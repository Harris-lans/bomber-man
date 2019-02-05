﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIScreen : MonoBehaviour 
{
	#region Member Variables
		
		[Header("Screen Details")]
		[SerializeField]
		public SO_Tag UIScreenTag;
        
		protected UIManager _UIManager;

	#endregion

	#region Life Cycle

		protected virtual void Awake()
		{
			_UIManager = UIManager.Instance;
		}

	#endregion

	#region Member Functions

		public void ShowScreen()
		{
		    gameObject.SetActive(true);
		}

		public void HideScreen()
		{
            gameObject.SetActive(false);
		}

    #endregion
}
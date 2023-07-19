using System;
using Cysharp.Threading.Tasks;
using IWorld.ContractDefinition;
using mud.Unity;
using UniRx;
using DefaultNamespace;
using UnityEngine;
using ObservableExtensions = UniRx.ObservableExtensions;

public class TypeTestManager : MonoBehaviour
{
	private IDisposable _counterSub;
	public int typeInt;
	private NetworkManager net;

	// Start is called before the first frame update
	void Start()
	{
		net = NetworkManager.Instance;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SendTypeTxAsync().Forget();
		}
	}

	private async UniTaskVoid SendTypeTxAsync()
	{
		try
		{
			await net.worldSend.TxExecute<CreateNewTypeFunction>();
		}
		catch (Exception ex)
		{
			// Handle your exception here
			Debug.LogException(ex);
		}
	}

	private void OnIncrement(TypeTestTableUpdate update)
	{
		var currentValue = update.TypedValue.Item1;
		if (currentValue == null) return;

		// Debug.Log("Type is now: " + currentValue.value);
		Debug.Log(currentValue.value == null ? "Type is null" : "Type is " + (int)(currentValue.value));

	}

	private void OnDestroy()
	{
		_counterSub?.Dispose();
	}
}

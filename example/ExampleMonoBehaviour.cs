using System;
using Switchboard;
using UnityEngine;
using ILogger = Switchboard.ILogger;

[RequireComponent(typeof(MeshRenderer))]
public class ExampleMonoBehaviour : MonoBehaviour
{
	[Min(0.0f)]
	public float LogFrequency = 0.5f;
	private float Timer;

	private ILogger Logger;
	private IModel Model;

	private MeshRenderer Renderer;

	// Reference InjectorLocator once, at the start of Awake(), to get the IInjector.
	// If an IInjector is available, try to get dependencies.
	// If a required dependency is not provided, throwing an exception will disable the component.
	private void Awake()
	{
		IInjector injector = InjectorLocator.GetInjector();
		if(injector != null)
		{
			Logger = injector.Get<ILogger>();
			Model = injector.Get<IModel>();
		}
		if(Logger == null)
			throw new Exception("Logger unavailable!");

		if(Model == null)
			Logger.LogWarning("Don't forget to add an IModel to the DependencyInjector.");

		Renderer = GetComponent<MeshRenderer>();
	}

	private void Update()
	{
		UpdateRenderer();
		UpdateLog();
	}

	// All of the changes that update the position and properties of the renderer components in the scene come from the model data, yet it is a loosely coupled dependency upon an interface.
	// This is not intended to imply that model data at the composition root should be moving MonoBehaviours around.
	// It is only meant to demonstrate how it is possible to keep models at the root of your application as pure C# objects, loosely coupled to scene data treated as the view layer.
	private void UpdateRenderer()
	{
		if(Model != null)
		{
			transform.position = Model.Position;
			if(Renderer.material.color != Model.Color)
				Renderer.material.color = Model.Color;
		}
	}

	// These logs are written to a persistent file on disk without allocating any new objects for garbage collection.
	private void UpdateLog()
	{
		Timer += Time.unscaledDeltaTime;
		if(LogFrequency > 0.0f && Timer >= LogFrequency)
		{
			Timer -= LogFrequency;
			if(Timer >= LogFrequency)
				Timer = 0.0f;

			if(Model != null)
			{
				StringMaker stringMaker = StringMaker.ThreadStaticInstance;
				stringMaker.Length = 0;
				stringMaker.Append("Position: ").Append(Model.Position)
					.Append(" Color: ").Append(Model.Color);
				Logger.LogInformation(stringMaker);
				stringMaker.Clear();
			}
		}
	}
}

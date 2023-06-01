using System;
using Switchboard;
using UnityEngine;
using Logger = Switchboard.Logger;

[CreateAssetMenu(fileName = "ExampleInjectorBase", menuName = "Switchboard/Examples/Injector Base", order = SwitchboardMenuOrder.Value)]
public sealed class ExampleInjectorBase : DependencyInjector
{
	[Expandable]
	public ExampleModelBase Model;

	private LogFileManager LogFileManager;

	protected override void Activation()
	{
		LogFileManager = new LogFileManager();
		if(LogFileManager.StartLogging())
		{
			if(Application.isEditor == false)
				Logger.RemoveUnityLogger();
			Logger.HijackUnityLogHandler();
		}
		new ClockSynchronizer(ApplicationTicker.StaticInstance);

		if(Model != null)
			ApplicationTicker.StaticInstance.StartTick(Model.TickAction);
	}

	protected override void Deactivation()
	{
		if(Model != null)
			ApplicationTicker.StaticInstance.StopTick(Model.TickAction);

		Logger.ResetUnityLogHandler();
		Logger.AddUnityLogger();
		LogFileManager.StopLogging();
		LogFileManager = null;
	}

	protected override object GetInstanceOf(Type type)
	{
		if(type.IsAssignableFrom(TheTypeOf<ExampleModelBase>.Type))
			return Model;

		if(type == TheTypeOf<Switchboard.ILogger>.Type)
			return Logger.Root;

		if(type.IsAssignableFrom(TheTypeOf<ApplicationTicker>.Type))
			return ApplicationTicker.StaticInstance;

		return null;
	}
}

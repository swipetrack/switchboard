using System;

public static class InjectorLocator
{
	private static Func<IInjector> LocatorDelegate;

	public static IInjector GetInjector() => LocatorDelegate?.Invoke();

	public static void AssignLocatorDelegate(Func<IInjector> locatorDelegate)
	{
		if(locatorDelegate == null)
			throw new ArgumentNullException(nameof(locatorDelegate));

		if(LocatorDelegate != null)
			throw new InvalidOperationException("The locator delegate is already assigned.");

		LocatorDelegate = locatorDelegate;
	}

	public static void RemoveLocatorDelegate(Func<IInjector> locatorDelegate)
	{
		if(locatorDelegate == null)
			throw new ArgumentNullException(nameof(locatorDelegate));

		if(LocatorDelegate == locatorDelegate)
			LocatorDelegate = null;
	}
}

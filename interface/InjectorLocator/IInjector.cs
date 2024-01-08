public interface IInjector
{
	T Get<T>() where T : class;
}

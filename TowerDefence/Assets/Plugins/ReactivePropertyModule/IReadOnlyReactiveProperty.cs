using System;

namespace Plugins.ReactivePropertyModule
{
	public interface IReadOnlyReactiveProperty<TValue>
	{
		public event Action<TValue> OnValueChange;
		public TValue Value { get; set; }
	}
}
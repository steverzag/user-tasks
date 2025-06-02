namespace UsersTasks.API.Endpoints.Configuration
{
	public static class EnpointsRegisterer
	{
		public static void RegisterEndpoints(this WebApplication app)
		{

			static bool isAssignableToIEndpoints(Type t) =>
				!t.IsAbstract
				&& !t.IsInterface
				&& typeof(IEndpoints).IsAssignableFrom(t);

			var type = typeof(IEndpoints);
			var endpointsTypes = type.Assembly
				.GetTypes()
				.Where(isAssignableToIEndpoints);

			List<string> failingImplementations = [];
			foreach (var t in endpointsTypes)
			{
				var ctor = t.GetConstructor(Type.EmptyTypes);

				if (ctor is null)
				{
					failingImplementations.Add($"{t.Name}: IEndpoints implementing classes must present an empty constructor");
					continue;
				}

				IEndpoints instance = (IEndpoints)Activator.CreateInstance(t)!;
				instance.RegisterEndpoints(app);
			}

			if (failingImplementations.Count > 0)
			{
				throw new EnpointsRegisterFailedException(failingImplementations);
			}
		}
	}

	public class EnpointsRegisterFailedException(IEnumerable<string> failingImplementations) : Exception("One or more endpoints failed to register")
	{
		public IEnumerable<string> FailingImplementations { get; set; } = failingImplementations;
	}
}

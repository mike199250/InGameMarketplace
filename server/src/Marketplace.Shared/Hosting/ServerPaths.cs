using Microsoft.Extensions.Hosting;

namespace Marketplace.Shared.Hosting;

internal class ServerPaths(IHostEnvironment environment)
{
	private const string MarkerFile = ".server-root";

	public string ServerRoot { get; } = FindServerRoot(environment);

	private static string FindServerRoot(IHostEnvironment environment)
	{
		var dir = new DirectoryInfo(environment.ContentRootPath);
		while (dir != null)
		{
			if (File.Exists(Path.Combine(dir.FullName, MarkerFile)))
			{
				return dir.FullName;
			}

			dir = dir.Parent;
		}
		throw new InvalidOperationException($"Server root marker '{MarkerFile}' was not found.");
	}
}

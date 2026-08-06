using Microsoft.Extensions.Hosting;

namespace Marketplace.Shared.Hosting;

public class ServerPaths(string searchPath)
{
	private const string MarkerFile = ".server-root";

	public string ServerRoot { get; } = FindServerRoot(searchPath);

	public ServerPaths(IHostEnvironment environment) : this(environment.ContentRootPath)
	{
	}

	private static string FindServerRoot(string searchPath)
	{
		var dir = new DirectoryInfo(searchPath);
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

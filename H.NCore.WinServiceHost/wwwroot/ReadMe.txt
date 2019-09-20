dotnet.exe H.SPS.WinServiceHost.dll serviceurl:http://0.0.0.0:8081 servicePath:H.SPS.CommonService.dll action:install


Optionally set the name of the service like this:

ServiceRunner<ExampleService>.Run(config =>
{
	config.SetName("MyTestService");
});
Run the service without arguments and it runs like console app.

Run the service with action:install and it will install the service.

Run the service with action:uninstall and it will uninstall the service.

Run the service with action:start and it will start the service.

Run the service with action:stop and it will stop the service.

Run the service with username:YOUR_USERNAME, password:YOUR_PASSWORD and action:install which installs it for the given account.

Run the service with built-in-account:(NetworkService|LocalService|LocalSystem) and action:install which installs it for the given built in account. Defaults to LocalSystem.

Run the service with description:YOUR_DESCRIPTION and it setup description for the service.

Run the service with display-name:YOUR_DISPLAY_NAME and it setup Display name for the service.

Run the service with name:YOUR_NAME and it setup name for the service.

Run the service with start-immediately:(true|false) to start service immediately after install. Defaults to true.

You can find the complete example in PeterKottas.DotNetCore.Example project.

Install the service using powershell: dotnet.exe $serviceDllPath action:install
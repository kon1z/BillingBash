﻿using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Kon.AccountingService.HttpApi.Client.ConsoleTestApp;

public class ClientDemoService : ITransientDependency
{
    public Task RunAsync()
    {
	    return Task.CompletedTask;
    }
}

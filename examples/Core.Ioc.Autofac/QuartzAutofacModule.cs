﻿using System.Diagnostics.CodeAnalysis;
using Autofac;
using Core.Jobs;
using Quartz;
using Scheduler.Quartz.Ioc.Autofac.Modules;

namespace Core.Ioc.Autofac
{
    /// <inheritdoc />
    /// <summary>
    /// Dependencies registration module for Quartz scheduler
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class QuartzAutofacModule : QuartzModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // Register all our Quartz jobs
            builder.RegisterTypes(GetTypes(typeof(ExampleLogJob)))
                .Where(t => t != typeof(IJob) && typeof(IJob).IsAssignableFrom(t))
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
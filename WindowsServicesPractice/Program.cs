﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace WindowsServicesPractice
{
    class Program
    {
        static void Main(string[] args)
        {

            HostFactory.Run(serviceConfig => {
                serviceConfig.UseNLog();

                serviceConfig.Service<ConverterService>(
                    serviceInstance =>
                    {
                        serviceInstance.ConstructUsing(
                            () => new ConverterService());

                        serviceInstance.WhenStarted(execute => execute.Start());

                        serviceInstance.WhenStopped(execute => execute.Stop());
                    });

                serviceConfig.SetServiceName("AwesomeFileConverter");
                serviceConfig.SetDisplayName("Awesome File Converter");
                serviceConfig.SetDescription("A demo service for capitalizing files. Super useful");

                serviceConfig.StartAutomatically();
            });
        }
    }
}

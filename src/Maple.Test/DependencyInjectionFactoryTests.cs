﻿using DryIoc;
using Maple.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maple.Test
{
    [TestClass]
    public class DependencyInjectionFactoryTests
    {

        [TestMethod]
        public async Task SanityMapleGetContainerTest()
        {
            var container = await DependencyInjectionFactory.Get().ConfigureAwait(false);
            container.VerifyResolutions();
        }

        [TestMethod]
        public async Task ResolveLoadablesAsList()
        {
            var container = await DependencyInjectionFactory.Get().ConfigureAwait(false);

            var factory = Substitute.For<IWavePlayerFactory>();
            container.UseInstance(factory);

            var loadables = container.Resolve<IList<ILoadableViewModel>>();

            Assert.IsNotNull(loadables);
            Assert.IsTrue(loadables?.Count > 3, $"Only {loadables.Count} instance(s) found");
        }

        [TestMethod]
        public async Task ResolveManyLoadablesAsList()
        {
            var container = await DependencyInjectionFactory.Get().ConfigureAwait(false);

            var factory = Substitute.For<IWavePlayerFactory>();
            container.UseInstance(factory);

            var loadables = container.ResolveMany<ILoadableViewModel>().ToList();

            Assert.IsNotNull(loadables);
            Assert.IsTrue(loadables?.Count > 3, $"Only {loadables.Count} instance(s) found");
        }
    }
}
